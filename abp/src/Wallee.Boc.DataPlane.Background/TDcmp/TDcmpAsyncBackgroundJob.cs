using FluentFTP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.Background.Ftp;
using Wallee.Boc.DataPlane.Blobs;
using Wallee.Boc.DataPlane.Extensions;
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
                throw new AbpException("下载未成功");
            }

            memory.Seek(0, SeekOrigin.Begin);

            return memory;
        }

        protected virtual async Task<string> PrepareTempTableAsync<T>(IReadOnlyRepository<T> repository) where T : AggregateRoot
        {
            var tableName = await repository.GetTableName("Temp");

            var dbContext = await repository.GetDbContextAsync();

            var count = (await dbContext.Database.SqlQueryRaw<int>($"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'")
                .ToListAsync())
                .FirstOrDefault();

            if (count > 0)
            {
                await dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}");
            }
            else
            {
                var createTableScript = await repository.GenerateCreateTableScript(tableName);
                await dbContext.Database.ExecuteSqlRawAsync(createTableScript);
            }

            return tableName;
        }
    }
}
