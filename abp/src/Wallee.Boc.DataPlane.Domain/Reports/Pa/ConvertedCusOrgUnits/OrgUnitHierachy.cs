using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCusOrgUnits
{
    /// <summary>
    /// 机构层级表
    /// </summary>
    public class OrgUnitHierachy : AuditedAggregateRoot
    {
        public string Orgidt { get; private set; } = default!;
        public string OrgName { get; private set; } = default!;
        public string UpOrgidt { get; private set; } = default!;
        public string UpOrgName { get; private set; } = default!;
        public override object[] GetKeys()
        {
            return new object[]
            {
                Orgidt
            };
        }
    }
}
