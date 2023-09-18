using System;
using Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;

namespace Wallee.Boc.DataPlane.Reports.ConvertCusOrgUnits;


/// <summary>
/// 折效客户机构分布情况
/// </summary>
public interface IConvertedCusOrgUnitAppService :
    IReadOnlyAppService<
        ConvertedCusOrgUnitDto,
        ConvertedCusOrgUnitKey,
        ConvertedCusOrgUnitGetListInput>
{
    Task CreateByFileAsync(CreateUpdateConvertedCusOrgUnitByFileDto input);
}