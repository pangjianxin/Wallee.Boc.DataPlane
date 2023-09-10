using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicName)]
    public class LoadCcicNameJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
