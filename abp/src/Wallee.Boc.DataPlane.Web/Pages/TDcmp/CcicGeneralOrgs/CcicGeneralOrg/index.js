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
                title: l('CcicGeneralOrgCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicGeneralOrgLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicGeneralOrgENJ_LCL_GOVT_PRFT_PC_TP'),
                data: "eNJ_LCL_GOVT_PRFT_PC_TP"
            },
            {
                title: l('CcicGeneralOrgFNC_SUBS_INCM_SRC'),
                data: "fNC_SUBS_INCM_SRC"
            },
            {
                title: l('CcicGeneralOrgFNDS_SRC_INF'),
                data: "fNDS_SRC_INF"
            },
            {
                title: l('CcicGeneralOrgWLTH_SRC_OVSEA'),
                data: "wLTH_SRC_OVSEA"
            },
            {
                title: l('CcicGeneralOrgWLTH_SRC_IS_OTHR_HOUR_NOTE'),
                data: "wLTH_SRC_IS_OTHR_HOUR_NOTE"
            },
            {
                title: l('CcicGeneralOrgWLTH_SRC_CNRG'),
                data: "wLTH_SRC_CNRG"
            },
            {
                title: l('CcicGeneralOrgENTP_INTD'),
                data: "eNTP_INTD"
            },
            {
                title: l('CcicGeneralOrgLOGO_IMAGE_FILE_ID'),
                data: "lOGO_IMAGE_FILE_ID"
            },
            {
                title: l('CcicGeneralOrgLOGO_NAME'),
                data: "lOGO_NAME"
            },
            {
                title: l('CcicGeneralOrgCO_TAOA_ATTCH_ID'),
                data: "cO_TAOA_ATTCH_ID"
            },
            {
                title: l('CcicGeneralOrgEXST_OURBK_EQU_PCT'),
                data: "eXST_OURBK_EQU_PCT"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACCNO'),
                data: "bSC_DEP_ACCNO"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACC_ACOP_APVL_NO'),
                data: "bSC_DEP_ACC_ACOP_APVL_NO"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACC_DEPBK_NAME'),
                data: "bSC_DEP_ACC_DEPBK_NAME"
            },
            {
                title: l('CcicGeneralOrgBSC_DEP_ACC_OPNAC_DT'),
                data: "bSC_DEP_ACC_OPNAC_DT"
            },
            {
                title: l('CcicGeneralOrgENTP_DEVE_STRTG'),
                data: "eNTP_DEVE_STRTG"
            },
            {
                title: l('CcicGeneralOrgDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicGeneralOrgCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicGeneralOrgCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicGeneralOrgCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicGeneralOrgCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicGeneralOrgLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicGeneralOrgMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicGeneralOrgLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicGeneralOrgLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicGeneralOrgRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicGeneralOrgRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

 
});
