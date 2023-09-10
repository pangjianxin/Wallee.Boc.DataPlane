using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Wallee.Boc.DataPlane.TDcmp.CcicIds
{
    /// <summary>
    /// 对公证件信息
    /// a20
    /// </summary>
    public class CcicId : BasicAggregateRoot
    {
        /// <summary>
        ///  客户号. (字符型(10))
        /// </summary>
        public string CUSNO { get; set; } = default!;

        /// <summary>
        ///  证件类型. (字符型(2))
        /// 证件类型代码  查代码集“其他关联代码集”sheet
        /// </summary>
        public string CRDT_TP { get; set; } = default!;

        /// <summary>
        ///  证件序号. (数值型(3))
        /// </summary>
        public int CRDT_SN { get; set; } = default!;

        /// <summary>
        ///  法人编码. (字符型(3))
        /// </summary>
        public string LGPER_CODE { get; set; } = default!;

        /// <summary>
        ///  证件号码. (字符型(32))
        /// </summary>
        public string? CRAD { get; set; }

        /// <summary>
        ///  证件属性. (字符型(1))
        /// </summary>
        public string? CRDT_ATR { get; set; }

        /// <summary>
        ///  其他证件类型说明. (字符型(60))
        /// </summary>
        public string? OTHR_CRTY_NOTE { get; set; }

        /// <summary>
        ///  证件签发地址(国家/地区). (字符型(3))
        /// </summary>
        public string? CRDT_SGIS_ADDR4 { get; set; }

        /// <summary>
        ///  发证机关所在地. (字符型(6))
        /// </summary>
        public string? ISSCT_AHR_LO { get; set; }

        /// <summary>
        ///  证件签发机关名称. (字符型(400))
        /// </summary>
        public string? CRDT_SGIS_AHR_NAME { get; set; }

        /// <summary>
        ///  证件签发日期. (日期型(8))
        /// </summary>
        public DateTime? CRDT_SGIS_DT { get; set; }

        /// <summary>
        ///  证件到期日期. (日期型(8))
        /// </summary>
        public DateTime? CRDT_EXP_DT { get; set; }

        /// <summary>
        ///  证件永久有效标志. (字符型(1))
        /// </summary>
        public string? CRDT_PRM_VLD_FLAG { get; set; }

        /// <summary>
        ///  年检日期. (日期型(8))
        /// </summary>
        public DateTime? ANINS_DT { get; set; }

        /// <summary>
        ///  证件影像ID. (字符型(10))
        /// </summary>
        public string? CRDT_IMAGE_ID { get; set; }

        /// <summary>
        ///  识别信息描述. (字符型(200))
        /// </summary>
        public string? ID_INF_DES { get; set; }

        /// <summary>
        ///  证件状态. (字符型(1))
        /// </summary>
        public string? CRDT_STS { get; set; }

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
        public CcicId()
        {
            
        }
        public override object[] GetKeys()
        {
            return new object[] { CUSNO, CRDT_TP, CRDT_SN, LGPER_CODE };
        }
    }
}
