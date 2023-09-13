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
                data: "cusno"
            },
            {
                title: l('CcicRegisterLGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicRegisterRGST_CNRG'),
                data: "rgsT_CNRG"
            },
            {
                title: l('CcicRegisterENTP_INCDT_PERI'),
                data: "entP_INCDT_PERI"
            },
            {
                title: l('CcicRegisterSEAR_DT'),
                data: "seaR_DT"
            },
            {
                title: l('CcicRegisterLOUT_DT'),
                data: "louT_DT"
            },
            {
                title: l('CcicRegisterOPRT_MATU_START_DT'),
                data: "oprT_MATU_START_DT"
            },
            {
                title: l('CcicRegisterOPRT_MATU_TMT_DT'),
                data: "oprT_MATU_TMT_DT"
            },
            {
                title: l('CcicRegisterOPRT_MATU'),
                data: "oprT_MATU"
            },
            {
                title: l('CcicRegisterLGPER_FLAG'),
                data: "lgpeR_FLAG"
            },
            {
                title: l('CcicRegisterNO_HV_LGPER_QUA_OF_CUS_TP'),
                data: "nO_HV_LGPER_QUA_OF_CUS_TP"
            },
            {
                title: l('CcicRegisterRGCAP_CUR'),
                data: "rgcaP_CUR"
            },
            {
                title: l('CcicRegisterRC_AMT'),
                data: "rC_AMT"
            },
            {
                title: l('CcicRegisterARCPT_CUR'),
                data: "arcpT_CUR"
            },
            {
                title: l('CcicRegisterARCPT_AMT'),
                data: "arcpT_AMT"
            },
            {
                title: l('CcicRegisterORGN_FNDS_CUR'),
                data: "orgN_FNDS_CUR"
            },
            {
                title: l('CcicRegisterORGN_FNDS_AMT'),
                data: "orgN_FNDS_AMT"
            },
            {
                title: l('CcicRegisterFEE_SRC'),
                data: "feE_SRC"
            },
            {
                title: l('CcicRegisterCARE_UNBDG_TP'),
                data: "carE_UNBDG_TP"
            },
            {
                title: l('CcicRegisterSHR_TOTAL'),
                data: "shR_TOTAL"
            },
            {
                title: l('CcicRegisterISSU_EQU_AMT'),
                data: "issU_EQU_AMT"
            },
            {
                title: l('CcicRegisterBZSCP'),
                data: "bzscp"
            },
            {
                title: l('CcicRegisterBSN_SCOP'),
                data: "bsN_SCOP"
            },
            {
                title: l('CcicRegisterPRCLN_AND_BSN_SCOP_DES'),
                data: "prclN_AND_BSN_SCOP_DES"
            },
            {
                title: l('CcicRegisterMAINB_1_SCOP_NOTE'),
                data: "mainB_1_SCOP_NOTE"
            },
            {
                title: l('CcicRegisterMAINB_2_SCOP_NOTE'),
                data: "mainB_2_SCOP_NOTE"
            },
            {
                title: l('CcicRegisterMAINB_3_SCOP_NOTE'),
                data: "mainB_3_SCOP_NOTE"
            },
            {
                title: l('CcicRegisterIVS_PRJ_ENTP_INFO_NOTE'),
                data: "ivS_PRJ_ENTP_INFO_NOTE"
            },
            {
                title: l('CcicRegisterMIX_SCOP'),
                data: "miX_SCOP"
            },
            {
                title: l('CcicRegisterAVY_TRTY'),
                data: "avY_TRTY"
            },
            {
                title: l('CcicRegisterHOST_UNIT_NAME'),
                data: "hosT_UNIT_NAME"
            },
            {
                title: l('CcicRegisterBSN_SPVS_UNIT_NAME'),
                data: "bsN_SPVS_UNIT_NAME"
            },
            {
                title: l('CcicRegisterIDBZ_BSNLC_WORD_NO_NAME'),
                data: "idbZ_BSNLC_WORD_NO_NAME"
            },
            {
                title: l('CcicRegisterIDBZ_BSNLC_COMP_ITFO_DES'),
                data: "idbZ_BSNLC_COMP_ITFO_DES"
            },
            {
                title: l('CcicRegisterIDBZ_BSNLC_BZSCP_AND_MOD_DES'),
                data: "idbZ_BSNLC_BZSCP_AND_MOD_DES"
            },
            {
                title: l('CcicRegisterDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicRegisterCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicRegisterCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicRegisterCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicRegisterCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicRegisterLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicRegisterMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicRegisterLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicRegisterLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicRegisterRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicRegisterRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));
});
