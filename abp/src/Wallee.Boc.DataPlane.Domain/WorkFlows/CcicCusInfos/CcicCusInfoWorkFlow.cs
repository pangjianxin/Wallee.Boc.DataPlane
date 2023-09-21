using System;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos.Events;

namespace Wallee.Boc.DataPlane.WorkFlows.CcicCusInfos
{
    /// <summary>
    /// 信息管理平台工作流
    /// </summary>
    public class CcicCusInfoWorkFlow : AuditedAggregateRoot<Guid>
    {
        protected CcicCusInfoWorkFlow()
        {
        }
        public CcicCusInfoWorkFlow(Guid id, DateTime dataDate) : base(id)
        {
            DataDate = dataDate;
            Status = CcicCusInfoWorkFlowStatus.初始化;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public CcicCusInfoWorkFlowStatus Status { get; private set; }
        /// <summary>
        /// 数据日期
        /// </summary>
        public DateTime DataDate { get; private set; }
        /// <summary>
        /// 备注(有可能会记录异常的堆栈信息)
        /// </summary>
        public string? Comment { get; private set; }
        /// <summary>
        /// 已完成的任务数
        /// </summary>
        public int CompletedCount { get; private set; }
        /// <summary>
        /// 任务总数
        /// </summary>
        public int TotalTaskCount
        {
            get
            {
                return Enum.GetValues<CcicCusInfoWorkFlowStatus>().Count();
            }
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(CcicCusInfoWorkFlowStatus status)
        {
            Status = status;
            CompletedCount++;

            if (Status == CcicCusInfoWorkFlowStatus.已完成)
            {
                AddDistributedEvent(new CcicCusInfoWorkFlowCompletedEto
                {
                    DataDate = DataDate,
                });
            }
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
