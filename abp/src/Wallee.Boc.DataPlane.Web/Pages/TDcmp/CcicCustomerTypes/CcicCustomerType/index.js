$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicCustomerTypes.ccicCustomerType;
    var createModal = new abp.ModalManager(abp.appPath + 'TDcmp/CcicCustomerTypes/CcicCustomerType/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'TDcmp/CcicCustomerTypes/CcicCustomerType/EditModal');

    var dataTable = $('#CcicCustomerTypeTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicCustomerTypeCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicCustomerTypeLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicCustomerTypeCUS_TP'),
                data: "cUS_TP"
            },
            {
                title: l('CcicCustomerTypeCUS_SUBTP'),
                data: "cUS_SUBTP"
            },
            {
                title: l('CcicCustomerTypeINDCL'),
                data: "iNDCL"
            },
            {
                title: l('CcicCustomerTypeFAIRS_CUS_CTGY'),
                data: "fAIRS_CUS_CTGY"
            },
            {
                title: l('CcicCustomerTypeSPV_CUS_TP'),
                data: "sPV_CUS_TP"
            },
            {
                title: l('CcicCustomerTypeSOD_ADIV_GOVT_UNIQ'),
                data: "sOD_ADIV_GOVT_UNIQ"
            },
            {
                title: l('CcicCustomerTypeCRERU_TYPE_CODE'),
                data: "cRERU_TYPE_CODE"
            },
            {
                title: l('CcicCustomerTypeNEW_MODE_CUS_IDR'),
                data: "nEW_MODE_CUS_IDR"
            },
            {
                title: l('CcicCustomerTypeHOSP_CUS_CHAR_CTGY'),
                data: "hOSP_CUS_CHAR_CTGY"
            },
            {
                title: l('CcicCustomerTypeED_IDY_CUS_CHAR_CTGY'),
                data: "eD_IDY_CUS_CHAR_CTGY"
            },
            {
                title: l('CcicCustomerTypeED_IDY_CUS_CTGY'),
                data: "eD_IDY_CUS_CTGY"
            },
            {
                title: l('CcicCustomerTypeCUS_CTGY_LCL'),
                data: "cUS_CTGY_LCL"
            },
            {
                title: l('CcicCustomerTypeCUS_CTGY_STS'),
                data: "cUS_CTGY_STS"
            },
            {
                title: l('CcicCustomerTypeCUS_BLG_LINE'),
                data: "cUS_BLG_LINE"
            },
            {
                title: l('CcicCustomerTypeCUS_ORG'),
                data: "cUS_ORG"
            },
            {
                title: l('CcicCustomerTypeLWRS_FACT_OF_CMRC_ORG_TP_NAME'),
                data: "lWRS_FACT_OF_CMRC_ORG_TP_NAME"
            },
            {
                title: l('CcicCustomerTypeSPLMT_CUS_TP_RSK_CLBR'),
                data: "sPLMT_CUS_TP_RSK_CLBR"
            },
            {
                title: l('CcicCustomerTypePPPC_CUS_LEVEL_CODE'),
                data: "pPPC_CUS_LEVEL_CODE"
            },
            {
                title: l('CcicCustomerTypeHEAL_CUS_TP'),
                data: "hEAL_CUS_TP"
            },
            {
                title: l('CcicCustomerTypeCUS_LYR'),
                data: "cUS_LYR"
            },
            {
                title: l('CcicCustomerTypeCUS_SRC'),
                data: "cUS_SRC"
            },
            {
                title: l('CcicCustomerTypeCUS_LYLT'),
                data: "cUS_LYLT"
            },
            {
                title: l('CcicCustomerTypeAVY_SCOR'),
                data: "aVY_SCOR"
            },
            {
                title: l('CcicCustomerTypeREQ_PRVD_FNRPT_FRQC_CODE'),
                data: "rEQ_PRVD_FNRPT_FRQC_CODE"
            },
            {
                title: l('CcicCustomerTypeCUS_LGCLS_CODE'),
                data: "cUS_LGCLS_CODE"
            },
            {
                title: l('CcicCustomerTypeDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicCustomerTypeCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicCustomerTypeCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicCustomerTypeLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicCustomerTypeLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicCustomerTypeRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicCustomerTypeRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

   
});
