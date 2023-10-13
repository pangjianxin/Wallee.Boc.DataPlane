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
        public OrgUnitHierarchy(Guid id, Guid? parentId, string identity, string name) : base(id)
        {
            ParentId = parentId;
            Identity = identity;
            Name = name;
        }

        public Guid? ParentId { get; private set; }
        public string Identity { get; private set; } = default!;
        public string Name { get; private set; } = default!;

        public void UpdateInfo(string name, string identity)
        {
            Name = name;
            Identity = identity;
        }

        public void Move(Guid? parentId)
        {
            ParentId = parentId;
        }
    }
}
