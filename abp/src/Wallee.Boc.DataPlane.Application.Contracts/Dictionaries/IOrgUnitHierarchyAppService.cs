using System;
using Wallee.Boc.DataPlane.Dictionaries.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Wallee.Boc.DataPlane.Dictionaries;


/// <summary>
/// 机构层级表
/// </summary>
public interface IOrgUnitHierarchyAppService :
    ICrudAppService<
                OrgUnitHierarchyDto,
        Guid,
        OrgUnitHierarchyGetListInput,
        CreateOrgUnitHierarchyDto,
        UpdateOrgUnitHierarchyDto>
{
    Task<List<OrgUnitHierarchyDto>> GetAllAsync();
    Task<OrgUnitHierarchyDto> MoveAsync(Guid id, MoveOrgUnitHierarchyDto input);
}