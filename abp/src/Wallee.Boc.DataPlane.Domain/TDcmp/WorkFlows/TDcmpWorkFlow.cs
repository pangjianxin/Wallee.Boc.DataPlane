using System;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Wallee.Boc.DataPlane.TDcmp.WorkFlows.Events;

namespace Wallee.Boc.DataPlane.TDcmp.WorkFlows
{
    /// <summary>
    /// 信息管理平台工作流
    /// </summary>
    public class TDcmpWorkFlow : AuditedAggregateRoot<Guid>
    {
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        protected TDcmpWorkFlow()
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {
        }
        public TDcmpWorkFlow(Guid id, DateTime dataDate, string cronExpression) : base(id)
        {
            DataDate = dataDate;
            CronExpression = cronExpression;
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
        /// 每日执行的Cron表达式
        /// </summary>
        public string CronExpression { get; private set; }
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
                return Enum.GetValues<TDcmpStatus>().Count();
            }
        }
        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="status"></param>
        public void SetStatus(TDcmpStatus status)
        {
            Status = status;
            CompletedCount++;

            if (Status == TDcmpStatus.已完成)
            {
                AddDistributedEvent(new TDcmpWorkFlowCompletedEto
                {
                    DataDate = DataDate,
                    CronExpression = CronExpression
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
