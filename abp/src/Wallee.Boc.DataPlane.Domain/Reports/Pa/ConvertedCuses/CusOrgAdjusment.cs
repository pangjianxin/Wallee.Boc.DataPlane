using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses
{
    /// <summary>
    /// 客户机构调整
    /// </summary>
    public class CusOrgAdjusment : AuditedAggregateRoot
    {
        public string Cusidt { get; set; } = default!;
        public string Orgidt { get; set; } = default!;

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
