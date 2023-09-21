using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicAntiMoneyLaundering)]
    public class LoadCcicAntiMoneyLaunderingJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
