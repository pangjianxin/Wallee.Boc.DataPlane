using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicGeneralOrg)]
    public class LoadCcicGeneralOrgJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
