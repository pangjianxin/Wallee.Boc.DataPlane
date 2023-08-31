using System;
using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    [BackgroundJobName("third job")]
    public class ThirdJobArgs : BackgroundJobArgsWithContinuation<FirstJobArgs>
    {
        public DateTime Date { get;set; }
    }
}
