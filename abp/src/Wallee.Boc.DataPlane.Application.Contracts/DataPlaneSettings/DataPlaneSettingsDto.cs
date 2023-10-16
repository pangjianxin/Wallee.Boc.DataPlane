namespace Wallee.Boc.DataPlane.DataPlaneSettings
{
    public class DataPlaneSettingsDto
    {
        public string TDcmpWorkFlowCronExpression { get; set; } = default!;
        public string OrgUnitHierarchyVisiblity { get; set; } = default!;
        public decimal ConvertedCusOrgUnitFirstLevel { get; set; }
        public decimal ConvertedCusOrgUnitSecondLevel { get; set; }
        public decimal ConvertedCusOrgUnitThirdLevel { get; set; }
        public decimal ConvertedCusOrgUnitFourthLevel { get; set; }
        public decimal ConvertedCusOrgUnitFifthLevel { get; set; }
        public decimal ConvertedCusOrgUnitSixthLevel { get; set; }
    }
}
