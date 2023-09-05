using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows;

/// <summary>
/// 信息管理平台工作流
/// </summary>
public interface ITDcmpWorkFlowRepository : IRepository<TDcmpWorkFlow, Guid>
{
}
