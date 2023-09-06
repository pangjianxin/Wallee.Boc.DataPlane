using System;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows;


/// <summary>
/// 信息管理平台工作流
/// </summary>
public interface ITDcmpWorkFlowAppService :
    ICrudAppService<
                TDcmpWorkFlowDto,
        Guid,
        TDcmpWorkFlowGetListInput,
        CreateUpdateTDcmpWorkFlowDto,
        CreateUpdateTDcmpWorkFlowDto>
{
    Task<ExecutingTDcmpWorkFlowDto?> GetExecutingAsync();
}