using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicLsolationList)]
    public class LoadCcicLsolationListJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
