using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses
{
    /// <summary>
    /// 客户机构调整
    /// </summary>
    public class CusOrgAdjusment : BasicAggregateRoot, IModificationAuditedObject
    {
        public string Cusidt { get; set; } = default!;
        public string Orgidt { get; set; } = default!;

        public Guid? LastModifierId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public CusOrgAdjusment() { }

        public override object[] GetKeys()
        {
            return new object[]
            {
                Cusidt
            };
        }
    }
}
