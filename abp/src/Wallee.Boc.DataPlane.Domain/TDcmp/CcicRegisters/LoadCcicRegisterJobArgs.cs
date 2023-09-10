using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicRegister)]
    public class LoadCcicRegisterJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
