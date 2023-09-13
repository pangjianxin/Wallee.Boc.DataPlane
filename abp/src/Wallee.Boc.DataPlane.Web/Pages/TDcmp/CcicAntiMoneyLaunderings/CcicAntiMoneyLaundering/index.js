$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicAntiMoneyLaunderings.ccicAntiMoneyLaundering;


    var dataTable = $('#CcicAntiMoneyLaunderingTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CCUSNO'),
                data: "cusno"
            },
            {
                title: l('CcicAntiMoneyLaunderingAML_INF_SN'),
                data: "amL_INF_SN"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingEXPC_MO_TXN_SZ_AMT'),
                data: "expC_MO_TXN_SZ_AMT"
            },
            {
                title: l('CcicAntiMoneyLaunderingEXPC_MO_TXN_SZ_CUR'),
                data: "expC_MO_TXN_SZ_CUR"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRRCUS_CODE'),
                data: "crrcuS_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingSDD_CUS_TP'),
                data: "sdD_CUS_TP"
            },
            {
                title: l('CcicAntiMoneyLaunderingTE_CUSRL_PPS'),
                data: "tE_CUSRL_PPS"
            },
            {
                title: l('CcicAntiMoneyLaunderingPURPOSE_REMARK'),
                data: "purposE_REMARK"
            },
            {
                title: l('CcicAntiMoneyLaunderingBENEO_ID_INFO'),
                data: "beneO_ID_INFO"
            },
            {
                title: l('CcicAntiMoneyLaunderingCANNO_ID_BENEO_REASN'),
                data: "cannO_ID_BENEO_REASN"
            },
            {
                title: l('CcicAntiMoneyLaunderingEXST_EXT_SANCT_NMLST_FLAG'),
                data: "exsT_EXT_SANCT_NMLST_FLAG"
            },
            {
                title: l('CcicAntiMoneyLaunderingPOLI_FLAG'),
                data: "polI_FLAG"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRR_RSK_GRD_CODE'),
                data: "crR_RSK_GRD_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingAML_RSK_GRD_VLD_START_DT'),
                data: "amL_RSK_GRD_VLD_START_DT"
            },
            {
                title: l('CcicAntiMoneyLaunderingAML_RSK_GRD_VLD_TMT_DT'),
                data: "amL_RSK_GRD_VLD_TMT_DT"
            },
            {
                title: l('CcicAntiMoneyLaunderingDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicAntiMoneyLaunderingCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicAntiMoneyLaunderingLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicAntiMoneyLaunderingRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicAntiMoneyLaunderingRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));
});
