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
                title: l('CUSNO'),
                data: "cusno"
            },
            {
                title: l('CcicPracticeOPRT_INF_SN'),
                data: "oprT_INF_SN"
            },
            {
                title: l('CcicPracticeLGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicPracticeOPRT_INFO_STAT_YR'),
                data: "oprT_INFO_STAT_YR"
            },
            {
                title: l('CcicPracticeOPRT_INFO_STAT_INST'),
                data: "oprT_INFO_STAT_INST"
            },
            {
                title: l('CcicPracticeENTP_GRWUP_STG_CODE'),
                data: "entP_GRWUP_STG_CODE"
            },
            {
                title: l('CcicPracticeENTP_OPRT_STS'),
                data: "entP_OPRT_STS"
            },
            {
                title: l('CcicPracticeCUS_OPRT_STS_START_DT'),
                data: "cuS_OPRT_STS_START_DT"
            },
            {
                title: l('CcicPracticeCUS_OPRT_STS_TMT_DT'),
                data: "cuS_OPRT_STS_TMT_DT"
            },
            {
                title: l('CcicPracticeINFO_OVW'),
                data: "infO_OVW"
            },
            {
                title: l('CcicPracticeCROSS_IDY_OPRT_FLAG'),
                data: "crosS_IDY_OPRT_FLAG"
            },
            {
                title: l('CcicPracticeLEAD_PD_AND_BRND_DES'),
                data: "leaD_PD_AND_BRND_DES"
            },
            {
                title: l('CcicPracticeBRND_VAL_CUR'),
                data: "brnD_VAL_CUR"
            },
            {
                title: l('CcicPracticeBRND_VAL'),
                data: "brnD_VAL"
            },
            {
                title: l('CcicPracticeBRND_VISI'),
                data: "brnD_VISI"
            },
            {
                title: l('CcicPracticeBRND_VISI_SURVY_ORG_NAME'),
                data: "brnD_VISI_SURVY_ORG_NAME"
            },
            {
                title: l('CcicPracticeENTP_PD_LIFE_CYCLE'),
                data: "entP_PD_LIFE_CYCLE"
            },
            {
                title: l('CcicPracticeCMRC_AVY_PEAK_IDR'),
                data: "cmrC_AVY_PEAK_IDR"
            },
            {
                title: l('CcicPracticeMAIN_ORI_MTRL_DES'),
                data: "maiN_ORI_MTRL_DES"
            },
            {
                title: l('CcicPracticeCRER_PNUM'),
                data: "creR_PNUM"
            },
            {
                title: l('CcicPracticeCO_EMPE_AVGAG'),
                data: "cO_EMPE_AVGAG"
            },
            {
                title: l('CcicPracticeSALES_CUR'),
                data: "saleS_CUR"
            },
            {
                title: l('CcicPracticeSALES_AMT'),
                data: "saleS_AMT"
            },
            {
                title: l('CcicPracticeAST_TAMT_CUR'),
                data: "asT_TAMT_CUR"
            },
            {
                title: l('CcicPracticeAST_TAMT'),
                data: "asT_TAMT"
            },
            {
                title: l('CcicPracticeNTAST_CUR'),
                data: "ntasT_CUR"
            },
            {
                title: l('CcicPracticeNTAST_AMT'),
                data: "ntasT_AMT"
            },
            {
                title: l('CcicPracticeDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicPracticeCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicPracticeCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPracticeCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicPracticeCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicPracticeLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicPracticeMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPracticeLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicPracticeLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicPracticeRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicPracticeRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

   
});
