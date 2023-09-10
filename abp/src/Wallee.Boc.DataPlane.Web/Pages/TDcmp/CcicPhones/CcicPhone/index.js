$(function () {

   

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicPhones.ccicPhone;
   

    var dataTable = $('#CcicPhoneTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicPhoneCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicPhoneUNIT_TEL_TP'),
                data: "uNIT_TEL_TP"
            },
            {
                title: l('CcicPhoneCNTEL_SN'),
                data: "cNTEL_SN"
            },
            {
                title: l('CcicPhoneLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicPhoneIC'),
                data: "iC"
            },
            {
                title: l('CcicPhoneDMST_ARCD'),
                data: "dMST_ARCD"
            },
            {
                title: l('CcicPhoneEXN_NO'),
                data: "eXN_NO"
            },
            {
                title: l('CcicPhoneTEL_NO'),
                data: "tEL_NO"
            },
            {
                title: l('CcicPhoneADDR_TP'),
                data: "aDDR_TP"
            },
            {
                title: l('CcicPhoneELC_ADTP'),
                data: "eLC_ADTP"
            },
            {
                title: l('CcicPhoneREL_TP_CODE'),
                data: "rEL_TP_CODE"
            },
            {
                title: l('CcicPhoneREL_STRT_DT'),
                data: "rEL_STRT_DT"
            },
            {
                title: l('CcicPhoneREL_END_DT'),
                data: "rEL_END_DT"
            },
            {
                title: l('CcicPhoneREL_STRT_TIME'),
                data: "rEL_STRT_TIME"
            },
            {
                title: l('CcicPhoneREL_END_TIME'),
                data: "rEL_END_TIME"
            },
            {
                title: l('CcicPhoneREL_DES'),
                data: "rEL_DES"
            },
            {
                title: l('CcicPhoneDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicPhoneCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicPhoneCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPhoneCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicPhoneCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicPhoneLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicPhoneMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPhoneLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicPhoneLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicPhoneRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicPhoneRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

   
});
