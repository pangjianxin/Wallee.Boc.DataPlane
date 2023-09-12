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
                title: l('CUSNO'),
                data: "cusno"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicCustomerTypeCUS_TP'),
                data: "cuS_TP"
            },
            {
                title: l('CcicCustomerTypeCUS_SUBTP'),
                data: "cuS_SUBTP"
            },
            {
                title: l('CcicCustomerTypeINDCL'),
                data: "indcl"
            },
            {
                title: l('CcicCustomerTypeFAIRS_CUS_CTGY'),
                data: "fairS_CUS_CTGY"
            },
            {
                title: l('CcicCustomerTypeSPV_CUS_TP'),
                data: "spV_CUS_TP"
            },
            {
                title: l('CcicCustomerTypeSOD_ADIV_GOVT_UNIQ'),
                data: "soD_ADIV_GOVT_UNIQ"
            },
            {
                title: l('CcicCustomerTypeCRERU_TYPE_CODE'),
                data: "crerU_TYPE_CODE"
            },
            {
                title: l('CcicCustomerTypeNEW_MODE_CUS_IDR'),
                data: "neW_MODE_CUS_IDR"
            },
            {
                title: l('CcicCustomerTypeHOSP_CUS_CHAR_CTGY'),
                data: "hosP_CUS_CHAR_CTGY"
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
                data: "cuS_CTGY_LCL"
            },
            {
                title: l('CcicCustomerTypeCUS_CTGY_STS'),
                data: "cuS_CTGY_STS"
            },
            {
                title: l('CcicCustomerTypeCUS_BLG_LINE'),
                data: "cuS_BLG_LINE"
            },
            {
                title: l('CcicCustomerTypeCUS_ORG'),
                data: "cuS_ORG"
            },
            {
                title: l('CcicCustomerTypeLWRS_FACT_OF_CMRC_ORG_TP_NAME'),
                data: "lwrS_FACT_OF_CMRC_ORG_TP_NAME"
            },
            {
                title: l('CcicCustomerTypeSPLMT_CUS_TP_RSK_CLBR'),
                data: "splmT_CUS_TP_RSK_CLBR"
            },
            {
                title: l('CcicCustomerTypePPPC_CUS_LEVEL_CODE'),
                data: "pppC_CUS_LEVEL_CODE"
            },
            {
                title: l('CcicCustomerTypeHEAL_CUS_TP'),
                data: "heaL_CUS_TP"
            },
            {
                title: l('CcicCustomerTypeCUS_LYR'),
                data: "cuS_LYR"
            },
            {
                title: l('CcicCustomerTypeCUS_SRC'),
                data: "cuS_SRC"
            },
            {
                title: l('CcicCustomerTypeCUS_LYLT'),
                data: "cuS_LYLT"
            },
            {
                title: l('CcicCustomerTypeAVY_SCOR'),
                data: "avY_SCOR"
            },
            {
                title: l('CcicCustomerTypeREQ_PRVD_FNRPT_FRQC_CODE'),
                data: "reQ_PRVD_FNRPT_FRQC_CODE"
            },
            {
                title: l('CcicCustomerTypeCUS_LGCLS_CODE'),
                data: "cuS_LGCLS_CODE"
            },
            {
                title: l('CcicCustomerTypeDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicCustomerTypeCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicCustomerTypeCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicCustomerTypeLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicCustomerTypeLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicCustomerTypeRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicCustomerTypeRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

   
});
