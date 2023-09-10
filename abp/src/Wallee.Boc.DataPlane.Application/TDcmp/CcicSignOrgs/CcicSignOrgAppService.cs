using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.TDcmp.CcicSignOrgs;


/// <summary>
/// 对公重要标志信息-组织    a35
/// </summary>
public class CcicSignOrgAppService : AbstractKeyReadOnlyAppService<CcicSignOrg, CcicSignOrgDto, CcicSignOrgKey, CcicSignOrgGetListInput>,
    ICcicSignOrgAppService
{
    

    private readonly ICcicSignOrgRepository _repository;

    public CcicSignOrgAppService(ICcicSignOrgRepository repository) : base(repository)
    {
        _repository = repository;
    }

  

    protected override async Task<CcicSignOrg> GetEntityByIdAsync(CcicSignOrgKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicSignOrg> ApplyDefaultSorting(IQueryable<CcicSignOrg> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicSignOrg>> CreateFilteredQueryAsync(CcicSignOrgGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
