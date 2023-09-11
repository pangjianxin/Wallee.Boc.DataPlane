using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wallee.Boc.DataPlane.Migrations
{
    /// <inheritdoc />
    public partial class AddTdcmpTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCcicAntiMoneyLaunderings",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AMLINFSN = table.Column<int>(name: "AML_INF_SN", type: "int", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    EXPCMOTXNSZAMT = table.Column<decimal>(name: "EXPC_MO_TXN_SZ_AMT", type: "decimal(18,3)", nullable: true),
                    EXPCMOTXNSZCUR = table.Column<string>(name: "EXPC_MO_TXN_SZ_CUR", type: "nvarchar(max)", nullable: true),
                    CRRCUSCODE = table.Column<string>(name: "CRRCUS_CODE", type: "nvarchar(max)", nullable: true),
                    SDDCUSTP = table.Column<string>(name: "SDD_CUS_TP", type: "nvarchar(max)", nullable: true),
                    TECUSRLPPS = table.Column<string>(name: "TE_CUSRL_PPS", type: "nvarchar(max)", nullable: true),
                    PURPOSEREMARK = table.Column<string>(name: "PURPOSE_REMARK", type: "nvarchar(max)", nullable: true),
                    BENEOIDINFO = table.Column<string>(name: "BENEO_ID_INFO", type: "nvarchar(max)", nullable: true),
                    CANNOIDBENEOREASN = table.Column<string>(name: "CANNO_ID_BENEO_REASN", type: "nvarchar(max)", nullable: true),
                    EXSTEXTSANCTNMLSTFLAG = table.Column<string>(name: "EXST_EXT_SANCT_NMLST_FLAG", type: "nvarchar(max)", nullable: true),
                    POLIFLAG = table.Column<string>(name: "POLI_FLAG", type: "nvarchar(max)", nullable: true),
                    CRRRSKGRDCODE = table.Column<string>(name: "CRR_RSK_GRD_CODE", type: "nvarchar(max)", nullable: true),
                    AMLRSKGRDVLDSTARTDT = table.Column<DateTime>(name: "AML_RSK_GRD_VLD_START_DT", type: "datetime2", nullable: true),
                    AMLRSKGRDVLDTMTDT = table.Column<DateTime>(name: "AML_RSK_GRD_VLD_TMT_DT", type: "datetime2", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicAntiMoneyLaunderings", x => new { x.CUSNO, x.AMLINFSN, x.LGPERCODE });
                },
                comment: "对公反洗钱信息    a02");

            migrationBuilder.CreateTable(
                name: "AppCcicCustomerTypeOrgs",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    NTECODEPT = table.Column<string>(name: "NTECO_DEPT", type: "nvarchar(max)", nullable: true),
                    ENTPECNCMCLF = table.Column<string>(name: "ENTP_ECN_CMCLF", type: "nvarchar(max)", nullable: true),
                    ENTPCHAR = table.Column<string>(name: "ENTP_CHAR", type: "nvarchar(max)", nullable: true),
                    OWSSTCCODE = table.Column<string>(name: "OWS_STC_CODE", type: "nvarchar(max)", nullable: true),
                    ENTPSZMOIMISTD = table.Column<string>(name: "ENTP_SZ_MOIMI_STD", type: "nvarchar(max)", nullable: true),
                    ENTPSZTBSTD = table.Column<string>(name: "ENTP_SZ_TB_STD", type: "nvarchar(max)", nullable: true),
                    ADMNHIER = table.Column<string>(name: "ADMN_HIER", type: "nvarchar(max)", nullable: true),
                    RESPITFO = table.Column<string>(name: "RESP_ITFO", type: "nvarchar(max)", nullable: true),
                    NONLSUFLTORGFLAG = table.Column<string>(name: "NONL_SUFLT_ORG_FLAG", type: "nvarchar(max)", nullable: true),
                    YESSUPRLGPERORSPVSUNITFLAG = table.Column<string>(name: "YES_SUPR_LGPER_OR_SPVS_UNIT_FLAG", type: "nvarchar(max)", nullable: true),
                    GOVTFUNCTPGOVTUNIQ = table.Column<string>(name: "GOVT_FUNC_TP_GOVT_UNIQ", type: "nvarchar(max)", nullable: true),
                    ENVANDSOCRSKCTGY = table.Column<string>(name: "ENV_AND_SOC_RSK_CTGY", type: "nvarchar(max)", nullable: true),
                    SEITPCODE = table.Column<string>(name: "SEI_TP_CODE", type: "nvarchar(max)", nullable: true),
                    HOSPCUSLEVEL = table.Column<string>(name: "HOSP_CUS_LEVEL", type: "nvarchar(max)", nullable: true),
                    ORGTPCODE = table.Column<string>(name: "ORG_TP_CODE", type: "nvarchar(max)", nullable: true),
                    IDYREFNO = table.Column<string>(name: "IDY_REFNO", type: "nvarchar(max)", nullable: true),
                    ORGTYPETAX = table.Column<string>(name: "ORG_TYPE_TAX", type: "nvarchar(max)", nullable: true),
                    RSDNTTAXIDR = table.Column<string>(name: "RSDNT_TAX_IDR", type: "nvarchar(max)", nullable: true),
                    ORGTAXRSDNTIDNTTP = table.Column<string>(name: "ORG_TAX_RSDNT_IDNT_TP", type: "nvarchar(max)", nullable: true),
                    TAXMNTEFFDT = table.Column<DateTime>(name: "TAX_MNT_EFF_DT", type: "datetime2", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicCustomerTypeOrgs", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公客户类别信息-组织    a09");

            migrationBuilder.CreateTable(
                name: "AppCcicCustomerTypes",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    CUSTP = table.Column<string>(name: "CUS_TP", type: "nvarchar(max)", nullable: true),
                    CUSSUBTP = table.Column<string>(name: "CUS_SUBTP", type: "nvarchar(max)", nullable: true),
                    INDCL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAIRSCUSCTGY = table.Column<string>(name: "FAIRS_CUS_CTGY", type: "nvarchar(max)", nullable: true),
                    SPVCUSTP = table.Column<string>(name: "SPV_CUS_TP", type: "nvarchar(max)", nullable: true),
                    SODADIVGOVTUNIQ = table.Column<string>(name: "SOD_ADIV_GOVT_UNIQ", type: "nvarchar(max)", nullable: true),
                    CRERUTYPECODE = table.Column<string>(name: "CRERU_TYPE_CODE", type: "nvarchar(max)", nullable: true),
                    NEWMODECUSIDR = table.Column<string>(name: "NEW_MODE_CUS_IDR", type: "nvarchar(max)", nullable: true),
                    HOSPCUSCHARCTGY = table.Column<string>(name: "HOSP_CUS_CHAR_CTGY", type: "nvarchar(max)", nullable: true),
                    EDIDYCUSCHARCTGY = table.Column<string>(name: "ED_IDY_CUS_CHAR_CTGY", type: "nvarchar(max)", nullable: true),
                    EDIDYCUSCTGY = table.Column<string>(name: "ED_IDY_CUS_CTGY", type: "nvarchar(max)", nullable: true),
                    CUSCTGYLCL = table.Column<string>(name: "CUS_CTGY_LCL", type: "nvarchar(max)", nullable: true),
                    CUSCTGYSTS = table.Column<string>(name: "CUS_CTGY_STS", type: "nvarchar(max)", nullable: true),
                    CUSBLGLINE = table.Column<string>(name: "CUS_BLG_LINE", type: "nvarchar(max)", nullable: true),
                    CUSORG = table.Column<string>(name: "CUS_ORG", type: "nvarchar(max)", nullable: true),
                    LWRSFACTOFCMRCORGTPNAME = table.Column<string>(name: "LWRS_FACT_OF_CMRC_ORG_TP_NAME", type: "nvarchar(max)", nullable: true),
                    SPLMTCUSTPRSKCLBR = table.Column<string>(name: "SPLMT_CUS_TP_RSK_CLBR", type: "nvarchar(max)", nullable: true),
                    PPPCCUSLEVELCODE = table.Column<string>(name: "PPPC_CUS_LEVEL_CODE", type: "nvarchar(max)", nullable: true),
                    HEALCUSTP = table.Column<string>(name: "HEAL_CUS_TP", type: "nvarchar(max)", nullable: true),
                    CUSLYR = table.Column<string>(name: "CUS_LYR", type: "nvarchar(max)", nullable: true),
                    CUSSRC = table.Column<string>(name: "CUS_SRC", type: "nvarchar(max)", nullable: true),
                    CUSLYLT = table.Column<decimal>(name: "CUS_LYLT", type: "decimal(18,2)", nullable: true),
                    AVYSCOR = table.Column<decimal>(name: "AVY_SCOR", type: "decimal(18,2)", nullable: true),
                    REQPRVDFNRPTFRQCCODE = table.Column<string>(name: "REQ_PRVD_FNRPT_FRQC_CODE", type: "nvarchar(max)", nullable: true),
                    CUSLGCLSCODE = table.Column<string>(name: "CUS_LGCLS_CODE", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicCustomerTypes", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公客户类别信息    a08");

            migrationBuilder.CreateTable(
                name: "AppCcicGeneralOrgs",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    ENJLCLGOVTPRFTPCTP = table.Column<string>(name: "ENJ_LCL_GOVT_PRFT_PC_TP", type: "nvarchar(max)", nullable: true),
                    FNCSUBSINCMSRC = table.Column<string>(name: "FNC_SUBS_INCM_SRC", type: "nvarchar(max)", nullable: true),
                    FNDSSRCINF = table.Column<string>(name: "FNDS_SRC_INF", type: "nvarchar(max)", nullable: true),
                    WLTHSRCOVSEA = table.Column<string>(name: "WLTH_SRC_OVSEA", type: "nvarchar(max)", nullable: true),
                    WLTHSRCISOTHRHOURNOTE = table.Column<string>(name: "WLTH_SRC_IS_OTHR_HOUR_NOTE", type: "nvarchar(max)", nullable: true),
                    WLTHSRCCNRG = table.Column<string>(name: "WLTH_SRC_CNRG", type: "nvarchar(max)", nullable: true),
                    ENTPINTD = table.Column<string>(name: "ENTP_INTD", type: "nvarchar(max)", nullable: true),
                    LOGOIMAGEFILEID = table.Column<string>(name: "LOGO_IMAGE_FILE_ID", type: "nvarchar(max)", nullable: true),
                    LOGONAME = table.Column<string>(name: "LOGO_NAME", type: "nvarchar(max)", nullable: true),
                    COTAOAATTCHID = table.Column<string>(name: "CO_TAOA_ATTCH_ID", type: "nvarchar(max)", nullable: true),
                    EXSTOURBKEQUPCT = table.Column<decimal>(name: "EXST_OURBK_EQU_PCT", type: "decimal(6,2)", nullable: true),
                    BSCDEPACCNO = table.Column<string>(name: "BSC_DEP_ACCNO", type: "nvarchar(max)", nullable: true),
                    BSCDEPACCACOPAPVLNO = table.Column<string>(name: "BSC_DEP_ACC_ACOP_APVL_NO", type: "nvarchar(max)", nullable: true),
                    BSCDEPACCDEPBKNAME = table.Column<string>(name: "BSC_DEP_ACC_DEPBK_NAME", type: "nvarchar(max)", nullable: true),
                    BSCDEPACCOPNACDT = table.Column<DateTime>(name: "BSC_DEP_ACC_OPNAC_DT", type: "datetime2", nullable: true),
                    ENTPDEVESTRTG = table.Column<string>(name: "ENTP_DEVE_STRTG", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicGeneralOrgs", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公概况-组织    a18");

            migrationBuilder.CreateTable(
                name: "AppCcicIds",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CRDTTP = table.Column<string>(name: "CRDT_TP", type: "nvarchar(450)", nullable: false),
                    CRDTSN = table.Column<int>(name: "CRDT_SN", type: "int", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    CRAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CRDTATR = table.Column<string>(name: "CRDT_ATR", type: "nvarchar(max)", nullable: true),
                    OTHRCRTYNOTE = table.Column<string>(name: "OTHR_CRTY_NOTE", type: "nvarchar(max)", nullable: true),
                    CRDTSGISADDR4 = table.Column<string>(name: "CRDT_SGIS_ADDR4", type: "nvarchar(max)", nullable: true),
                    ISSCTAHRLO = table.Column<string>(name: "ISSCT_AHR_LO", type: "nvarchar(max)", nullable: true),
                    CRDTSGISAHRNAME = table.Column<string>(name: "CRDT_SGIS_AHR_NAME", type: "nvarchar(max)", nullable: true),
                    CRDTSGISDT = table.Column<DateTime>(name: "CRDT_SGIS_DT", type: "datetime2", nullable: true),
                    CRDTEXPDT = table.Column<DateTime>(name: "CRDT_EXP_DT", type: "datetime2", nullable: true),
                    CRDTPRMVLDFLAG = table.Column<string>(name: "CRDT_PRM_VLD_FLAG", type: "nvarchar(max)", nullable: true),
                    ANINSDT = table.Column<DateTime>(name: "ANINS_DT", type: "datetime2", nullable: true),
                    CRDTIMAGEID = table.Column<string>(name: "CRDT_IMAGE_ID", type: "nvarchar(max)", nullable: true),
                    IDINFDES = table.Column<string>(name: "ID_INF_DES", type: "nvarchar(max)", nullable: true),
                    CRDTSTS = table.Column<string>(name: "CRDT_STS", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicIds", x => new { x.CUSNO, x.CRDTTP, x.CRDTSN, x.LGPERCODE });
                },
                comment: "对公证件信息    a20");

            migrationBuilder.CreateTable(
                name: "AppCcicLsolationLists",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    QUARNSTS = table.Column<string>(name: "QUARN_STS", type: "nvarchar(max)", nullable: true),
                    QUARNTP = table.Column<string>(name: "QUARN_TP", type: "nvarchar(max)", nullable: true),
                    QUARNREASN = table.Column<string>(name: "QUARN_REASN", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: false),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: false),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: false),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: false),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: false),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: false),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: false),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicLsolationLists", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公隔离清单信息    a82");

            migrationBuilder.CreateTable(
                name: "AppCcicNames",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CUSNAMELANG = table.Column<string>(name: "CUS_NAME_LANG", type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    CUSNAME = table.Column<string>(name: "CUS_NAME", type: "nvarchar(max)", nullable: true),
                    CUSNAMESTARTDT = table.Column<DateTime>(name: "CUS_NAME_START_DT", type: "datetime2", nullable: true),
                    CUSNAMETMTDT = table.Column<DateTime>(name: "CUS_NAME_TMT_DT", type: "datetime2", nullable: true),
                    CUSSHTNM = table.Column<string>(name: "CUS_SHTNM", type: "nvarchar(max)", nullable: true),
                    CUSSHTNMSTARTDT = table.Column<DateTime>(name: "CUS_SHTNM_START_DT", type: "datetime2", nullable: true),
                    CUSSHTNMENDDTPERI = table.Column<DateTime>(name: "CUS_SHTNM_ENDDT_PERI", type: "datetime2", nullable: true),
                    CUSSWIFTNAME = table.Column<string>(name: "CUS_SWIFT_NAME", type: "nvarchar(max)", nullable: true),
                    CUSSWIFTNAMESTARTDT = table.Column<DateTime>(name: "CUS_SWIFT_NAME_START_DT", type: "datetime2", nullable: true),
                    CUSSWIFTNAMEENDDTPERI = table.Column<DateTime>(name: "CUS_SWIFT_NAME_ENDDT_PERI", type: "datetime2", nullable: true),
                    CUSSHNM = table.Column<string>(name: "CUS_SHNM", type: "nvarchar(max)", nullable: true),
                    CUSSHNMSTARTDT = table.Column<DateTime>(name: "CUS_SHNM_START_DT", type: "datetime2", nullable: true),
                    CUSSHNMENDDTPERI = table.Column<DateTime>(name: "CUS_SHNM_ENDDT_PERI", type: "datetime2", nullable: true),
                    CUSFRMNMNAME = table.Column<string>(name: "CUS_FRMNM_NAME", type: "nvarchar(max)", nullable: true),
                    CUSFRMNMNAMESTARTDT = table.Column<DateTime>(name: "CUS_FRMNM_NAME_START_DT", type: "datetime2", nullable: true),
                    CUSFRMNMNAMEENDDTPERI = table.Column<DateTime>(name: "CUS_FRMNM_NAME_ENDDT_PERI", type: "datetime2", nullable: true),
                    CUSOTHRNAMETP = table.Column<string>(name: "CUS_OTHR_NAME_TP", type: "nvarchar(max)", nullable: true),
                    CUSOTHRNAME = table.Column<string>(name: "CUS_OTHR_NAME", type: "nvarchar(max)", nullable: true),
                    CUSOTHRNAMESTARTDT = table.Column<DateTime>(name: "CUS_OTHR_NAME_START_DT", type: "datetime2", nullable: true),
                    CUSOTHRNAMETMTDT = table.Column<DateTime>(name: "CUS_OTHR_NAME_TMT_DT", type: "datetime2", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicNames", x => new { x.CUSNO, x.CUSNAMELANG, x.LGPERCODE });
                },
                comment: "对公名称信息    a22");

            migrationBuilder.CreateTable(
                name: "AppCcicPersonalRelations",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RELRL = table.Column<string>(name: "REL_RL", type: "nvarchar(450)", nullable: false),
                    PRINTCUSNOYARD = table.Column<string>(name: "PRINT_CUSNO_YARD", type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    RELDES = table.Column<string>(name: "REL_DES", type: "nvarchar(max)", nullable: true),
                    RELSTRTDT = table.Column<DateTime>(name: "REL_STRT_DT", type: "datetime2", nullable: true),
                    RELENDDT = table.Column<DateTime>(name: "REL_END_DT", type: "datetime2", nullable: true),
                    RELSTRTTIME = table.Column<TimeSpan>(name: "REL_STRT_TIME", type: "time", nullable: true),
                    RELENDTIME = table.Column<TimeSpan>(name: "REL_END_TIME", type: "time", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicPersonalRelations", x => new { x.CUSNO, x.RELRL, x.PRINTCUSNOYARD, x.LGPERCODE });
                },
                comment: "对公人员关系    a24");

            migrationBuilder.CreateTable(
                name: "AppCcicPhones",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UNITTELTP = table.Column<string>(name: "UNIT_TEL_TP", type: "nvarchar(450)", nullable: false),
                    CNTELSN = table.Column<int>(name: "CNTEL_SN", type: "int", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    IC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DMSTARCD = table.Column<string>(name: "DMST_ARCD", type: "nvarchar(max)", nullable: true),
                    EXNNO = table.Column<string>(name: "EXN_NO", type: "nvarchar(max)", nullable: true),
                    TELNO = table.Column<string>(name: "TEL_NO", type: "nvarchar(max)", nullable: true),
                    ADDRTP = table.Column<string>(name: "ADDR_TP", type: "nvarchar(max)", nullable: true),
                    ELCADTP = table.Column<string>(name: "ELC_ADTP", type: "nvarchar(max)", nullable: true),
                    RELTPCODE = table.Column<string>(name: "REL_TP_CODE", type: "nvarchar(max)", nullable: true),
                    RELSTRTDT = table.Column<DateTime>(name: "REL_STRT_DT", type: "datetime2", nullable: true),
                    RELENDDT = table.Column<DateTime>(name: "REL_END_DT", type: "datetime2", nullable: true),
                    RELSTRTTIME = table.Column<TimeSpan>(name: "REL_STRT_TIME", type: "time", nullable: true),
                    RELENDTIME = table.Column<TimeSpan>(name: "REL_END_TIME", type: "time", nullable: true),
                    RELDES = table.Column<string>(name: "REL_DES", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicPhones", x => new { x.CUSNO, x.UNITTELTP, x.CNTELSN, x.LGPERCODE });
                },
                comment: "对公名称信息    a22");

            migrationBuilder.CreateTable(
                name: "AppCcicPractices",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OPRTINFSN = table.Column<int>(name: "OPRT_INF_SN", type: "int", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    OPRTINFOSTATYR = table.Column<DateTime>(name: "OPRT_INFO_STAT_YR", type: "datetime2", nullable: true),
                    OPRTINFOSTATINST = table.Column<int>(name: "OPRT_INFO_STAT_INST", type: "int", nullable: true),
                    ENTPGRWUPSTGCODE = table.Column<string>(name: "ENTP_GRWUP_STG_CODE", type: "nvarchar(max)", nullable: true),
                    ENTPOPRTSTS = table.Column<string>(name: "ENTP_OPRT_STS", type: "nvarchar(max)", nullable: true),
                    CUSOPRTSTSSTARTDT = table.Column<DateTime>(name: "CUS_OPRT_STS_START_DT", type: "datetime2", nullable: true),
                    CUSOPRTSTSTMTDT = table.Column<DateTime>(name: "CUS_OPRT_STS_TMT_DT", type: "datetime2", nullable: true),
                    INFOOVW = table.Column<string>(name: "INFO_OVW", type: "nvarchar(max)", nullable: true),
                    CROSSIDYOPRTFLAG = table.Column<string>(name: "CROSS_IDY_OPRT_FLAG", type: "nvarchar(max)", nullable: true),
                    LEADPDANDBRNDDES = table.Column<string>(name: "LEAD_PD_AND_BRND_DES", type: "nvarchar(max)", nullable: true),
                    BRNDVALCUR = table.Column<string>(name: "BRND_VAL_CUR", type: "nvarchar(max)", nullable: true),
                    BRNDVAL = table.Column<decimal>(name: "BRND_VAL", type: "decimal(18,3)", nullable: true),
                    BRNDVISI = table.Column<string>(name: "BRND_VISI", type: "nvarchar(max)", nullable: true),
                    BRNDVISISURVYORGNAME = table.Column<string>(name: "BRND_VISI_SURVY_ORG_NAME", type: "nvarchar(max)", nullable: true),
                    ENTPPDLIFECYCLE = table.Column<string>(name: "ENTP_PD_LIFE_CYCLE", type: "nvarchar(max)", nullable: true),
                    CMRCAVYPEAKIDR = table.Column<string>(name: "CMRC_AVY_PEAK_IDR", type: "nvarchar(max)", nullable: true),
                    MAINORIMTRLDES = table.Column<string>(name: "MAIN_ORI_MTRL_DES", type: "nvarchar(max)", nullable: true),
                    CRERPNUM = table.Column<int>(name: "CRER_PNUM", type: "int", nullable: true),
                    COEMPEAVGAG = table.Column<decimal>(name: "CO_EMPE_AVGAG", type: "decimal(5,2)", nullable: true),
                    SALESCUR = table.Column<string>(name: "SALES_CUR", type: "nvarchar(max)", nullable: true),
                    SALESAMT = table.Column<decimal>(name: "SALES_AMT", type: "decimal(18,3)", nullable: true),
                    ASTTAMTCUR = table.Column<string>(name: "AST_TAMT_CUR", type: "nvarchar(max)", nullable: true),
                    ASTTAMT = table.Column<decimal>(name: "AST_TAMT", type: "decimal(18,3)", nullable: true),
                    NTASTCUR = table.Column<string>(name: "NTAST_CUR", type: "nvarchar(max)", nullable: true),
                    NTASTAMT = table.Column<decimal>(name: "NTAST_AMT", type: "decimal(18,3)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicPractices", x => new { x.CUSNO, x.OPRTINFSN, x.LGPERCODE });
                },
                comment: "对公运营信息    a26");

            migrationBuilder.CreateTable(
                name: "AppCcicRegisters",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    RGSTCNRG = table.Column<string>(name: "RGST_CNRG", type: "nvarchar(max)", nullable: true),
                    ENTPINCDTPERI = table.Column<DateTime>(name: "ENTP_INCDT_PERI", type: "datetime2", nullable: true),
                    SEARDT = table.Column<DateTime>(name: "SEAR_DT", type: "datetime2", nullable: true),
                    LOUTDT = table.Column<DateTime>(name: "LOUT_DT", type: "datetime2", nullable: true),
                    OPRTMATUSTARTDT = table.Column<DateTime>(name: "OPRT_MATU_START_DT", type: "datetime2", nullable: true),
                    OPRTMATUTMTDT = table.Column<DateTime>(name: "OPRT_MATU_TMT_DT", type: "datetime2", nullable: true),
                    OPRTMATU = table.Column<int>(name: "OPRT_MATU", type: "int", nullable: true),
                    LGPERFLAG = table.Column<string>(name: "LGPER_FLAG", type: "nvarchar(max)", nullable: true),
                    NOHVLGPERQUAOFCUSTP = table.Column<string>(name: "NO_HV_LGPER_QUA_OF_CUS_TP", type: "nvarchar(max)", nullable: true),
                    RGCAPCUR = table.Column<string>(name: "RGCAP_CUR", type: "nvarchar(max)", nullable: true),
                    RCAMT = table.Column<decimal>(name: "RC_AMT", type: "decimal(18,3)", nullable: true),
                    ARCPTCUR = table.Column<string>(name: "ARCPT_CUR", type: "nvarchar(max)", nullable: true),
                    ARCPTAMT = table.Column<decimal>(name: "ARCPT_AMT", type: "decimal(18,3)", nullable: true),
                    ORGNFNDSCUR = table.Column<string>(name: "ORGN_FNDS_CUR", type: "nvarchar(max)", nullable: true),
                    ORGNFNDSAMT = table.Column<decimal>(name: "ORGN_FNDS_AMT", type: "decimal(18,3)", nullable: true),
                    FEESRC = table.Column<string>(name: "FEE_SRC", type: "nvarchar(max)", nullable: true),
                    CAREUNBDGTP = table.Column<string>(name: "CARE_UNBDG_TP", type: "nvarchar(max)", nullable: true),
                    SHRTOTAL = table.Column<decimal>(name: "SHR_TOTAL", type: "decimal(24,6)", nullable: true),
                    ISSUEQUAMT = table.Column<decimal>(name: "ISSU_EQU_AMT", type: "decimal(18,3)", nullable: true),
                    BZSCP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BSNSCOP = table.Column<string>(name: "BSN_SCOP", type: "nvarchar(max)", nullable: true),
                    PRCLNANDBSNSCOPDES = table.Column<string>(name: "PRCLN_AND_BSN_SCOP_DES", type: "nvarchar(max)", nullable: true),
                    MAINB1SCOPNOTE = table.Column<string>(name: "MAINB_1_SCOP_NOTE", type: "nvarchar(max)", nullable: true),
                    MAINB2SCOPNOTE = table.Column<string>(name: "MAINB_2_SCOP_NOTE", type: "nvarchar(max)", nullable: true),
                    MAINB3SCOPNOTE = table.Column<string>(name: "MAINB_3_SCOP_NOTE", type: "nvarchar(max)", nullable: true),
                    IVSPRJENTPINFONOTE = table.Column<string>(name: "IVS_PRJ_ENTP_INFO_NOTE", type: "nvarchar(max)", nullable: true),
                    MIXSCOP = table.Column<string>(name: "MIX_SCOP", type: "nvarchar(max)", nullable: true),
                    AVYTRTY = table.Column<string>(name: "AVY_TRTY", type: "nvarchar(max)", nullable: true),
                    HOSTUNITNAME = table.Column<string>(name: "HOST_UNIT_NAME", type: "nvarchar(max)", nullable: true),
                    BSNSPVSUNITNAME = table.Column<string>(name: "BSN_SPVS_UNIT_NAME", type: "nvarchar(max)", nullable: true),
                    IDBZBSNLCWORDNONAME = table.Column<string>(name: "IDBZ_BSNLC_WORD_NO_NAME", type: "nvarchar(max)", nullable: true),
                    IDBZBSNLCCOMPITFODES = table.Column<string>(name: "IDBZ_BSNLC_COMP_ITFO_DES", type: "nvarchar(max)", nullable: true),
                    IDBZBSNLCBZSCPANDMODDES = table.Column<string>(name: "IDBZ_BSNLC_BZSCP_AND_MOD_DES", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicRegisters", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公注册信息    a28");

            migrationBuilder.CreateTable(
                name: "AppCcicSignOrgs",
                columns: table => new
                {
                    CUSNO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LGPERCODE = table.Column<string>(name: "LGPER_CODE", type: "nvarchar(450)", nullable: false),
                    SUPRUNITLGPERPNPTP = table.Column<string>(name: "SUPR_UNIT_LGPER_PNP_TP", type: "nvarchar(max)", nullable: true),
                    LSTCOFLAG = table.Column<string>(name: "LSTCO_FLAG", type: "nvarchar(max)", nullable: true),
                    HTCHEFLAG = table.Column<string>(name: "HTCHE_FLAG", type: "nvarchar(max)", nullable: true),
                    EXMPTRGSSOCGROUFLAG = table.Column<string>(name: "EXMPT_RGS_SOC_GROU_FLAG", type: "nvarchar(max)", nullable: true),
                    NONPFTPROPORGFLAG = table.Column<string>(name: "NON_PFT_PROP_ORG_FLAG", type: "nvarchar(max)", nullable: true),
                    SERISILLGRCRDFLAG = table.Column<string>(name: "SERIS_ILLG_RCRD_FLAG", type: "nvarchar(max)", nullable: true),
                    PSLITFTAWITHFLAG = table.Column<string>(name: "PS_LIT_FTA_WITH_FLAG", type: "nvarchar(max)", nullable: true),
                    PUBENFLAG = table.Column<string>(name: "PUBEN_FLAG", type: "nvarchar(max)", nullable: true),
                    CHINASCEFLAG = table.Column<string>(name: "CHINA_SCE_FLAG", type: "nvarchar(max)", nullable: true),
                    TPEFLAG = table.Column<string>(name: "TPE_FLAG", type: "nvarchar(max)", nullable: true),
                    ILLGDISHFLAG = table.Column<string>(name: "ILLG_DISH_FLAG", type: "nvarchar(max)", nullable: true),
                    SPCLECOREENTPFLAG = table.Column<string>(name: "SPCL_ECORE_ENTP_FLAG", type: "nvarchar(max)", nullable: true),
                    AGROFLAG = table.Column<string>(name: "AGRO_FLAG", type: "nvarchar(max)", nullable: true),
                    ARAAFENTPFLAG = table.Column<string>(name: "ARAAF_ENTP_FLAG", type: "nvarchar(max)", nullable: true),
                    EUORGFLAG = table.Column<string>(name: "EU_ORG_FLAG", type: "nvarchar(max)", nullable: true),
                    SATIENTPFLAG = table.Column<string>(name: "SATI_ENTP_FLAG", type: "nvarchar(max)", nullable: true),
                    FNCPVRTFLAG = table.Column<string>(name: "FNC_PVRT_FLAG", type: "nvarchar(max)", nullable: true),
                    UNICENTPFLAG = table.Column<string>(name: "UNIC_ENTP_FLAG", type: "nvarchar(max)", nullable: true),
                    DELFLAG = table.Column<string>(name: "DEL_FLAG", type: "nvarchar(max)", nullable: true),
                    CRTRTLRREFNO = table.Column<string>(name: "CRTR_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTTLRORGREFNO = table.Column<string>(name: "CRT_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    CRTDTTM = table.Column<DateTime>(name: "CRT_DTTM", type: "datetime2", nullable: true),
                    CURACDTPERI = table.Column<DateTime>(name: "CUR_ACDT_PERI", type: "datetime2", nullable: true),
                    LTSTMODTLRREFNO = table.Column<string>(name: "LTST_MOD_TLR_REFNO", type: "nvarchar(max)", nullable: true),
                    MODTLRORGREFNO = table.Column<string>(name: "MOD_TLR_ORG_REFNO", type: "nvarchar(max)", nullable: true),
                    LASTMNTSTSCODE = table.Column<string>(name: "LAST_MNT_STS_CODE", type: "nvarchar(max)", nullable: true),
                    LASTMODDTTM = table.Column<DateTime>(name: "LAST_MOD_DTTM", type: "datetime2", nullable: true),
                    RCRDVRSNSN = table.Column<string>(name: "RCRD_VRSN_SN", type: "nvarchar(max)", nullable: true),
                    RCRDCLNUPSTSCD = table.Column<string>(name: "RCRD_CLNUP_STSCD", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCcicSignOrgs", x => new { x.CUSNO, x.LGPERCODE });
                },
                comment: "对公重要标志信息-组织    a35");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCcicAntiMoneyLaunderings");

            migrationBuilder.DropTable(
                name: "AppCcicCustomerTypeOrgs");

            migrationBuilder.DropTable(
                name: "AppCcicCustomerTypes");

            migrationBuilder.DropTable(
                name: "AppCcicGeneralOrgs");

            migrationBuilder.DropTable(
                name: "AppCcicIds");

            migrationBuilder.DropTable(
                name: "AppCcicLsolationLists");

            migrationBuilder.DropTable(
                name: "AppCcicNames");

            migrationBuilder.DropTable(
                name: "AppCcicPersonalRelations");

            migrationBuilder.DropTable(
                name: "AppCcicPhones");

            migrationBuilder.DropTable(
                name: "AppCcicPractices");

            migrationBuilder.DropTable(
                name: "AppCcicRegisters");

            migrationBuilder.DropTable(
                name: "AppCcicSignOrgs");
        }
    }
}
