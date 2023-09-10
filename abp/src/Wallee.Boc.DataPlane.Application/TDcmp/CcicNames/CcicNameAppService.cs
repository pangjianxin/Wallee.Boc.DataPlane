using AutoFilterer.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicNames.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames;


/// <summary>
/// 对公名称信息    a22
/// </summary>
public class CcicNameAppService : AbstractKeyReadOnlyAppService<CcicName, CcicNameDto, CcicNameKey, CcicNameGetListInput>,
    ICcicNameAppService
{


    private readonly ICcicNameRepository _repository;

    public CcicNameAppService(ICcicNameRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicName> GetEntityByIdAsync(CcicNameKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.CUS_NAME_LANG == id.CUS_NAME_LANG &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicName> ApplyDefaultSorting(IQueryable<CcicName> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicName>> CreateFilteredQueryAsync(CcicNameGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
