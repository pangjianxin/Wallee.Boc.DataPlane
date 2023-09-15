using System;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;

[Serializable]
public class CreateUpdateConvertedCusOrgUnitDto
{
    public string Label { get; set; } = default!;

    public string UpOrgidt { get; set; } = default!;

    public string Orgidt { get; set; } = default!;

    public decimal FirstLevel { get; set; }

    public decimal SecondLevel { get; set; }

    public decimal ThirdLevel { get; set; }

    public decimal FourthLevel { get; set; }

    public decimal FifthLevel { get; set; }

    public decimal SixthLevel { get; set; }
}