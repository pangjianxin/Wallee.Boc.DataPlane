using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicAddresss)]
    public class LoadCcicAddressJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
