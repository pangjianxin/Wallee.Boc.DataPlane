using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.Origins;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics
{
    [BackgroundJobName(OriginsBackgroundJobNameConsts.LoadCcicBasics)]
    public class LoadCcicBasicJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
