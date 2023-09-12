$(function () {

   

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicCustomerTypeOrgs.ccicCustomerTypeOrg;
   

    var dataTable = $('#CcicCustomerTypeOrgTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
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
                title: l('CcicCustomerTypeOrgNTECO_DEPT'),
                data: "ntecO_DEPT"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_ECN_CMCLF'),
                data: "entP_ECN_CMCLF"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_CHAR'),
                data: "entP_CHAR"
            },
            {
                title: l('CcicCustomerTypeOrgOWS_STC_CODE'),
                data: "owS_STC_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_SZ_MOIMI_STD'),
                data: "entP_SZ_MOIMI_STD"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_SZ_TB_STD'),
                data: "entP_SZ_TB_STD"
            },
            {
                title: l('CcicCustomerTypeOrgADMN_HIER'),
                data: "admN_HIER"
            },
            {
                title: l('CcicCustomerTypeOrgRESP_ITFO'),
                data: "resP_ITFO"
            },
            {
                title: l('CcicCustomerTypeOrgNONL_SUFLT_ORG_FLAG'),
                data: "nonL_SUFLT_ORG_FLAG"
            },
            {
                title: l('CcicCustomerTypeOrgYES_SUPR_LGPER_OR_SPVS_UNIT_FLAG'),
                data: "yeS_SUPR_LGPER_OR_SPVS_UNIT_FLAG"
            },
            {
                title: l('CcicCustomerTypeOrgGOVT_FUNC_TP_GOVT_UNIQ'),
                data: "govT_FUNC_TP_GOVT_UNIQ"
            },
            {
                title: l('CcicCustomerTypeOrgENV_AND_SOC_RSK_CTGY'),
                data: "enV_AND_SOC_RSK_CTGY"
            },
            {
                title: l('CcicCustomerTypeOrgSEI_TP_CODE'),
                data: "seI_TP_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgHOSP_CUS_LEVEL'),
                data: "hosP_CUS_LEVEL"
            },
            {
                title: l('CcicCustomerTypeOrgORG_TP_CODE'),
                data: "orG_TP_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgIDY_REFNO'),
                data: "idY_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgORG_TYPE_TAX'),
                data: "orG_TYPE_TAX"
            },
            {
                title: l('CcicCustomerTypeOrgRSDNT_TAX_IDR'),
                data: "rsdnT_TAX_IDR"
            },
            {
                title: l('CcicCustomerTypeOrgORG_TAX_RSDNT_IDNT_TP'),
                data: "orG_TAX_RSDNT_IDNT_TP"
            },
            {
                title: l('CcicCustomerTypeOrgTAX_MNT_EFF_DT'),
                data: "taX_MNT_EFF_DT"
            },
            {
                title: l('CcicCustomerTypeOrgDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicCustomerTypeOrgCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicCustomerTypeOrgCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicCustomerTypeOrgLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicCustomerTypeOrgRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicCustomerTypeOrgRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

});
