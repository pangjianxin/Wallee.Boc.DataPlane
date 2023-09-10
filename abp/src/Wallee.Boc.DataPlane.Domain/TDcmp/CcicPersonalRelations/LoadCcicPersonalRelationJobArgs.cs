using Volo.Abp.BackgroundJobs;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations
{
    [BackgroundJobName(TDcmpBackgroundJobNameConsts.LoadCcicPersonalRelation)]
    public class LoadCcicPersonalRelationJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
