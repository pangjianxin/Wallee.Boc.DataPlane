using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.Origins.CcicBasics
{
    [BackgroundJobName(OriginsBackgroundJobNameConsts.LoadCcicBasics)]
    public class LoadCcicBasicJobArgs : OriginsBackgroundJobArgs
    {
    }
}
