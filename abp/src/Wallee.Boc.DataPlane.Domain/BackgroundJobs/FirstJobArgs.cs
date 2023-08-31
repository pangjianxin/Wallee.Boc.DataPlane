using System;
using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    [BackgroundJobName("first job")]
    public class FirstJobArgs : BackgroundJobArgsWithContinuation<SecondJobArgs>
    {
        public DateTime Date { get; set; }
    }
}
