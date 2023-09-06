using System;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;

[Serializable]
public class CreateUpdateTDcmpWorkFlowDto
{
    /// <summary>
    /// 数据日期
    /// </summary>
    public DateTime DataDate { get; set; }
    public string CronExpression { get; set; } = default!;
}