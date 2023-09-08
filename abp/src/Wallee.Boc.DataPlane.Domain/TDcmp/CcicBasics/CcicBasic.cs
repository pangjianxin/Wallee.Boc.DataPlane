using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.TDcmp.CcicBasics
{
    /// <summary>
    /// 对公客户基础信息
    /// a04
    /// </summary>
    public class CcicBasic : AggregateRoot
    {
        /// <summary>
        /// 客户号
        /// </summary>
        public string CUSNO { get; set; } = default!;

        /// <summary>
        /// 法人编码
        /// </summary>
        public string LGPER_CODE { get; set; } = default!;

        /// <summary>
        /// 终身编码
        /// </summary>
        public string? AL_CODE { get; set; }

        /// <summary>
        /// 通讯语言
        /// </summary>
        public string? COMM_LNG { get; set; }

        /// <summary>
        /// 客户关系建立渠道
        /// </summary>
        public string? CUSRL_TE_CHNL { get; set; }

        /// <summary>
        /// 客户经理柜员编号
        /// </summary>
        public string? CSMGR_TLR_REFNO { get; set; }

        /// <summary>
        /// 开户机构编号
        /// </summary>
        public string? OPNAC_ORG_REFNO { get; set; }

        /// <summary>
        /// 归属机构编号
        /// </summary>
        public string? BLG_ORG_REFNO { get; set; }

        /// <summary>
        /// 开户日期
        /// </summary>
        public DateTime? OPNAC_DT { get; set; }

        /// <summary>
        /// 关闭日期
        /// </summary>
        public DateTime? CLS_DT { get; set; }

        /// <summary>
        /// 最后确认日期
        /// </summary>
        public DateTime? LAST_CNMDT_PERI { get; set; }

        /// <summary>
        /// 客户状态
        /// </summary>
        public string? CSTST { get; set; }

        /// <summary>
        /// 停用原因
        /// </summary>
        public string? DSABL_REASN { get; set; }

        /// <summary>
        /// 停用原因说明
        /// </summary>
        public string? DSABL_REASN_NOTE { get; set; }

        /// <summary>
        /// 参与方角色类型代码
        /// </summary>
        public string? PART_RL_TP_CODE { get; set; }

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
        public DateTime CRT_DTTM { get; set; }

        /// <summary>
        /// 当前会计日期
        /// </summary>
        public DateTime CUR_ACDT_PERI { get; set; }

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
        public DateTime LAST_MOD_DTTM { get; set; }

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
            return new object[] {
                CUSNO,LGPER_CODE
            };
        }

#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        public CcicBasic()
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
        {
        }

        //public CcicBasic(string cUSNO, string lGPER_CODE, string? aL_CODE,
        //    string? cOMM_LNG, string? cUSRL_TE_CHNL, string? cSMGR_TLR_REFNO,
        //    string? oPNAC_ORG_REFNO, string? bLG_ORG_REFNO, string? oPNAC_DT,
        //    string? cLS_DT, string lAST_CNMDT_PERI, string? cSTST,
        //    string? dSABL_REASN, string? dSABL_REASN_NOTE,
        //    string? pART_RL_TP_CODE, string? dEL_FLAG, string? cRTR_TLR_REFNO,
        //    string? cRT_TLR_ORG_REFNO, DateTime cRT_DTTM, DateTime cUR_ACDT_PERI,
        //    string? lTST_MOD_TLR_REFNO,
        //    string? mOD_TLR_ORG_REFNO, string? lAST_MNT_STS_CODE,
        //    DateTime lAST_MOD_DTTM, string? rCRD_VRSN_SN,
        //    string? rCRD_CLNUP_STSCD)
        //{
        //    CUSNO = cUSNO;
        //    LGPER_CODE = lGPER_CODE;
        //    AL_CODE = aL_CODE;
        //    COMM_LNG = cOMM_LNG;
        //    CUSRL_TE_CHNL = cUSRL_TE_CHNL;
        //    CSMGR_TLR_REFNO = cSMGR_TLR_REFNO;
        //    OPNAC_ORG_REFNO = oPNAC_ORG_REFNO;
        //    BLG_ORG_REFNO = bLG_ORG_REFNO;
        //    OPNAC_DT = oPNAC_DT;
        //    CLS_DT = cLS_DT;
        //    LAST_CNMDT_PERI = lAST_CNMDT_PERI;
        //    CSTST = cSTST;
        //    DSABL_REASN = dSABL_REASN;
        //    DSABL_REASN_NOTE = dSABL_REASN_NOTE;
        //    PART_RL_TP_CODE = pART_RL_TP_CODE;
        //    DEL_FLAG = dEL_FLAG;
        //    CRTR_TLR_REFNO = cRTR_TLR_REFNO;
        //    CRT_TLR_ORG_REFNO = cRT_TLR_ORG_REFNO;
        //    CRT_DTTM = cRT_DTTM;
        //    CUR_ACDT_PERI = cUR_ACDT_PERI;
        //    LTST_MOD_TLR_REFNO = lTST_MOD_TLR_REFNO;
        //    MOD_TLR_ORG_REFNO = mOD_TLR_ORG_REFNO;
        //    LAST_MNT_STS_CODE = lAST_MNT_STS_CODE;
        //    LAST_MOD_DTTM = lAST_MOD_DTTM;
        //    RCRD_VRSN_SN = rCRD_VRSN_SN;
        //    RCRD_CLNUP_STSCD = rCRD_CLNUP_STSCD;
        //}
    }
}
