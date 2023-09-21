using System;

namespace Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos
{
    public class UpdateCcicCusInfoWorkFlowCommentJobArgs
    {
        public Guid WorkFlowId { get; set; }
        public string Comment { get; set; } = default!;
    }
}
