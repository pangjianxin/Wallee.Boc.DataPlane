using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using Volo.Abp.AuditLogging.EntityFrameworkCore;

namespace Wallee.Boc.DataPlane.Dictionaries;

#pragma warning disable CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
public class OrganizationUnitCoordinateRepository : EfCoreRepository<DataPlaneDbContext, OrganizationUnitCoordinate, Guid>, IOrganizationUnitCoordinateRepository
#pragma warning restore CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
{
    public OrganizationUnitCoordinateRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public override async Task<IQueryable<OrganizationUnitCoordinate>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}