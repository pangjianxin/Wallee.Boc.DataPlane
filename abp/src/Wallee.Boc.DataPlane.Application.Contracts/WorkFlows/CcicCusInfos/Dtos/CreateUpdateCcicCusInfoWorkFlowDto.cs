using System;

namespace Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Dtos;

[Serializable]
public class CreateUpdateCcicCusInfoWorkFlowDto
{
    /// <summary>
    /// 数据日期
    /// </summary>
    public DateTime DataDate { get; set; }
}