using System;
using Volo.Abp.Domain.Entities.Auditing;
using Wallee.Boc.DataPlane.WorkFlows;

namespace Wallee.Boc.DataPlane.Origins.WorkFlows
{
    /// <summary>
    /// 信息管理平台工作流
    /// </summary>
    public class TDcmp : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 状态
        /// </summary>
        public TDcmpStatus Status { get; private set; }
        /// <summary>
        /// 数据日期
        /// </summary>
        public DateTime DataDate { get; private set; }
        public void SetStatus(TDcmpStatus status)
        {
            Status = status;
        }
    }
}
