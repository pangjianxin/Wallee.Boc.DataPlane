$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicSignOrgs.ccicSignOrg;

    var dataTable = $('#CcicSignOrgTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicSignOrgCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicSignOrgLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicSignOrgSUPR_UNIT_LGPER_PNP_TP'),
                data: "sUPR_UNIT_LGPER_PNP_TP"
            },
            {
                title: l('CcicSignOrgLSTCO_FLAG'),
                data: "lSTCO_FLAG"
            },
            {
                title: l('CcicSignOrgHTCHE_FLAG'),
                data: "hTCHE_FLAG"
            },
            {
                title: l('CcicSignOrgEXMPT_RGS_SOC_GROU_FLAG'),
                data: "eXMPT_RGS_SOC_GROU_FLAG"
            },
            {
                title: l('CcicSignOrgNON_PFT_PROP_ORG_FLAG'),
                data: "nON_PFT_PROP_ORG_FLAG"
            },
            {
                title: l('CcicSignOrgSERIS_ILLG_RCRD_FLAG'),
                data: "sERIS_ILLG_RCRD_FLAG"
            },
            {
                title: l('CcicSignOrgPS_LIT_FTA_WITH_FLAG'),
                data: "pS_LIT_FTA_WITH_FLAG"
            },
            {
                title: l('CcicSignOrgPUBEN_FLAG'),
                data: "pUBEN_FLAG"
            },
            {
                title: l('CcicSignOrgCHINA_SCE_FLAG'),
                data: "cHINA_SCE_FLAG"
            },
            {
                title: l('CcicSignOrgTPE_FLAG'),
                data: "tPE_FLAG"
            },
            {
                title: l('CcicSignOrgILLG_DISH_FLAG'),
                data: "iLLG_DISH_FLAG"
            },
            {
                title: l('CcicSignOrgSPCL_ECORE_ENTP_FLAG'),
                data: "sPCL_ECORE_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgAGRO_FLAG'),
                data: "aGRO_FLAG"
            },
            {
                title: l('CcicSignOrgARAAF_ENTP_FLAG'),
                data: "aRAAF_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgEU_ORG_FLAG'),
                data: "eU_ORG_FLAG"
            },
            {
                title: l('CcicSignOrgSATI_ENTP_FLAG'),
                data: "sATI_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgFNC_PVRT_FLAG'),
                data: "fNC_PVRT_FLAG"
            },
            {
                title: l('CcicSignOrgUNIC_ENTP_FLAG'),
                data: "uNIC_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicSignOrgCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicSignOrgCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicSignOrgCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicSignOrgCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicSignOrgLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicSignOrgMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicSignOrgLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicSignOrgLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicSignOrgRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicSignOrgRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));
});
