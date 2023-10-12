using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;

/// <summary>
/// 客户机构调整
/// </summary>
[Serializable]
public class CusOrgAdjusmentDto : EntityDto,IModificationAuditedObject
{
    public string Cusidt { get; set; } = default!;

    public string Orgidt { get; set; } = default!;

    public Guid? LastModifierId { get; set; }

    public DateTime? LastModificationTime { get; set; }
}