using AutoFilterer.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicBasics.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics;


/// <summary>
/// 对公客户基础信息
/// </summary>
public class CcicBasicAppService : AbstractKeyReadOnlyAppService<CcicBasic, CcicBasicDto, CcicBasicKey, CcicBasicGetListInput>, ICcicBasicAppService
{
    private readonly ICcicBasicRepository _repository;

    public CcicBasicAppService(ICcicBasicRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicBasic> GetEntityByIdAsync(CcicBasicKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicBasic> ApplyDefaultSorting(IQueryable<CcicBasic> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicBasic>> CreateFilteredQueryAsync(CcicBasicGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
