using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits
{
    /// <summary>
    /// 折效客户机构分布情况
    /// </summary>
    public class ConvertedCusOrgUnit : BasicAggregateRoot
    {
        public DateTime DataDate { get; set; }
        public string OrgIdentity { get; set; } = default!;
        public string OrgName { get; set; } = default!;
        public decimal FirstLevel { get; set; }
        public decimal SecondLevel { get; set; }
        public decimal ThirdLevel { get; set; }
        public decimal FourthLevel { get; set; }
        public decimal FifthLevel { get; set; }
        public decimal SixthLevel { get; set; }
        public string? ParentName { get; set; }
        public string? ParentIdentity { get; set; }
        public ConvertedCusOrgUnit()
        {
        }

        public override object[] GetKeys()
        {
            return new object[] { DataDate, OrgIdentity };
        }

        public void SetParentInfo(string parentName, string parentIdentity)
        {
            ParentName = parentName;
            ParentIdentity = parentIdentity;
        }
    }
}
