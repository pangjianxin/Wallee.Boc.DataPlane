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
                title: l('CcicAntiMoneyLaunderingCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingAML_INF_SN'),
                data: "aML_INF_SN"
            },
            {
                title: l('CcicAntiMoneyLaunderingLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingEXPC_MO_TXN_SZ_AMT'),
                data: "eXPC_MO_TXN_SZ_AMT"
            },
            {
                title: l('CcicAntiMoneyLaunderingEXPC_MO_TXN_SZ_CUR'),
                data: "eXPC_MO_TXN_SZ_CUR"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRRCUS_CODE'),
                data: "cRRCUS_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingSDD_CUS_TP'),
                data: "sDD_CUS_TP"
            },
            {
                title: l('CcicAntiMoneyLaunderingTE_CUSRL_PPS'),
                data: "tE_CUSRL_PPS"
            },
            {
                title: l('CcicAntiMoneyLaunderingPURPOSE_REMARK'),
                data: "pURPOSE_REMARK"
            },
            {
                title: l('CcicAntiMoneyLaunderingBENEO_ID_INFO'),
                data: "bENEO_ID_INFO"
            },
            {
                title: l('CcicAntiMoneyLaunderingCANNO_ID_BENEO_REASN'),
                data: "cANNO_ID_BENEO_REASN"
            },
            {
                title: l('CcicAntiMoneyLaunderingEXST_EXT_SANCT_NMLST_FLAG'),
                data: "eXST_EXT_SANCT_NMLST_FLAG"
            },
            {
                title: l('CcicAntiMoneyLaunderingPOLI_FLAG'),
                data: "pOLI_FLAG"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRR_RSK_GRD_CODE'),
                data: "cRR_RSK_GRD_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingAML_RSK_GRD_VLD_START_DT'),
                data: "aML_RSK_GRD_VLD_START_DT"
            },
            {
                title: l('CcicAntiMoneyLaunderingAML_RSK_GRD_VLD_TMT_DT'),
                data: "aML_RSK_GRD_VLD_TMT_DT"
            },
            {
                title: l('CcicAntiMoneyLaunderingDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicAntiMoneyLaunderingCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicAntiMoneyLaunderingLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAntiMoneyLaunderingLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicAntiMoneyLaunderingLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicAntiMoneyLaunderingRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicAntiMoneyLaunderingRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

 
});
