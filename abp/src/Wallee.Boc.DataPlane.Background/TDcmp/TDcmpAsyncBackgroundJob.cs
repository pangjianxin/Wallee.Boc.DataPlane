using Cronos;
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

namespace Wallee.Boc.DataPlane.Background.TDcmp
{
    public abstract class TDcmpAsyncBackgroundJob<TArgs> : AsyncBackgroundJob<TArgs> where TArgs : TDcmpBackgroundJobArgs
    {
        protected readonly FtpOptions _ftpOptions;
        protected readonly IBlobContainer<DataPlaneFileContainer> _tDcmpFileContainer;
        protected readonly IClock _clock;

        public TDcmpAsyncBackgroundJob(
            IOptions<FtpOptions> ftpOptions,
            IBlobContainer<DataPlaneFileContainer> tDcmpFileContainer,
            IClock clock)
        {
            _ftpOptions = ftpOptions.Value;
            _tDcmpFileContainer = tDcmpFileContainer;
            _clock = clock;
        }
        protected async Task<Stream> GetStreamFromFtp(TArgs args)
        {
            var fileDate = args.DataDate.ToString("yyyyMMdd");

            var ccicBasicFileName = string.Format(_ftpOptions.CcicBasicFileName, fileDate);

            var ftpBasePath = string.Format(_ftpOptions.FtpBasePath, fileDate);
            var bormFileFullName = Path.Combine(ftpBasePath, ccicBasicFileName);
            using IAsyncFtpClient ftpClient = new AsyncFtpClient(_ftpOptions.Address, _ftpOptions.UserName, _ftpOptions.Password);
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

        protected async Task PrepareCcicBasicTempTableAsync(string connStr, string tableName)
        {
            using var conn = new SqlConnection(connStr);
            await conn.OpenAsync();

            using var tran = conn.BeginTransaction($"CREATE_{tableName}");
            try
            {
                var sqlCommand = conn.CreateCommand();
                sqlCommand.Transaction = tran;

                sqlCommand.CommandText = string.Format(Encoding.UTF8.GetString(await _tDcmpFileContainer.GetAllBytesAsync("")), tableName);

                await sqlCommand.ExecuteNonQueryAsync();

                await tran.CommitAsync();
            }
            catch
            {
                await tran.RollbackAsync();

                throw;
            }
        }

        protected TimeSpan CalculateNextLoopDelay(DateTime currentDate)
        {
            var now = _clock.Now;

            var nextFileDateTime = currentDate.Date.AddDays(1);

            var delay = TimeSpan.FromSeconds(5);

            if (nextFileDateTime.Date >= now.Date)
            {
                var nextTryTimeCron = CronExpression.Parse(_ftpOptions.TDcmpJobExecutionCronExpression);

                var nextTryTime = nextTryTimeCron.GetNextOccurrence((DateTimeOffset)nextFileDateTime.AddDays(1), TimeZoneInfo.Local)!.Value;

                delay = nextTryTime - now;
            }

            return delay;
        }
    }
}
