using AutoFilterer.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs;


/// <summary>
/// 对公概况-组织    a18
/// </summary>
public class CcicGeneralOrgAppService : AbstractKeyReadOnlyAppService<CcicGeneralOrg, CcicGeneralOrgDto, CcicGeneralOrgKey, CcicGeneralOrgGetListInput>,
    ICcicGeneralOrgAppService
{
    private readonly ICcicGeneralOrgRepository _repository;

    public CcicGeneralOrgAppService(ICcicGeneralOrgRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicGeneralOrg> GetEntityByIdAsync(CcicGeneralOrgKey id)
    {
        // TODO: AbpHelper generated
        return await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            ));
    }

    protected override IQueryable<CcicGeneralOrg> ApplyDefaultSorting(IQueryable<CcicGeneralOrg> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicGeneralOrg>> CreateFilteredQueryAsync(CcicGeneralOrgGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
