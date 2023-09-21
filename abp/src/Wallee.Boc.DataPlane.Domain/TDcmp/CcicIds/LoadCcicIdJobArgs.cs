using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicId)]
    public class LoadCcicIdJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
