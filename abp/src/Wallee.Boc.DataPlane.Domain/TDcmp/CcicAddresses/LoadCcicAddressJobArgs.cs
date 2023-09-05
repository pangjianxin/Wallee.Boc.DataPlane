using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.Origins;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses
{
    [BackgroundJobName(OriginsBackgroundJobNameConsts.LoadCcicAddresss)]
    public class LoadCcicAddressJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
