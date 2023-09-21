using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicCustomerType)]
    public class LoadCcicCustomerTypeJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
