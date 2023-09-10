using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicAntiMoneyLaundering)]
    public class LoadCcicAntiMoneyLaunderingJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
