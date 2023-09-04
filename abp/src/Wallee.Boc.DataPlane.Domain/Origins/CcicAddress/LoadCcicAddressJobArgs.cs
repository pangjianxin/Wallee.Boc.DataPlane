using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Origins.CcicAddress
{
    [BackgroundJobName(OriginsBackgroundJobNameConsts.LoadCcicAddresss)]
    public class LoadCcicAddressJobArgs : OriginsBackgroundJobArgs
    {
    }
}
