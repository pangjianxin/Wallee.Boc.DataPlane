using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Domain.Repositories;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Dtos;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows;


/// <summary>
/// 信息管理平台工作流
/// </summary>
public class TDcmpWorkFlowAppService : CrudAppService<TDcmpWorkFlow, TDcmpWorkFlowDto, Guid, TDcmpWorkFlowGetListInput, CreateUpdateTDcmpWorkFlowDto, CreateUpdateTDcmpWorkFlowDto>,
    ITDcmpWorkFlowAppService
{

    private readonly ITDcmpWorkFlowRepository _repository;
    private readonly IBackgroundJobManager _backgroundJobManager;
    private readonly TDcmpWorkFlowManager _tDcmpWorkFlowManager;

    public TDcmpWorkFlowAppService(
        ITDcmpWorkFlowRepository repository,
        IBackgroundJobManager backgroundJobManager,
        TDcmpWorkFlowManager tDcmpWorkFlowManager) : base(repository)
    {
        _repository = repository;
        _backgroundJobManager = backgroundJobManager;
        _tDcmpWorkFlowManager = tDcmpWorkFlowManager;
    }

    public override async Task<TDcmpWorkFlowDto> CreateAsync(CreateUpdateTDcmpWorkFlowDto input)
    {
        return await MapToGetOutputDtoAsync(await _tDcmpWorkFlowManager.CreateAsync(input.DataDate));
    }

    protected override async Task<IQueryable<TDcmpWorkFlow>> CreateFilteredQueryAsync(TDcmpWorkFlowGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.Status != null, x => x.Status == input.Status)
            .WhereIf(input.DataDate != null, x => x.DataDate == input.DataDate)
            .WhereIf(input.Comment != null, x => x.Comment == input.Comment)
            ;
    }
}
