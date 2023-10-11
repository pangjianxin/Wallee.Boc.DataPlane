using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Domain.Repositories;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Dtos;

namespace Wallee.Boc.DataPlane.WorkFlows;


/// <summary>
/// 信息管理平台工作流
/// </summary>
public class CcicCusInfoWorkFlowAppService : CrudAppService<CcicCusInfoWorkFlow, CcicCusInfoWorkFlowDto, Guid, CcicCusInfoWorkFlowGetListInput, CreateUpdateCcicCusInfoWorkFlowDto, CreateUpdateCcicCusInfoWorkFlowDto>,
    ICcicCusInfoWorkFlowAppService
{

    private readonly ICcicCusInfoWorkFlowRepository _repository;
    private readonly IBackgroundJobManager _backgroundJobManager;
    private readonly CcicCusInfoWorkFlowManager _ccicCusInfoWorkFlowManager;

    public CcicCusInfoWorkFlowAppService(
        ICcicCusInfoWorkFlowRepository repository,
        IBackgroundJobManager backgroundJobManager,
        CcicCusInfoWorkFlowManager tDcmpWorkFlowManager) : base(repository)
    {
        _repository = repository;
        _backgroundJobManager = backgroundJobManager;
        _ccicCusInfoWorkFlowManager = tDcmpWorkFlowManager;
    }

    public override async Task<CcicCusInfoWorkFlowDto> CreateAsync(CreateUpdateCcicCusInfoWorkFlowDto input)
    {
        var workFlow = await _ccicCusInfoWorkFlowManager.CreateAsync(input.DataDate);

        return await MapToGetOutputDtoAsync(workFlow);
    }

    public async Task<ExecutingCcicCusInfoWorkFlowDto?> GetExecutingAsync()
    {
        var workFlow = await _repository.FirstOrDefaultAsync(it => it.Status != CcicCusInfoWorkFlowStatus.已完成);

        if (workFlow == default)
        {
            workFlow = await AsyncExecuter.FirstOrDefaultAsync((await _repository.GetQueryableAsync()).OrderByDescending(it => it.DataDate));
        }
        return new ExecutingCcicCusInfoWorkFlowDto
        {
            Dto = await MapToGetOutputDtoAsync(workFlow!),
            DotGraph = await _ccicCusInfoWorkFlowManager.GetDotGraphAsync(workFlow!)
        };

    }

    protected override async Task<IQueryable<CcicCusInfoWorkFlow>> CreateFilteredQueryAsync(CcicCusInfoWorkFlowGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.Status != null, x => x.Status == input.Status)
            .WhereIf(input.DataDate != null, x => x.DataDate.Date == input.DataDate.GetValueOrDefault().Date)
            .WhereIf(input.Comment != null, x => x.Comment!.Contains(input.Comment!));
    }
}
