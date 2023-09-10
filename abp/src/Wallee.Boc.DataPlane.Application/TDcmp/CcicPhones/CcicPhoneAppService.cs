using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicPhones.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicPhones;


/// <summary>
/// 对公名称信息    a22
/// </summary>
public class CcicPhoneAppService : AbstractKeyReadOnlyAppService<CcicPhone, CcicPhoneDto, CcicPhoneKey, CcicPhoneGetListInput>,
    ICcicPhoneAppService
{


    private readonly ICcicPhoneRepository _repository;

    public CcicPhoneAppService(ICcicPhoneRepository repository) : base(repository)
    {
        _repository = repository;
    }



    protected override async Task<CcicPhone> GetEntityByIdAsync(CcicPhoneKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.UNIT_TEL_TP == id.UNIT_TEL_TP &&
                e.CNTEL_SN == id.CNTEL_SN &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicPhone> ApplyDefaultSorting(IQueryable<CcicPhone> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicPhone>> CreateFilteredQueryAsync(CcicPhoneGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .ApplyFilter(input);
    }
}
