using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPractices;

public class CcicPracticeRepository : UpsertableEfCoreRepository<CcicPractice>, ICcicPracticeRepository
{
    public CcicPracticeRepository(IDbContextProvider<DataPlaneDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<CcicPractice>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}