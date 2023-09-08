using System;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows
{
    public class UpdateWorkFlowCommentJobArgs
    {
        public Guid WorkFlowId { get; set; }
        public string Comment { get; set; } = default!;
    }
}
