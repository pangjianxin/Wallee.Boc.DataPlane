using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicId)]
    public class LoadCcicIdJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
