using System;
using Volo.Abp.Domain.Repositories;

namespace Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos;

/// <summary>
/// 信息管理平台工作流
/// </summary>
public interface ICcicCusInfoWorkFlowRepository : IRepository<CcicCusInfoWorkFlow, Guid>
{
}
