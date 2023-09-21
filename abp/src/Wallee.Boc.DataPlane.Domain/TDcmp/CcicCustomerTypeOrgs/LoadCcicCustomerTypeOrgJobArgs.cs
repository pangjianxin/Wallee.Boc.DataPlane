using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicCustomerTypeOrg)]
    public class LoadCcicCustomerTypeOrgJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
