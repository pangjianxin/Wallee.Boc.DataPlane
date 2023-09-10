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
                title: l('CcicCustomerTypeOrgCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicCustomerTypeOrgLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgNTECO_DEPT'),
                data: "nTECO_DEPT"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_ECN_CMCLF'),
                data: "eNTP_ECN_CMCLF"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_CHAR'),
                data: "eNTP_CHAR"
            },
            {
                title: l('CcicCustomerTypeOrgOWS_STC_CODE'),
                data: "oWS_STC_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_SZ_MOIMI_STD'),
                data: "eNTP_SZ_MOIMI_STD"
            },
            {
                title: l('CcicCustomerTypeOrgENTP_SZ_TB_STD'),
                data: "eNTP_SZ_TB_STD"
            },
            {
                title: l('CcicCustomerTypeOrgADMN_HIER'),
                data: "aDMN_HIER"
            },
            {
                title: l('CcicCustomerTypeOrgRESP_ITFO'),
                data: "rESP_ITFO"
            },
            {
                title: l('CcicCustomerTypeOrgNONL_SUFLT_ORG_FLAG'),
                data: "nONL_SUFLT_ORG_FLAG"
            },
            {
                title: l('CcicCustomerTypeOrgYES_SUPR_LGPER_OR_SPVS_UNIT_FLAG'),
                data: "yES_SUPR_LGPER_OR_SPVS_UNIT_FLAG"
            },
            {
                title: l('CcicCustomerTypeOrgGOVT_FUNC_TP_GOVT_UNIQ'),
                data: "gOVT_FUNC_TP_GOVT_UNIQ"
            },
            {
                title: l('CcicCustomerTypeOrgENV_AND_SOC_RSK_CTGY'),
                data: "eNV_AND_SOC_RSK_CTGY"
            },
            {
                title: l('CcicCustomerTypeOrgSEI_TP_CODE'),
                data: "sEI_TP_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgHOSP_CUS_LEVEL'),
                data: "hOSP_CUS_LEVEL"
            },
            {
                title: l('CcicCustomerTypeOrgORG_TP_CODE'),
                data: "oRG_TP_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgIDY_REFNO'),
                data: "iDY_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgORG_TYPE_TAX'),
                data: "oRG_TYPE_TAX"
            },
            {
                title: l('CcicCustomerTypeOrgRSDNT_TAX_IDR'),
                data: "rSDNT_TAX_IDR"
            },
            {
                title: l('CcicCustomerTypeOrgORG_TAX_RSDNT_IDNT_TP'),
                data: "oRG_TAX_RSDNT_IDNT_TP"
            },
            {
                title: l('CcicCustomerTypeOrgTAX_MNT_EFF_DT'),
                data: "tAX_MNT_EFF_DT"
            },
            {
                title: l('CcicCustomerTypeOrgDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicCustomerTypeOrgCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicCustomerTypeOrgCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicCustomerTypeOrgLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicCustomerTypeOrgLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicCustomerTypeOrgLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicCustomerTypeOrgRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicCustomerTypeOrgRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

});
