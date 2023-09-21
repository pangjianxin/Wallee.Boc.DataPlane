using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicGeneralOrg)]
    public class LoadCcicGeneralOrgJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
