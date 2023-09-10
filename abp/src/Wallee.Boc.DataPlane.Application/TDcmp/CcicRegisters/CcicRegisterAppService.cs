using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicRegisters.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicRegisters;


/// <summary>
/// 对公注册信息    a28
/// </summary>
public class CcicRegisterAppService : AbstractKeyReadOnlyAppService<CcicRegister, CcicRegisterDto, CcicRegisterKey, CcicRegisterGetListInput>,
    ICcicRegisterAppService
{


    private readonly ICcicRegisterRepository _repository;

    public CcicRegisterAppService(ICcicRegisterRepository repository) : base(repository)
    {
        _repository = repository;
    }



    protected override async Task<CcicRegister> GetEntityByIdAsync(CcicRegisterKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicRegister> ApplyDefaultSorting(IQueryable<CcicRegister> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicRegister>> CreateFilteredQueryAsync(CcicRegisterGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
          .ApplyFilter(input);
    }
}
