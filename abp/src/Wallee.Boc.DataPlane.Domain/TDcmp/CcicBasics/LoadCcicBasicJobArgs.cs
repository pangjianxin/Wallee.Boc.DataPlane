using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicBasics)]
    public class LoadCcicBasicJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
