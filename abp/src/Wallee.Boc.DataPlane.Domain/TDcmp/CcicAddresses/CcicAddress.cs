using System;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.TDcmp.CcicAddresses
{
    /// <summary>
    /// 对公地址信息
    /// </summary>
    public class CcicAddress : AggregateRoot
    {
        public string CUSNO { get; set; } = default!; // 客户号
        public string ADDR_TP { get; set; } = default!;// 地址类型
        public int ADDR_SN { get; set; } // 地址序号
        public string LGPER_CODE { get; set; } = default!; // 法人编码
        public string ADDR_LANG { get; set; } = default!; // 地址语种
        public string CNRG { get; set; } = default!; // 国家/地区
        public string PRVC_MNCP { get; set; } = default!; // 省份/直辖市
        public string CITY { get; set; } = default!;    // 市
        public string CNTY { get; set; } = default!; // 县/区
        public string ADDR1 { get; set; } = default!; // 地址(详细地址)
        public string PSALC { get; set; } = default!; // 邮编
        public string RTNPT_FLAG { get; set; } = default!; // 退件标志
        public string PS_NAME { get; set; } = default!; // 位置名称
        public string CTY_LNG_CODE { get; set; } = default!; // 国家语言代码
        public string CTY_RGON_RSK_GRD_CODE { get; set; } = default!; // 国家地区风险等级代码
        public string RLTV_UNNPY_URBN_CODE { get; set; } = default!; // 关联银联城市代码
        public string BKCD_URBN_CODE { get; set; } = default!; // 银行卡城市代码
        public string REL_TP_CODE { get; set; } = default!; // 关系类型代码
        public DateTime REL_STRT_DT { get; set; } // 关系开始日期
        public DateTime REL_END_DT { get; set; } // 关系结束日期
        public DateTime REL_STRT_TIME { get; set; } // 关系开始时间
        public DateTime REL_END_TIME { get; set; } // 关系结束时间
        public string REL_DES { get; set; } = default!; // 关系描述
        public string DEL_FLAG { get; set; } = default!; // 删除标志
        public string CRTR_TLR_REFNO { get; set; } = default!; // 创建人柜员编号
        public string CRT_TLR_ORG_REFNO { get; set; } = default!; // 创建柜员机构编号
        public DateTime CRT_DTTM { get; set; } // 创建日期时间
        public DateTime CUR_ACDT_PERI { get; set; } // 当前会计日期
        public string LTST_MOD_TLR_REFNO { get; set; } = default!; // 最新修改柜员编号
        public string MOD_TLR_ORG_REFNO { get; set; } = default!; // 修改柜员机构编号
        public string LAST_MNT_STS_CODE { get; set; } = default!; // 最后维护状态代码
        public DateTime LAST_MOD_DTTM { get; set; } // 最后修改日期时间
        public long RCRD_VRSN_SN { get; set; } // 记录版本序号

        public override object[] GetKeys()
        {
            return new object[] { CUSNO, LGPER_CODE };
        }

        protected CcicAddress()
        {
        }

        public CcicAddress(
            string cUSNO,
            string aDDR_TP,
            int aDDR_SN,
            string lGPER_CODE,
            string aDDR_LANG,
            string cNRG,
            string pRVC_MNCP,
            string cITY,
            string cNTY,
            string aDDR1,
            string pSALC,
            string rTNPT_FLAG,
            string pS_NAME,
            string cTY_LNG_CODE,
            string cTY_RGON_RSK_GRD_CODE,
            string rLTV_UNNPY_URBN_CODE,
            string bKCD_URBN_CODE,
            string rEL_TP_CODE,
            DateTime rEL_STRT_DT,
            DateTime rEL_END_DT,
            DateTime rEL_STRT_TIME,
            DateTime rEL_END_TIME,
            string rEL_DES,
            string dEL_FLAG,
            string cRTR_TLR_REFNO,
            string cRT_TLR_ORG_REFNO,
            DateTime cRT_DTTM,
            DateTime cUR_ACDT_PERI,
            string lTST_MOD_TLR_REFNO,
            string mOD_TLR_ORG_REFNO,
            string lAST_MNT_STS_CODE,
            DateTime lAST_MOD_DTTM,
            long rCRD_VRSN_SN
        )
        {
            CUSNO = cUSNO;
            ADDR_TP = aDDR_TP;
            ADDR_SN = aDDR_SN;
            LGPER_CODE = lGPER_CODE;
            ADDR_LANG = aDDR_LANG;
            CNRG = cNRG;
            PRVC_MNCP = pRVC_MNCP;
            CITY = cITY;
            CNTY = cNTY;
            ADDR1 = aDDR1;
            PSALC = pSALC;
            RTNPT_FLAG = rTNPT_FLAG;
            PS_NAME = pS_NAME;
            CTY_LNG_CODE = cTY_LNG_CODE;
            CTY_RGON_RSK_GRD_CODE = cTY_RGON_RSK_GRD_CODE;
            RLTV_UNNPY_URBN_CODE = rLTV_UNNPY_URBN_CODE;
            BKCD_URBN_CODE = bKCD_URBN_CODE;
            REL_TP_CODE = rEL_TP_CODE;
            REL_STRT_DT = rEL_STRT_DT;
            REL_END_DT = rEL_END_DT;
            REL_STRT_TIME = rEL_STRT_TIME;
            REL_END_TIME = rEL_END_TIME;
            REL_DES = rEL_DES;
            DEL_FLAG = dEL_FLAG;
            CRTR_TLR_REFNO = cRTR_TLR_REFNO;
            CRT_TLR_ORG_REFNO = cRT_TLR_ORG_REFNO;
            CRT_DTTM = cRT_DTTM;
            CUR_ACDT_PERI = cUR_ACDT_PERI;
            LTST_MOD_TLR_REFNO = lTST_MOD_TLR_REFNO;
            MOD_TLR_ORG_REFNO = mOD_TLR_ORG_REFNO;
            LAST_MNT_STS_CODE = lAST_MNT_STS_CODE;
            LAST_MOD_DTTM = lAST_MOD_DTTM;
            RCRD_VRSN_SN = rCRD_VRSN_SN;
        }
    }
}
