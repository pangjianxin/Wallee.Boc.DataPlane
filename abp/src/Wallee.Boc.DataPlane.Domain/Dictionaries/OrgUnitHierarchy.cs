using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.DataPlane.Dictionaries
{
    /// <summary>
    /// 机构层级表
    /// </summary>
    public class OrgUnitHierarchy : AuditedAggregateRoot<Guid>
    {
        protected OrgUnitHierarchy() { }
        public OrgUnitHierarchy(Guid id, Guid? parentId, string orgIdentity, string name) : base(id)
        {
            ParentId = parentId;
            OrgIdentity = orgIdentity;
            Name = name;
        }

        public Guid? ParentId { get; private set; }
        public string OrgIdentity { get; private set; } = default!;
        public string Name { get; private set; } = default!;

        public void UpdateInfo(string name, string identity)
        {
            Name = name;
            OrgIdentity = identity;
        }

        public void Move(Guid? parentId)
        {
            ParentId = parentId;
        }
    }
}
