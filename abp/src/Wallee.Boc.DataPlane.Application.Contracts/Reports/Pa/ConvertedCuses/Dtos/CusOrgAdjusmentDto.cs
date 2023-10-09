using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

/// <summary>
/// 客户机构调整
/// </summary>
[Serializable]
public class CusOrgAdjusmentDto : AuditedEntityDto
{
    public string Cusidt { get; set; } = default!;

    public string Orgidt { get; set; } = default!;
}