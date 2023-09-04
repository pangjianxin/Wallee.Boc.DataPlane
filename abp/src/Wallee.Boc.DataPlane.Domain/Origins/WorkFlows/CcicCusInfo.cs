using System;
using Volo.Abp.Domain.Entities.Auditing;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.Origins.WorkFlows
{
    /// <summary>
    /// 对公客户信息装载工作流
    /// </summary>
    public class CcicCusInfo : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 状态
        /// </summary>
        public CcicCusInfoStatus Status { get; private set; }
        /// <summary>
        /// 数据日期
        /// </summary>
        public DateTime DataDate { get; private set; }
        public void SetStatus(CcicCusInfoStatus status)
        {
            Status = status;
        }
    }
}
