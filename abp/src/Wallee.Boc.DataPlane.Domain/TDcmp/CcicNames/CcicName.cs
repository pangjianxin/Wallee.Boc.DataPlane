using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.TDcmp.CcicNames
{
    /// <summary>
    /// 对公名称信息
    /// a22
    /// </summary>
    public class CcicName : BasicAggregateRoot
    {
        /// <summary>
        /// 客户号
        /// 字符型(10)
        /// </summary>
        public string CUSNO { get; set; } = default!;

        /// <summary>
        /// 客户名称语种
        /// 字符型(2)
        /// </summary>
        public string CUS_NAME_LANG { get; set; } = default!;

        /// <summary>
        /// 法人编码
        /// 字符型(3)
        /// </summary>
        public string LGPER_CODE { get; set; } = default!;

        /// <summary>
        /// 客户名称
        /// 字符型(500)
        /// </summary>
        public string? CUS_NAME { get; set; }

        /// <summary>
        /// 客户名称起始日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_NAME_START_DT { get; set; }

        /// <summary>
        /// 客户名称终止日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_NAME_TMT_DT { get; set; }

        /// <summary>
        /// 客户简称
        /// 字符型(60)
        /// </summary>
        public string? CUS_SHTNM { get; set; }

        /// <summary>
        /// 客户简称起始日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_SHTNM_START_DT { get; set; }

        /// <summary>
        /// 客户简称终止日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_SHTNM_ENDDT_PERI { get; set; }

        /// <summary>
        /// 客户SWIFT名称
        /// 字符型(120)
        /// </summary>
        public string? CUS_SWIFT_NAME { get; set; }

        /// <summary>
        /// 客户SWIFT名称起始日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_SWIFT_NAME_START_DT { get; set; }

        /// <summary>
        /// 客户SWIFT名称终止日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_SWIFT_NAME_ENDDT_PERI { get; set; }

        /// <summary>
        /// 客户短名
        /// 字符型(60)
        /// </summary>
        public string? CUS_SHNM { get; set; }

        /// <summary>
        /// 客户短名起始日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_SHNM_START_DT { get; set; }

        /// <summary>
        /// 客户短名终止日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_SHNM_ENDDT_PERI { get; set; }

        /// <summary>
        /// 客户曾用名
        /// 字符型(120)
        /// </summary>
        public string? CUS_FRMNM_NAME { get; set; }

        /// <summary>
        /// 客户曾用名起始日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_FRMNM_NAME_START_DT { get; set; }

        /// <summary>
        /// 客户曾用名终止日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_FRMNM_NAME_ENDDT_PERI { get; set; }

        /// <summary>
        /// 客户其他名称类型
        /// 字符型(1)
        /// </summary>
        public string? CUS_OTHR_NAME_TP { get; set; }

        /// <summary>
        /// 客户其他名称
        /// 字符型(500)
        /// </summary>
        public string? CUS_OTHR_NAME { get; set; }

        /// <summary>
        /// 客户其他名称起始日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_OTHR_NAME_START_DT { get; set; }

        /// <summary>
        /// 客户其他名称终止日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUS_OTHR_NAME_TMT_DT { get; set; }

        /// <summary>
        /// 删除标志
        /// 字符型(1)
        /// </summary>
        public string? DEL_FLAG { get; set; }

        /// <summary>
        /// 创建人柜员编号
        /// 字符型(7)
        /// </summary>
        public string? CRTR_TLR_REFNO { get; set; }

        /// <summary>
        /// 创建柜员机构编号
        /// 字符型(5)
        /// </summary>
        public string? CRT_TLR_ORG_REFNO { get; set; }

        /// <summary>
        /// 创建日期时间
        /// 日期时间型
        /// </summary>
        public DateTime? CRT_DTTM { get; set; }

        /// <summary>
        /// 当前会计日期
        /// 日期型(8)
        /// </summary>
        public DateTime? CUR_ACDT_PERI { get; set; }

        /// <summary>
        /// 最新修改柜员编号
        /// 字符型(7)
        /// </summary>
        public string? LTST_MOD_TLR_REFNO { get; set; }

        /// <summary>
        /// 修改柜员机构编号
        /// 字符型(5)
        /// </summary>
        public string? MOD_TLR_ORG_REFNO { get; set; }
        /// <summary>
        /// 最后维护状态代码
        /// 字符型(1)
        /// </summary>
        public string? LAST_MNT_STS_CODE { get; set; }
        /// <summary>
        /// 最后修改日期时间
        /// 日期时间型
        /// </summary>
        public DateTime? LAST_MOD_DTTM { get; set; }

        /// <summary>
        /// 记录版本序号
        /// 数值型(20)
        /// </summary>
        public string? RCRD_VRSN_SN { get; set; }

        /// <summary>
        /// 记录清理状态代码
        /// 字符型(1)
        /// </summary>
        public string? RCRD_CLNUP_STSCD { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { CUSNO, CUS_NAME_LANG, LGPER_CODE };
        }

        public CcicName()
        {

        }
    }
}
