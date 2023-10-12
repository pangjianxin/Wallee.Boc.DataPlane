using AutoFilterer.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicIds.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds;


/// <summary>
/// 对公证件信息    a20
/// </summary>
public class CcicIdAppService : AbstractKeyReadOnlyAppService<CcicId, CcicIdDto, CcicIdKey, CcicIdGetListInput>,
    ICcicIdAppService
{
  

    private readonly ICcicIdRepository _repository;

    public CcicIdAppService(ICcicIdRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicId> GetEntityByIdAsync(CcicIdKey id)
    {
        // TODO: AbpHelper generated
        return (await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.CRDT_TP == id.CRDT_TP &&
                e.CRDT_SN == id.CRDT_SN &&
                e.LGPER_CODE == id.LGPER_CODE
            )))!;
    }

    protected override IQueryable<CcicId> ApplyDefaultSorting(IQueryable<CcicId> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicId>> CreateFilteredQueryAsync(CcicIdGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
