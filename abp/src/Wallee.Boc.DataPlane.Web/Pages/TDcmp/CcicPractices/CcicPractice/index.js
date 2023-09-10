$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicPractices.ccicPractice;


    var dataTable = $('#CcicPracticeTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: true,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                title: l('CcicPracticeCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicPracticeOPRT_INF_SN'),
                data: "oPRT_INF_SN"
            },
            {
                title: l('CcicPracticeLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicPracticeOPRT_INFO_STAT_YR'),
                data: "oPRT_INFO_STAT_YR"
            },
            {
                title: l('CcicPracticeOPRT_INFO_STAT_INST'),
                data: "oPRT_INFO_STAT_INST"
            },
            {
                title: l('CcicPracticeENTP_GRWUP_STG_CODE'),
                data: "eNTP_GRWUP_STG_CODE"
            },
            {
                title: l('CcicPracticeENTP_OPRT_STS'),
                data: "eNTP_OPRT_STS"
            },
            {
                title: l('CcicPracticeCUS_OPRT_STS_START_DT'),
                data: "cUS_OPRT_STS_START_DT"
            },
            {
                title: l('CcicPracticeCUS_OPRT_STS_TMT_DT'),
                data: "cUS_OPRT_STS_TMT_DT"
            },
            {
                title: l('CcicPracticeINFO_OVW'),
                data: "iNFO_OVW"
            },
            {
                title: l('CcicPracticeCROSS_IDY_OPRT_FLAG'),
                data: "cROSS_IDY_OPRT_FLAG"
            },
            {
                title: l('CcicPracticeLEAD_PD_AND_BRND_DES'),
                data: "lEAD_PD_AND_BRND_DES"
            },
            {
                title: l('CcicPracticeBRND_VAL_CUR'),
                data: "bRND_VAL_CUR"
            },
            {
                title: l('CcicPracticeBRND_VAL'),
                data: "bRND_VAL"
            },
            {
                title: l('CcicPracticeBRND_VISI'),
                data: "bRND_VISI"
            },
            {
                title: l('CcicPracticeBRND_VISI_SURVY_ORG_NAME'),
                data: "bRND_VISI_SURVY_ORG_NAME"
            },
            {
                title: l('CcicPracticeENTP_PD_LIFE_CYCLE'),
                data: "eNTP_PD_LIFE_CYCLE"
            },
            {
                title: l('CcicPracticeCMRC_AVY_PEAK_IDR'),
                data: "cMRC_AVY_PEAK_IDR"
            },
            {
                title: l('CcicPracticeMAIN_ORI_MTRL_DES'),
                data: "mAIN_ORI_MTRL_DES"
            },
            {
                title: l('CcicPracticeCRER_PNUM'),
                data: "cRER_PNUM"
            },
            {
                title: l('CcicPracticeCO_EMPE_AVGAG'),
                data: "cO_EMPE_AVGAG"
            },
            {
                title: l('CcicPracticeSALES_CUR'),
                data: "sALES_CUR"
            },
            {
                title: l('CcicPracticeSALES_AMT'),
                data: "sALES_AMT"
            },
            {
                title: l('CcicPracticeAST_TAMT_CUR'),
                data: "aST_TAMT_CUR"
            },
            {
                title: l('CcicPracticeAST_TAMT'),
                data: "aST_TAMT"
            },
            {
                title: l('CcicPracticeNTAST_CUR'),
                data: "nTAST_CUR"
            },
            {
                title: l('CcicPracticeNTAST_AMT'),
                data: "nTAST_AMT"
            },
            {
                title: l('CcicPracticeDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicPracticeCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicPracticeCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPracticeCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicPracticeCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicPracticeLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicPracticeMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPracticeLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicPracticeLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicPracticeRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicPracticeRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

   
});
