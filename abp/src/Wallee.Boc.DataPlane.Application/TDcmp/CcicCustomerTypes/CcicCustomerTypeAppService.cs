using AutoFilterer.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypes;


/// <summary>
/// 对公客户类别信息    a08
/// </summary>
public class CcicCustomerTypeAppService : AbstractKeyReadOnlyAppService<CcicCustomerType, CcicCustomerTypeDto, CcicCustomerTypeKey, CcicCustomerTypeGetListInput>,
    ICcicCustomerTypeAppService
{
    private readonly ICcicCustomerTypeRepository _repository;

    public CcicCustomerTypeAppService(ICcicCustomerTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicCustomerType> GetEntityByIdAsync(CcicCustomerTypeKey id)
    {
        // TODO: AbpHelper generated
        return (await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            )))!;
    }

    protected override IQueryable<CcicCustomerType> ApplyDefaultSorting(IQueryable<CcicCustomerType> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicCustomerType>> CreateFilteredQueryAsync(CcicCustomerTypeGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
