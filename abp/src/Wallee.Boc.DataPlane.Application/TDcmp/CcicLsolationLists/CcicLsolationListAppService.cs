using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicLsolationLists;


/// <summary>
/// 对公隔离清单信息    a82
/// </summary>
public class CcicLsolationListAppService : AbstractKeyReadOnlyAppService<CcicLsolationList, CcicLsolationListDto, CcicLsolationListKey, CcicLsolationListGetListInput>,
    ICcicLsolationListAppService
{


    private readonly ICcicLsolationListRepository _repository;

    public CcicLsolationListAppService(ICcicLsolationListRepository repository) : base(repository)
    {
        _repository = repository;
    }



    protected override async Task<CcicLsolationList> GetEntityByIdAsync(CcicLsolationListKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicLsolationList> ApplyDefaultSorting(IQueryable<CcicLsolationList> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicLsolationList>> CreateFilteredQueryAsync(CcicLsolationListGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
