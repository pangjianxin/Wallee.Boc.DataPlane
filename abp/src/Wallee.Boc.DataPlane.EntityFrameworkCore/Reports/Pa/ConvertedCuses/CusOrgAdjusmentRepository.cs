using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Timing;
using Wallee.Boc.DataPlane.EntityFrameworkCore;
using Wallee.Boc.DataPlane.Repositories;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;

#pragma warning disable CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
public class CusOrgAdjusmentRepository : UpsertableEfCoreRepository<CusOrgAdjusment>, ICusOrgAdjusmentRepository
#pragma warning restore CS8613 // �����������������͵�Ϊ Null ������ʽʵ�ֵĳ�Ա��ƥ�䡣
{
    public IClock Clock { get; set; }

    public CusOrgAdjusmentRepository(
        IDbContextProvider<DataPlaneDbContext> dbContextProvider,
        IClock clock) : base(dbContextProvider)
    {
        Clock = clock;
    }
    public override async Task<IQueryable<CusOrgAdjusment>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}