using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicPractice)]
    public class LoadCcicPracticeJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
