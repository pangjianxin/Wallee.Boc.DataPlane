$(function () {

   

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicNames.ccicName;
    

    var dataTable = $('#CcicNameTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicNameCUS_NAME_LANG'),
                data: "cuS_NAME_LANG"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicNameCUS_NAME'),
                data: "cuS_NAME"
            },
            {
                title: l('CcicNameCUS_NAME_START_DT'),
                data: "cuS_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_NAME_TMT_DT'),
                data: "cuS_NAME_TMT_DT"
            },
            {
                title: l('CcicNameCUS_SHTNM'),
                data: "cuS_SHTNM"
            },
            {
                title: l('CcicNameCUS_SHTNM_START_DT'),
                data: "cuS_SHTNM_START_DT"
            },
            {
                title: l('CcicNameCUS_SHTNM_ENDDT_PERI'),
                data: "cuS_SHTNM_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_SWIFT_NAME'),
                data: "cuS_SWIFT_NAME"
            },
            {
                title: l('CcicNameCUS_SWIFT_NAME_START_DT'),
                data: "cuS_SWIFT_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_SWIFT_NAME_ENDDT_PERI'),
                data: "cuS_SWIFT_NAME_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_SHNM'),
                data: "cuS_SHNM"
            },
            {
                title: l('CcicNameCUS_SHNM_START_DT'),
                data: "cuS_SHNM_START_DT"
            },
            {
                title: l('CcicNameCUS_SHNM_ENDDT_PERI'),
                data: "cuS_SHNM_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_FRMNM_NAME'),
                data: "cuS_FRMNM_NAME"
            },
            {
                title: l('CcicNameCUS_FRMNM_NAME_START_DT'),
                data: "cuS_FRMNM_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_FRMNM_NAME_ENDDT_PERI'),
                data: "cuS_FRMNM_NAME_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME_TP'),
                data: "cuS_OTHR_NAME_TP"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME'),
                data: "cuS_OTHR_NAME"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME_START_DT'),
                data: "cuS_OTHR_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME_TMT_DT'),
                data: "cuS_OTHR_NAME_TMT_DT"
            },
            {
                title: l('CcicNameDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicNameCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicNameCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicNameCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicNameCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicNameLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicNameMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicNameLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicNameLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicNameRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicNameRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

 
});
