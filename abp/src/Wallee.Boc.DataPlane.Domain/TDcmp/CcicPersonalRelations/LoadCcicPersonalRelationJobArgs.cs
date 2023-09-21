using Volo.Abp.BackgroundJobs;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations
{
    [BackgroundJobName(CcicCusInfoWorkFlowBackgroundJobNameConsts.LoadCcicPersonalRelation)]
    public class LoadCcicPersonalRelationJobArgs : TDcmpBackgroundJobArgs
    {
    }
}
