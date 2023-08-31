using System;
using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    [BackgroundJobName("second job")]
    public class SecondJobArgs : BackgroundJobArgsWithContinuation<ThirdJobArgs>
    {
        public DateTime Date { get; set; }
    }
}
