using System;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Dtos;

namespace Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;


/// <summary>
/// 信息管理平台工作流
/// </summary>
public interface ICcicCusInfoWorkFlowAppService :
    ICrudAppService<
                CcicCusInfoWorkFlowDto,
        Guid,
        CcicCusInfoWorkFlowGetListInput,
        CreateUpdateCcicCusInfoWorkFlowDto,
        CreateUpdateCcicCusInfoWorkFlowDto>
{
    Task<ExecutingCcicCusInfoWorkFlowDto?> GetExecutingAsync();
}