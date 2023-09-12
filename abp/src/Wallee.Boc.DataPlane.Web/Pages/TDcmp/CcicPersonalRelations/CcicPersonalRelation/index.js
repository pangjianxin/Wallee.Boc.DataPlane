$(function () {

   

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicPersonalRelations.ccicPersonalRelation;
   

    var dataTable = $('#CcicPersonalRelationTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicPersonalRelationREL_RL'),
                data: "reL_RL"
            },
            {
                title: l('CcicPersonalRelationPRINT_CUSNO_YARD'),
                data: "prinT_CUSNO_YARD"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicPersonalRelationREL_DES'),
                data: "reL_DES"
            },
            {
                title: l('CcicPersonalRelationREL_STRT_DT'),
                data: "reL_STRT_DT"
            },
            {
                title: l('CcicPersonalRelationREL_END_DT'),
                data: "reL_END_DT"
            },
            {
                title: l('CcicPersonalRelationREL_STRT_TIME'),
                data: "reL_STRT_TIME"
            },
            {
                title: l('CcicPersonalRelationREL_END_TIME'),
                data: "reL_END_TIME"
            },
            {
                title: l('CcicPersonalRelationDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicPersonalRelationCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicPersonalRelationCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPersonalRelationCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicPersonalRelationCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicPersonalRelationLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicPersonalRelationMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPersonalRelationLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicPersonalRelationLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicPersonalRelationRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicPersonalRelationRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

  
});
