using System;

namespace Wallee.Boc.DataPlane.BackgroundJobs
{
    public abstract class BackgroundJobArgsWithContinuation<TNext>
    {
        public DateTime ReportDate { get; set; }
        public TNext Continuation { get; set; } = default!;
    }
}
