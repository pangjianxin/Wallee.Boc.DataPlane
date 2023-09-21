using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicPhone)]
    public class LoadCcicPhoneJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
