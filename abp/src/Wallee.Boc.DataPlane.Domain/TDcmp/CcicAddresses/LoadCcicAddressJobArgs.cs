using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicAddresss)]
    public class LoadCcicAddressJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
