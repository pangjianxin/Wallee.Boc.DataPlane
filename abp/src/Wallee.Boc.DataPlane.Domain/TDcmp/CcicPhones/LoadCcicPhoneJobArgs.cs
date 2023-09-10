using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicPhone)]
    public class LoadCcicPhoneJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
