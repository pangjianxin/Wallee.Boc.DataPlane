$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicGeneralOrgs.ccicGeneralOrg;


    var dataTable = $('#CcicGeneralOrgTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicGeneralOrgENJ_LCL_GOVT_PRFT_PC_TP'),
                data: "enJ_LCL_GOVT_PRFT_PC_TP"
            },
            {
                title: l('CcicGeneralOrgFNC_SUBS_INCM_SRC'),
                data: "fnC_SUBS_INCM_SRC"
            },
            {
                title: l('CcicGeneralOrgFNDS_SRC_INF'),
                data: "fnsS_SRC_INF"
            },
            {
                title: l('CcicGeneralOrgWLTH_SRC_OVSEA'),
                data: "wltH_SRC_OVSEA"
            },
            {
                title: l('CcicGeneralOrgWLTH_SRC_IS_OTHR_HOUR_NOTE'),
                data: "wltH_SRC_IS_OTHR_HOUR_NOTE"
            },
            {
                title: l('CcicGeneralOrgWLTH_SRC_CNRG'),
                data: "wltH_SRC_CNRG"
            },
            {
                title: l('CcicGeneralOrgENTP_INTD'),
                data: "entP_INTD"
            },
            {
                title: l('CcicGeneralOrgLOGO_IMAGE_FILE_ID'),
                data: "logO_IMAGE_FILE_ID"
            },
            {
                title: l('CcicGeneralOrgLOGO_NAME'),
                data: "logO_NAME"
            },
            {
                title: l('CcicGeneralOrgCO_TAOA_ATTCH_ID'),
                data: "cO_TAOA_ATTCH_ID"
            },
            {
                title: l('CcicGeneralOrgEXST_OURBK_EQU_PCT'),
                data: "exsT_OURBK_EQU_PCT"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACCNO'),
                data: "bsC_DEP_ACCNO"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACC_ACOP_APVL_NO'),
                data: "bsC_DEP_ACC_ACOP_APVL_NO"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACC_DEPBK_NAME'),
                data: "bsC_DEP_ACC_DEPBK_NAME"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACC_OPNAC_DT'),
                data: "bsC_DEP_ACC_OPNAC_DT"
            },
            {
                title: l('CcicGeneralOrgENTP_DEVE_STRTG'),
                data: "entP_DEVE_STRTG"
            },
            {
                title: l('CcicGeneralOrgDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicGeneralOrgCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicGeneralOrgCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicGeneralOrgCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicGeneralOrgCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicGeneralOrgLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicGeneralOrgMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicGeneralOrgLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicGeneralOrgLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicGeneralOrgRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicGeneralOrgRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

 
});
