using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows
{
    /// <summary>
    /// 信息管理平台工作流
    /// </summary>
    public class TDcmpWorkFlow : AuditedAggregateRoot<Guid>
    {
        protected TDcmpWorkFlow()
        {
        }
        public TDcmpWorkFlow(Guid id, DateTime dataDate) : base(id)
        {
            DataDate = dataDate;
            Status = TDcmpStatus.初始化;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public TDcmpStatus Status { get; private set; }
        /// <summary>
        /// 数据日期
        /// </summary>
        public DateTime DataDate { get; private set; }
        /// <summary>
        /// 备注(有可能会记录异常的堆栈信息)
        /// </summary>
        public string? Comment { get; private set; }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(TDcmpStatus status)
        {
            Status = status;
        }
        /// <summary>
        /// 设置备注/异常信息
        /// </summary>
        /// <param name="comment"></param>
        public void SetComment(string comment)
        {
            Comment = comment;
        }
    }
}
