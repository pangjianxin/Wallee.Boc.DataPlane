using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicSignOrg)]
    public class LoadCcicSignOrgJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
