namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos
{
    public class ExecutingTDcmpWorkFlowDto
    {
        public TDcmpWorkFlowDto Dto { get; set; } = default!;
        public string DotGraph { get; set; } = default!;
    }
}
