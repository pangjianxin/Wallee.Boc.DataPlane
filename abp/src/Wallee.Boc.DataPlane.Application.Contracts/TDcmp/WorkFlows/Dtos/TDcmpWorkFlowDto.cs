using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;

/// <summary>
/// 信息管理平台工作流
/// </summary>
[Serializable]
public class TDcmpWorkFlowDto : AuditedEntityDto<Guid>
{
    /// <summary>
    /// 状态
    /// </summary>
    public TDcmpStatus Status { get; set; }

    /// <summary>
    /// 数据日期
    /// </summary>
    public DateTime DataDate { get; set; }

    /// <summary>
    /// 备注(有可能会记录异常的堆栈信息)
    /// </summary>
    public string? Comment { get; set; }

    public int TotalTaskCount { get; set; }
    public int CompletedCount { get; set; }
}