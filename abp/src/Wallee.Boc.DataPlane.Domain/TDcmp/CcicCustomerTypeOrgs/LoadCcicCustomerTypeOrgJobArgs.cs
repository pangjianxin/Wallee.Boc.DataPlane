using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicCustomerTypeOrg)]
    public class LoadCcicCustomerTypeOrgJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
