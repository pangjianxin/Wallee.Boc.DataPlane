using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicBasics)]
    public class LoadCcicBasicJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
