using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using Volo.Abp.AuditLogging.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Dictionaries;

#pragma warning disable CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
public class OrganizationUnitCoordinateRepository : EfCoreRepository<DataPlaneDbContext, OrganizationUnitCoordinate, Guid>, IOrganizationUnitCoordinateRepository
#pragma warning restore CS8613 // 返回类型中引用类型的为 Null 性与隐式实现的成员不匹配。
{
    public OrganizationUnitCoordinateRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public override async Task<IQueryable<OrganizationUnitCoordinate>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}