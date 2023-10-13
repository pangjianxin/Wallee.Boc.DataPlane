using CsvHelper;
using CsvHelper.Configuration;
using FluentFTP;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.Repositories;
using Wallee.Boc.DataPlane.TDcmp;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public abstract class CcicCusInfoAsyncBackgroundJob<TArgs> : AsyncBackgroundJob<TArgs> where TArgs : TDcmpBackgroundJobArgs
    {
        protected ICcicCusInfoWorkFlowRepository Repository { get; }
        public IConfiguration Config { get; }
        protected FtpOptions FtpOptions { get; }
        protected IClock Clock { get; }

        public CcicCusInfoAsyncBackgroundJob(
            IOptions<FtpOptions> ftpOptions,
            IClock clock,
            ICcicCusInfoWorkFlowRepository repository,
            IConfiguration config)
        {
            FtpOptions = ftpOptions.Value;
            Clock = clock;
            Repository = repository;
            Config = config;
        }
        protected async Task<Stream> GetStreamFromFtp(CcicCusInfoWorkFlow workFlow, string fileName)
        {
            var fileDate = workFlow.DataDate.ToString("yyyyMMdd");

            var ccicBasicFileName = string.Format(fileName, fileDate);

            var ftpBasePath = string.Format(FtpOptions.FtpBasePath, fileDate);

            var bormFileFullName = Path.Combine(ftpBasePath, ccicBasicFileName);

            using IAsyncFtpClient ftpClient = new AsyncFtpClient(FtpOptions.Address, FtpOptions.UserName, FtpOptions.Password);
            await ftpClient.AutoConnect();

            if (!await ftpClient.FileExists(bormFileFullName))
            {
                throw new FileNotFoundException(bormFileFullName);
            }

            var memory = new MemoryStream();

            var result = await ftpClient.DownloadStream(memory, bormFileFullName);

            if (!result)
            {
                throw new AbpException("下载未成功");
            }

            memory.Seek(0, SeekOrigin.Begin);

            return memory;
        }

        protected virtual async Task UpsertAsync<T>(Stream stream, IUpsertableRepository<T> tDcmpRepository, Type csvClassMap) where T : BasicAggregateRoot
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var gzStream = new GZipStream(stream, CompressionMode.Decompress);
            using var streamReader = new StreamReader(gzStream, Encoding.GetEncoding(FtpOptions.Encoding));

            using var csv = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                TrimOptions = TrimOptions.Trim | TrimOptions.InsideQuotes,
                Delimiter = "\u0001|\u0001",
                ShouldSkipRecord = args =>
                {
                    if (args.Row.Parser.RawRecord.StartsWith("|||diip-control|||"))
                    {
                        return true;
                    }
                    return false;
                },
            });

            csv.Context.RegisterClassMap(csvClassMap);

            var records = csv.GetRecords<T>();

            await tDcmpRepository.UpsertAsync(records);
        }

        protected async Task WriteExceptionAsync(CcicCusInfoWorkFlow workFlow, Exception exception)
        {
            var connStr = Config.GetConnectionString("Default");

            using var conn = new SqlConnection(connStr);
            await conn.OpenAsync();

            using var tran = conn.BeginTransaction("CcicCusInfoWorkFlows_Exception");
            try
            {
                var sqlCommand = conn.CreateCommand();

                sqlCommand.Transaction = tran;

                sqlCommand.CommandText = @$"UPDATE dbo.AppCcicCusInfoWorkFlows SET Comment=N'{exception.Message.Replace("'", "''")}',
                                            LastModificationTime='{Clock.Now:yyyy-MM-dd HH:mm:ss}'  WHERE ID='{workFlow.Id}'";

                await sqlCommand.ExecuteNonQueryAsync();

                await tran.CommitAsync();
            }
            catch
            {
                await tran.RollbackAsync();

                throw;
            }
        }
    }
}
