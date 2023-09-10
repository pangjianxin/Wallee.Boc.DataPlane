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
                title: l('CcicNameCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicNameCUS_NAME_LANG'),
                data: "cUS_NAME_LANG"
            },
            {
                title: l('CcicNameLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicNameCUS_NAME'),
                data: "cUS_NAME"
            },
            {
                title: l('CcicNameCUS_NAME_START_DT'),
                data: "cUS_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_NAME_TMT_DT'),
                data: "cUS_NAME_TMT_DT"
            },
            {
                title: l('CcicNameCUS_SHTNM'),
                data: "cUS_SHTNM"
            },
            {
                title: l('CcicNameCUS_SHTNM_START_DT'),
                data: "cUS_SHTNM_START_DT"
            },
            {
                title: l('CcicNameCUS_SHTNM_ENDDT_PERI'),
                data: "cUS_SHTNM_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_SWIFT_NAME'),
                data: "cUS_SWIFT_NAME"
            },
            {
                title: l('CcicNameCUS_SWIFT_NAME_START_DT'),
                data: "cUS_SWIFT_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_SWIFT_NAME_ENDDT_PERI'),
                data: "cUS_SWIFT_NAME_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_SHNM'),
                data: "cUS_SHNM"
            },
            {
                title: l('CcicNameCUS_SHNM_START_DT'),
                data: "cUS_SHNM_START_DT"
            },
            {
                title: l('CcicNameCUS_SHNM_ENDDT_PERI'),
                data: "cUS_SHNM_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_FRMNM_NAME'),
                data: "cUS_FRMNM_NAME"
            },
            {
                title: l('CcicNameCUS_FRMNM_NAME_START_DT'),
                data: "cUS_FRMNM_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_FRMNM_NAME_ENDDT_PERI'),
                data: "cUS_FRMNM_NAME_ENDDT_PERI"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME_TP'),
                data: "cUS_OTHR_NAME_TP"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME'),
                data: "cUS_OTHR_NAME"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME_START_DT'),
                data: "cUS_OTHR_NAME_START_DT"
            },
            {
                title: l('CcicNameCUS_OTHR_NAME_TMT_DT'),
                data: "cUS_OTHR_NAME_TMT_DT"
            },
            {
                title: l('CcicNameDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicNameCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicNameCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicNameCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicNameCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicNameLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicNameMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicNameLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicNameLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicNameRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicNameRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

 
});
