using AutoFilterer.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAntiMoneyLaunderings;


/// <summary>
/// 对公反洗钱信息    a02
/// </summary>
public class CcicAntiMoneyLaunderingAppService : AbstractKeyReadOnlyAppService<CcicAntiMoneyLaundering, CcicAntiMoneyLaunderingDto, CcicAntiMoneyLaunderingKey, CcicAntiMoneyLaunderingGetListInput>,
    ICcicAntiMoneyLaunderingAppService
{

    private readonly ICcicAntiMoneyLaunderingRepository _repository;

    public CcicAntiMoneyLaunderingAppService(ICcicAntiMoneyLaunderingRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicAntiMoneyLaundering> GetEntityByIdAsync(CcicAntiMoneyLaunderingKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.AML_INF_SN == id.AML_INF_SN &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicAntiMoneyLaundering> ApplyDefaultSorting(IQueryable<CcicAntiMoneyLaundering> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicAntiMoneyLaundering>> CreateFilteredQueryAsync(CcicAntiMoneyLaunderingGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
