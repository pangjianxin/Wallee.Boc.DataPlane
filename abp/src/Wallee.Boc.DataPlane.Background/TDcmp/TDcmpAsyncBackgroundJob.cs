﻿using Cronos;
using FluentFTP;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Text;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BlobStoring;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.Blobs;
using Wallee.Boc.DataPlane.TDcmp;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public abstract class TDcmpAsyncBackgroundJob<TArgs> : AsyncBackgroundJob<TArgs> where TArgs : TDcmpBackgroundJobArgs
    {
        protected ITDcmpWorkFlowRepository Repository { get; set; }
        protected FtpOptions FtpOptions { get; set; }
        protected IBlobContainer<DataPlaneFileContainer> TDcmpFileContainer { get; set; }
        protected IClock Clock { get; set; }

        public TDcmpAsyncBackgroundJob(
            IOptions<FtpOptions> ftpOptions,
            IBlobContainer<DataPlaneFileContainer> tDcmpFileContainer,
            IClock clock,
            ITDcmpWorkFlowRepository repository)
        {
            FtpOptions = ftpOptions.Value;
            TDcmpFileContainer = tDcmpFileContainer;
            Clock = clock;
            Repository = repository;
        }
        protected async Task<Stream> GetStreamFromFtp(TDcmpWorkFlow workFlow, TArgs args)
        {

            var fileDate = workFlow.DataDate.ToString("yyyyMMdd");

            var ccicBasicFileName = string.Format(FtpOptions.CcicBasicFileName, fileDate);

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
                args.Exception = "下载未成功";
                throw new AbpException("下载未成功");
            }

            memory.Seek(0, SeekOrigin.Begin);

            return memory;
        }

        protected async Task PrepareCcicBasicTempTableAsync(string connStr, string tableName, string blobName)
        {
            using var conn = new SqlConnection(connStr);
            await conn.OpenAsync();

            using var tran = conn.BeginTransaction($"CREATE_{tableName}");
            try
            {
                var sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = tran;

                sqlCommand.CommandText = string.Format(Encoding.UTF8.GetString(await TDcmpFileContainer.GetAllBytesAsync(blobName)), tableName);

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