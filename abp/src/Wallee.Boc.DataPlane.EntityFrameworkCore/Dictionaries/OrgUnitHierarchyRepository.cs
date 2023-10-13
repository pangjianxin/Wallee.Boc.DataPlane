using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Dictionaries;

#pragma warning disable CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
public class OrgUnitHierarchyRepository : EfCoreRepository<DataPlaneDbContext, OrgUnitHierarchy, Guid>, IOrgUnitHierarchyRepository
#pragma warning restore CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
{
    public OrgUnitHierarchyRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<OrgUnitHierarchy>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}