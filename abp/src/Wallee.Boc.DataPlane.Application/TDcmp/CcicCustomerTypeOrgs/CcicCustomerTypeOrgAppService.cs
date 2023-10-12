using AutoFilterer.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.CcicCustomerTypeOrgs;


/// <summary>
/// 对公客户类别信息-组织    a09
/// </summary>
public class CcicCustomerTypeOrgAppService : AbstractKeyReadOnlyAppService<CcicCustomerTypeOrg, CcicCustomerTypeOrgDto, CcicCustomerTypeOrgKey, CcicCustomerTypeOrgGetListInput>,
    ICcicCustomerTypeOrgAppService
{
    private readonly ICcicCustomerTypeOrgRepository _repository;

    public CcicCustomerTypeOrgAppService(ICcicCustomerTypeOrgRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<CcicCustomerTypeOrg> GetEntityByIdAsync(CcicCustomerTypeOrgKey id)
    {
        // TODO: AbpHelper generated
        return (await AsyncExecuter.FirstOrDefaultAsync(
            (await _repository.WithDetailsAsync()).Where(e =>
                e.CUSNO == id.CUSNO &&
                e.LGPER_CODE == id.LGPER_CODE
            )))!;
    }

    protected override IQueryable<CcicCustomerTypeOrg> ApplyDefaultSorting(IQueryable<CcicCustomerTypeOrg> query)
    {
        // TODO: AbpHelper generated
        return query.OrderBy(e => e.CUSNO);
    }

    protected override async Task<IQueryable<CcicCustomerTypeOrg>> CreateFilteredQueryAsync(CcicCustomerTypeOrgGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
