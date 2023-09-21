using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicPractice)]
    public class LoadCcicPracticeJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
