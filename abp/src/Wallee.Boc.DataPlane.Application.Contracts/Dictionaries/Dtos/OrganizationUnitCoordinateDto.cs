using System;
using Volo.Abp.Application.Dtos;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos;

[Serializable]
public class OrganizationUnitCoordinateDto : EntityDto<Guid>
{
    /// <summary>
    /// 机构名
    /// </summary>
    public string OrgName { get; set; } = default!;
    /// <summary>
    /// 机构号
    /// </summary>
    public string OrgNo { get; set; } = default!;
    /// <summary>
    /// 纬度
    /// </summary>
    public double Latitude { get; set; }
    /// <summary>
    /// 经度
    /// </summary>
    public double Longitude { get; set; }
    /// <summary>
    /// 区划编码
    /// </summary>
    public string RegionCode { get; set; } = default!;
}