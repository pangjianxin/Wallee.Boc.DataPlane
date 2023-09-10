using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses
{
    /// <summary>
    /// 对公地址信息
    /// a00
    /// </summary>
    public class CcicAddress : BasicAggregateRoot
    {
        /// <summary>
        /// 客户号
        /// </summary>
        public string CUSNO { get; set; }

        /// <summary>
        /// 地址类型
        /// </summary>
        public string ADDR_TP { get; set; }

        /// <summary>
        /// 地址序号
        /// </summary>
        public int ADDR_SN { get; set; }

        /// <summary>
        /// 法人编码
        /// </summary>
        public string LGPER_CODE { get; set; }

        /// <summary>
        /// 地址语种
        /// </summary>
        public string? ADDR_LANG { get; set; }

        /// <summary>
        /// 国家/地区
        /// </summary>
        public string? CNRG { get; set; }

        /// <summary>
        /// 省份/直辖市
        /// </summary>
        public string? PRVC_MNCP { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string? CITY { get; set; }

        /// <summary>
        /// 县/区
        /// </summary>
        public string? CNTY { get; set; }

        /// <summary>
        /// 地址(详细地址)
        /// </summary>
        public string? ADDR1 { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string? PSALC { get; set; }

        /// <summary>
        /// 退件标志
        /// </summary>
        public string? RTNPT_FLAG { get; set; }

        /// <summary>
        /// 位置名称
        /// </summary>
        public string? PS_NAME { get; set; }

        /// <summary>
        /// 国家语言代码
        /// </summary>
        public string? CTY_LNG_CODE { get; set; }

        /// <summary>
        /// 国家地区风险等级代码
        /// </summary>
        public string? CTY_RGON_RSK_GRD_CODE { get; set; }

        /// <summary>
        /// 关联银联城市代码
        /// </summary>
        public string? RLTV_UNNPY_URBN_CODE { get; set; }

        /// <summary>
        /// 银行卡城市代码
        /// </summary>
        public string? BKCD_URBN_CODE { get; set; }

        /// <summary>
        /// 关系类型代码
        /// </summary>
        public string? REL_TP_CODE { get; set; }

        /// <summary>
        /// 关系开始日期
        /// </summary>
        public DateTime? REL_STRT_DT { get; set; }

        /// <summary>
        /// 关系结束日期
        /// </summary>
        public DateTime? REL_END_DT { get; set; }

        /// <summary>
        /// 关系开始时间
        /// </summary>
        public TimeSpan? REL_STRT_TIME { get; set; }

        /// <summary>
        /// 关系结束时间
        /// </summary>
        public TimeSpan? REL_END_TIME { get; set; }

        /// <summary>
        /// 关系描述
        /// </summary>
        public string? REL_DES { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public string? DEL_FLAG { get; set; }

        /// <summary>
        /// 创建人柜员编号
        /// </summary>
        public string? CRTR_TLR_REFNO { get; set; }

        /// <summary>
        /// 创建柜员机构编号
        /// </summary>
        public string? CRT_TLR_ORG_REFNO { get; set; }

        /// <summary>
        /// 创建日期时间
        /// </summary>
        public DateTime? CRT_DTTM { get; set; }

        /// <summary>
        /// 当前会计日期
        /// </summary>
        public DateTime? CUR_ACDT_PERI { get; set; }

        /// <summary>
        /// 最新修改柜员编号
        /// </summary>
        public string? LTST_MOD_TLR_REFNO { get; set; }

        /// <summary>
        /// 修改柜员机构编号
        /// </summary>
        public string? MOD_TLR_ORG_REFNO { get; set; }

        /// <summary>
        /// 最后维护状态代码
        /// </summary>
        public string? LAST_MNT_STS_CODE { get; set; }

        /// <summary>
        /// 最后修改日期时间
        /// </summary>
        public DateTime? LAST_MOD_DTTM { get; set; }

        /// <summary>
        /// 记录版本序号
        /// </summary>
        public string? RCRD_VRSN_SN { get; set; }

        /// <summary>
        /// 记录清理状态代码
        /// </summary>
        public string? RCRD_CLNUP_STSCD { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { CUSNO, ADDR_TP, ADDR_SN, LGPER_CODE };
        }
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public CcicAddress()
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {
        }
    }
}
