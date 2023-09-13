using System;

namespace Wallee.Boc.DataPlane.Dictionaries.Dtos;

[Serializable]
public class CreateUpdateOrganizationUnitCoordinateDto
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
}