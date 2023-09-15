using System;
using System.Linq;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.Permissions;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;
using Volo.Abp.Application.Services;
using AutoFilterer.Extensions;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;


/// <summary>
/// 折效客户机构分布情况
/// </summary>
public class ConvertedCusOrgUnitAppService : CrudAppService<ConvertedCusOrgUnit, ConvertedCusOrgUnitDto, Guid, ConvertedCusOrgUnitGetListInput, CreateUpdateConvertedCusOrgUnitDto, CreateUpdateConvertedCusOrgUnitDto>,
    IConvertedCusOrgUnitAppService
{
    protected override string GetPolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Default;
    protected override string GetListPolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Default;
    protected override string CreatePolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Create;
    protected override string UpdatePolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Update;
    protected override string DeletePolicyName { get; set; } = DataPlanePermissions.ConvertedCusOrgUnit.Delete;

    private readonly IConvertedCusOrgUnitRepository _repository;

    public ConvertedCusOrgUnitAppService(IConvertedCusOrgUnitRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<ConvertedCusOrgUnit>> CreateFilteredQueryAsync(ConvertedCusOrgUnitGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input)).ApplyFilter(input);
    }
}
