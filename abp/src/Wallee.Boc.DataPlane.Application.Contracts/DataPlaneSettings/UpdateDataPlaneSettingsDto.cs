using System;
using System.Collections.Generic;
using System.Text;

namespace Wallee.Boc.DataPlane.DataPlaneSettings
{
    public class UpdateDataPlaneSettingsDto
    {
        public string TDcmpWorkFlowCronExpression { get; set; } = default!;
        public string ConvertedCusFilterRules { get; set; } = default!;
        public decimal ConvertedCusOrgUnitFirstLevel { get; set; }
        public decimal ConvertedCusOrgUnitSecondLevel { get; set; }
        public decimal ConvertedCusOrgUnitThirdLevel { get; set; }
        public decimal ConvertedCusOrgUnitFourthLevel { get; set; }
        public decimal ConvertedCusOrgUnitFifthLevel { get; set; }
        public decimal ConvertedCusOrgUnitSixthLevel { get; set; }
    }
}
