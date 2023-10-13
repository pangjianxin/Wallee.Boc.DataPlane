using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPersonalRelations;

public class CcicPersonalRelationRepository : UpsertableEfCoreRepository<CcicPersonalRelation>, ICcicPersonalRelationRepository
{
    public CcicPersonalRelationRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public override async Task<IQueryable<CcicPersonalRelation>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}