using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicCustomerType)]
    public class LoadCcicCustomerTypeJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
