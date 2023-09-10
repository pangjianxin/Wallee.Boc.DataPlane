using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicSignOrg)]
    public class LoadCcicSignOrgJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
