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
                data: "cusno"
            },
            {
                title: l('CcicSignOrgLGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicSignOrgSUPR_UNIT_LGPER_PNP_TP'),
                data: "supR_UNIT_LGPER_PNP_TP"
            },
            {
                title: l('CcicSignOrgLSTCO_FLAG'),
                data: "lstcO_FLAG"
            },
            {
                title: l('CcicSignOrgHTCHE_FLAG'),
                data: "htchE_FLAG"
            },
            {
                title: l('CcicSignOrgEXMPT_RGS_SOC_GROU_FLAG'),
                data: "exmpT_RGS_SOC_GROU_FLAG"
            },
            {
                title: l('CcicSignOrgNON_PFT_PROP_ORG_FLAG'),
                data: "noN_PFT_PROP_ORG_FLAG"
            },
            {
                title: l('CcicSignOrgSERIS_ILLG_RCRD_FLAG'),
                data: "seriS_ILLG_RCRD_FLAG"
            },
            {
                title: l('CcicSignOrgPS_LIT_FTA_WITH_FLAG'),
                data: "pS_LIT_FTA_WITH_FLAG"
            },
            {
                title: l('CcicSignOrgPUBEN_FLAG'),
                data: "pubeN_FLAG"
            },
            {
                title: l('CcicSignOrgCHINA_SCE_FLAG'),
                data: "chinA_SCE_FLAG"
            },
            {
                title: l('CcicSignOrgTPE_FLAG'),
                data: "tpE_FLAG"
            },
            {
                title: l('CcicSignOrgILLG_DISH_FLAG'),
                data: "illG_DISH_FLAG"
            },
            {
                title: l('CcicSignOrgSPCL_ECORE_ENTP_FLAG'),
                data: "spcL_ECORE_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgAGRO_FLAG'),
                data: "agrO_FLAG"
            },
            {
                title: l('CcicSignOrgARAAF_ENTP_FLAG'),
                data: "araaF_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgEU_ORG_FLAG'),
                data: "eU_ORG_FLAG"
            },
            {
                title: l('CcicSignOrgSATI_ENTP_FLAG'),
                data: "satI_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgFNC_PVRT_FLAG'),
                data: "fnC_PVRT_FLAG"
            },
            {
                title: l('CcicSignOrgUNIC_ENTP_FLAG'),
                data: "uniC_ENTP_FLAG"
            },
            {
                title: l('CcicSignOrgDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicSignOrgCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicSignOrgCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicSignOrgCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicSignOrgCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicSignOrgLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicSignOrgMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicSignOrgLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicSignOrgLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicSignOrgRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicSignOrgRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));
});
