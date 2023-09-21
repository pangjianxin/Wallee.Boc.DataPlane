using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicName)]
    public class LoadCcicNameJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
