using System;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;
using Volo.Abp.Application.Services;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;


/// <summary>
/// 折效客户机构分布情况
/// </summary>
public interface IConvertedCusOrgUnitAppService :
    ICrudAppService< 
                ConvertedCusOrgUnitDto, 
        Guid, 
        ConvertedCusOrgUnitGetListInput,
        CreateUpdateConvertedCusOrgUnitDto,
        CreateUpdateConvertedCusOrgUnitDto>
{

}