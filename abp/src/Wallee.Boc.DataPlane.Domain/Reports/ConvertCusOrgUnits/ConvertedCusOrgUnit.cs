using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits
{
    /// <summary>
    /// 折效客户机构分布情况
    /// </summary>
    public class ConvertedCusOrgUnit : AuditedAggregateRoot<Guid>
    {
        public string Label { get; private set; } = default!;
        public string UpOrgidt { get; private set; } = default!;
        public string Orgidt { get; private set; } = default!;
        public decimal FirstLevel { get; private set; }
        public decimal SecondLevel { get; private set; }
        public decimal ThirdLevel { get; private set; }
        public decimal FourthLevel { get; private set; }
        public decimal FifthLevel { get; private set; }
        public decimal SixthLevel { get; private set; }
        public DateTime DataDate { get; private set; }

        protected ConvertedCusOrgUnit()
        {
        }

        public ConvertedCusOrgUnit(
            Guid id,
            string label,
            string upOrgidt,
            string orgidt,
            DateTime dataDate,
            decimal firstLevel,
            decimal secondLevel,
            decimal thirdLevel,
            decimal fourthLevel,
            decimal fifthLevel,
            decimal sixthLevel
        ) : base(id)
        {
            Label = label;
            UpOrgidt = upOrgidt;
            Orgidt = orgidt;
            DataDate = dataDate;
            FirstLevel = firstLevel;
            SecondLevel = secondLevel;
            ThirdLevel = thirdLevel;
            FourthLevel = fourthLevel;
            FifthLevel = fifthLevel;
            SixthLevel = sixthLevel;
        }
    }
}
