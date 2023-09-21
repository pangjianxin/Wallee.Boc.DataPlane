using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicRegister)]
    public class LoadCcicRegisterJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
