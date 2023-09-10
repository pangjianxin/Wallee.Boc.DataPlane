using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.TDcmp.CcicGeneralOrgs
{
    /// <summary>
    /// 对公概况-组织
    /// a18
    /// </summary>
    public class CcicGeneralOrg : BasicAggregateRoot
    {
        /// <summary>
        ///  客户号. (字符型(10))
        /// </summary>
        public string CUSNO { get; set; } = default!;

        /// <summary>
        ///  法人编码. (字符型(3))
        /// </summary>
        public string LGPER_CODE { get; set; } = default!;

        /// <summary>
        ///  享受当地政府优惠政策类型. (字符型(1))
        /// </summary>
        public string? ENJ_LCL_GOVT_PRFT_PC_TP { get; set; }

        /// <summary>
        ///  财政补助收入来源. (字符型(1))
        /// </summary>
        public string? FNC_SUBS_INCM_SRC { get; set; }

        /// <summary>
        ///  资金来源信息. (字符型(500))
        /// </summary>
        public string? FNDS_SRC_INF { get; set; }

        /// <summary>
        ///  财富来源(海外). (字符型(1))
        /// </summary>
        public string? WLTH_SRC_OVSEA { get; set; }

        /// <summary>
        ///  财富来源为其他时说明. (字符型(300))
        /// </summary>
        public string? WLTH_SRC_IS_OTHR_HOUR_NOTE { get; set; }

        /// <summary>
        ///  财富来源国家/地区. (字符型(3))
        /// </summary>
        public string? WLTH_SRC_CNRG { get; set; }

        /// <summary>
        ///  企业介绍. (字符型(500))
        /// </summary>
        public string? ENTP_INTD { get; set; }

        /// <summary>
        ///  LOGO影像文件ID. (字符型(10))
        /// </summary>
        public string? LOGO_IMAGE_FILE_ID { get; set; }
        /// <summary>
        ///  LOGO名称. (字符型(100))
        /// </summary>
        public string? LOGO_NAME { get; set; }

        /// <summary>
        ///  公司章程附件ID. (字符型(10))
        /// </summary>
        public string? CO_TAOA_ATTCH_ID { get; set; }

        /// <summary>
        ///  在我行股本占比. (数值型(6,2))
        /// </summary>
        public decimal? EXST_OURBK_EQU_PCT { get; set; }

        /// <summary>
        ///  基本存款账号. (字符型(25))
        /// </summary>
        public string? BSC_DEP_ACCNO { get; set; }

        /// <summary>
        ///  基本存款账户开户许可证核准号. (字符型(14))
        /// </summary>
        public string? BSC_DEP_ACC_ACOP_APVL_NO { get; set; }

        /// <summary>
        ///  基本存款账户开户行名称. (字符型(120))
        /// </summary>
        public string? BSC_DEP_ACC_DEPBK_NAME { get; set; }

        /// <summary>
        ///  基本存款账户开户日期. (日期型(8))
        /// </summary>
        public DateTime? BSC_DEP_ACC_OPNAC_DT { get; set; }

        /// <summary>
        ///  企业发展战略. (字符型(500))
        /// </summary>
        public string? ENTP_DEVE_STRTG { get; set; }

        /// <summary>
        ///  删除标志. (字符型(1))
        /// </summary>
        public string? DEL_FLAG { get; set; }

        /// <summary>
        ///  创建人柜员编号. (字符型(7))
        /// </summary>
        public string? CRTR_TLR_REFNO { get; set; }
        /// <summary>
        ///  创建柜员机构编号. (字符型(5))
        /// </summary>
        public string? CRT_TLR_ORG_REFNO { get; set; }

        /// <summary>
        ///  创建日期时间. (日期时间型)
        /// </summary>
        public DateTime? CRT_DTTM { get; set; }

        /// <summary>
        ///  当前会计日期. (日期型(8))
        /// </summary>
        public DateTime? CUR_ACDT_PERI { get; set; }

        /// <summary>
        ///  最新修改柜员编号. (字符型(7))
        /// </summary>
        public string? LTST_MOD_TLR_REFNO { get; set; }

        /// <summary>
        ///  修改柜员机构编号. (字符型(5))
        /// </summary>
        public string? MOD_TLR_ORG_REFNO { get; set; }

        /// <summary>
        ///  最后维护状态代码. (字符型(1))
        /// </summary>
        public string? LAST_MNT_STS_CODE { get; set; }

        /// <summary>
        ///  最后修改日期时间. (日期时间型)
        /// </summary>
        public DateTime? LAST_MOD_DTTM { get; set; }

        /// <summary>
        ///  记录版本序号. (数值型(20))
        /// </summary>
        public decimal? RCRD_VRSN_SN { get; set; }

        /// <summary>
        ///  记录清理状态代码. (字符型(1))
        /// </summary>
        public string? RCRD_CLNUP_STSCD { get; set; }
        public CcicGeneralOrg()
        {
            
        }
        public override object[] GetKeys()
        {
            return new object[] { CUSNO, LGPER_CODE };
        }

    
    }
}
