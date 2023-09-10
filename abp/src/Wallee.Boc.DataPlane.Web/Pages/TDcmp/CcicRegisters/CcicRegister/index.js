$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicRegisters.ccicRegister;


    var dataTable = $('#CcicRegisterTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicRegisterCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicRegisterLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicRegisterRGST_CNRG'),
                data: "rGST_CNRG"
            },
            {
                title: l('CcicRegisterENTP_INCDT_PERI'),
                data: "eNTP_INCDT_PERI"
            },
            {
                title: l('CcicRegisterSEAR_DT'),
                data: "sEAR_DT"
            },
            {
                title: l('CcicRegisterLOUT_DT'),
                data: "lOUT_DT"
            },
            {
                title: l('CcicRegisterOPRT_MATU_START_DT'),
                data: "oPRT_MATU_START_DT"
            },
            {
                title: l('CcicRegisterOPRT_MATU_TMT_DT'),
                data: "oPRT_MATU_TMT_DT"
            },
            {
                title: l('CcicRegisterOPRT_MATU'),
                data: "oPRT_MATU"
            },
            {
                title: l('CcicRegisterLGPER_FLAG'),
                data: "lGPER_FLAG"
            },
            {
                title: l('CcicRegisterNO_HV_LGPER_QUA_OF_CUS_TP'),
                data: "nO_HV_LGPER_QUA_OF_CUS_TP"
            },
            {
                title: l('CcicRegisterRGCAP_CUR'),
                data: "rGCAP_CUR"
            },
            {
                title: l('CcicRegisterRC_AMT'),
                data: "rC_AMT"
            },
            {
                title: l('CcicRegisterARCPT_CUR'),
                data: "aRCPT_CUR"
            },
            {
                title: l('CcicRegisterARCPT_AMT'),
                data: "aRCPT_AMT"
            },
            {
                title: l('CcicRegisterORGN_FNDS_CUR'),
                data: "oRGN_FNDS_CUR"
            },
            {
                title: l('CcicRegisterORGN_FNDS_AMT'),
                data: "oRGN_FNDS_AMT"
            },
            {
                title: l('CcicRegisterFEE_SRC'),
                data: "fEE_SRC"
            },
            {
                title: l('CcicRegisterCARE_UNBDG_TP'),
                data: "cARE_UNBDG_TP"
            },
            {
                title: l('CcicRegisterSHR_TOTAL'),
                data: "sHR_TOTAL"
            },
            {
                title: l('CcicRegisterISSU_EQU_AMT'),
                data: "iSSU_EQU_AMT"
            },
            {
                title: l('CcicRegisterBZSCP'),
                data: "bZSCP"
            },
            {
                title: l('CcicRegisterBSN_SCOP'),
                data: "bSN_SCOP"
            },
            {
                title: l('CcicRegisterPRCLN_AND_BSN_SCOP_DES'),
                data: "pRCLN_AND_BSN_SCOP_DES"
            },
            {
                title: l('CcicRegisterMAINB_1_SCOP_NOTE'),
                data: "mAINB_1_SCOP_NOTE"
            },
            {
                title: l('CcicRegisterMAINB_2_SCOP_NOTE'),
                data: "mAINB_2_SCOP_NOTE"
            },
            {
                title: l('CcicRegisterMAINB_3_SCOP_NOTE'),
                data: "mAINB_3_SCOP_NOTE"
            },
            {
                title: l('CcicRegisterIVS_PRJ_ENTP_INFO_NOTE'),
                data: "iVS_PRJ_ENTP_INFO_NOTE"
            },
            {
                title: l('CcicRegisterMIX_SCOP'),
                data: "mIX_SCOP"
            },
            {
                title: l('CcicRegisterAVY_TRTY'),
                data: "aVY_TRTY"
            },
            {
                title: l('CcicRegisterHOST_UNIT_NAME'),
                data: "hOST_UNIT_NAME"
            },
            {
                title: l('CcicRegisterBSN_SPVS_UNIT_NAME'),
                data: "bSN_SPVS_UNIT_NAME"
            },
            {
                title: l('CcicRegisterIDBZ_BSNLC_WORD_NO_NAME'),
                data: "iDBZ_BSNLC_WORD_NO_NAME"
            },
            {
                title: l('CcicRegisterIDBZ_BSNLC_COMP_ITFO_DES'),
                data: "iDBZ_BSNLC_COMP_ITFO_DES"
            },
            {
                title: l('CcicRegisterIDBZ_BSNLC_BZSCP_AND_MOD_DES'),
                data: "iDBZ_BSNLC_BZSCP_AND_MOD_DES"
            },
            {
                title: l('CcicRegisterDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicRegisterCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicRegisterCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicRegisterCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicRegisterCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicRegisterLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicRegisterMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicRegisterLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicRegisterLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicRegisterRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicRegisterRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));
});
