using CsvHelper;
using CsvHelper.Configuration;
using FluentFTP;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.Blobs;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics;

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public class LoadCcicBasicJob : TDcmpAsyncBackgroundJob<LoadCcicBasicJobArgs>, ITransientDependency
    {
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly IConfiguration _configuration;

        public LoadCcicBasicJob(
            IBackgroundJobManager backgroundJobManager,
            IBlobContainer<DataPlaneFileContainer> tDcmpFileContainer,
            IOptions<FtpOptions> ftpOptions,
            IConfiguration configuration,
            IClock clock) : base(ftpOptions, tDcmpFileContainer, clock)
        {
            _backgroundJobManager = backgroundJobManager;
            _configuration = configuration;
        }
        public override async Task ExecuteAsync(LoadCcicBasicJobArgs args)
        {
            var connStr = _configuration.GetConnectionString("Default");
            var tableName = "dbo.CcicBasic_Tmp";
            await PrepareCcicBasicTempTableAsync(connStr!, tableName);
            using var stream = await GetStreamFromFtp(args);
            await LoadCcicBasicTemp(stream, tableName);
        }

        private async Task LoadCcicBasicTemp(Stream stream, string tableName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var connStr = _configuration.GetConnectionString("Default");

            using var conn = new SqlConnection(connStr);

            await conn.OpenAsync();

            using var tran = conn.BeginTransaction($"CREATE_{tableName}");

            try
            {
                using (var gzStream = new GZipStream(stream, CompressionMode.Decompress))
                {
                    using var streamReader = new StreamReader(gzStream, Encoding.GetEncoding("GB18030"));

                    using var csv = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false,
                        TrimOptions = TrimOptions.Trim | TrimOptions.InsideQuotes,
                    });

                    // make sure to enable triggers
                    // more on triggers in next post
                    SqlBulkCopy bulkCopy = new(
                        conn,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers,
                        tran)
                    {
                        // set the destination table name
                        DestinationTableName = tableName
                    };

                    using var csvDataReader = new CsvDataReader(csv);

                    await bulkCopy.WriteToServerAsync(csvDataReader);
                }

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
