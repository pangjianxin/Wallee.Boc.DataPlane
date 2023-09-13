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
                data: "cusno"
            },
            {
                title: l('CcicPhoneUNIT_TEL_TP'),
                data: "uniT_TEL_TP"
            },
            {
                title: l('CcicPhoneCNTEL_SN'),
                data: "cnteL_SN"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicPhoneIC'),
                data: "ic"
            },
            {
                title: l('CcicPhoneDMST_ARCD'),
                data: "dmsT_ARCD"
            },
            {
                title: l('CcicPhoneEXN_NO'),
                data: "exN_NO"
            },
            {
                title: l('CcicPhoneTEL_NO'),
                data: "teL_NO"
            },
            {
                title: l('CcicPhoneADDR_TP'),
                data: "addR_TP"
            },
            {
                title: l('CcicPhoneELC_ADTP'),
                data: "elC_ADTP"
            },
            {
                title: l('CcicPhoneREL_TP_CODE'),
                data: "reL_TP_CODE"
            },
            {
                title: l('CcicPhoneREL_STRT_DT'),
                data: "reL_STRT_DT"
            },
            {
                title: l('CcicPhoneREL_END_DT'),
                data: "reL_END_DT"
            },
            {
                title: l('CcicPhoneREL_STRT_TIME'),
                data: "reL_STRT_TIME"
            },
            {
                title: l('CcicPhoneREL_END_TIME'),
                data: "reL_END_TIME"
            },
            {
                title: l('CcicPhoneREL_DES'),
                data: "reL_DES"
            },
            {
                title: l('CcicPhoneDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicPhoneCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicPhoneCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPhoneCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicPhoneCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicPhoneLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicPhoneMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPhoneLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicPhoneLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicPhoneRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicPhoneRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

   
});
