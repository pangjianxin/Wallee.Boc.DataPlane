using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits
{
    /// <summary>
    /// 折效客户机构分布情况
    /// </summary>
    public class ConvertedCusOrgUnit : AggregateRoot, IModificationAuditedObject
    {
        public DateTime DataDate { get; set; }
        public string Orgidt { get; set; } = default!;
        public string Label { get; set; } = default!;
        public string UpOrgidt { get; set; } = default!;
        public decimal FirstLevel { get; set; }
        public decimal SecondLevel { get; set; }
        public decimal ThirdLevel { get; set; }
        public decimal FourthLevel { get; set; }
        public decimal FifthLevel { get; set; }
        public decimal SixthLevel { get; set; }

        public Guid? LastModifierId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public ConvertedCusOrgUnit()
        {
        }

        public override object[] GetKeys()
        {
            return new object[] { DataDate, Orgidt };
        }
    }
}