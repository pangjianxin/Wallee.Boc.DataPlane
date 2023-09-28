using System;
using Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;

namespace Wallee.Boc.DataPlane.Reports.Pa.ConvertedCuses;


/// <summary>
/// 客户机构调整
/// </summary>
public interface ICusOrgAdjusmentAppService :
    IReadOnlyAppService<
        CusOrgAdjusmentDto,
        CusOrgAdjusmentKey,
        CusOrgAdjusmentGetListInput>
{
    Task CreateByFileAsync(CreateUpdateCusOrgAdjusmentByFileDto input);
}