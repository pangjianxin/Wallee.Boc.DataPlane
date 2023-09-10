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
                title: l('CcicPersonalRelationCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicPersonalRelationREL_RL'),
                data: "rEL_RL"
            },
            {
                title: l('CcicPersonalRelationPRINT_CUSNO_YARD'),
                data: "pRINT_CUSNO_YARD"
            },
            {
                title: l('CcicPersonalRelationLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicPersonalRelationREL_DES'),
                data: "rEL_DES"
            },
            {
                title: l('CcicPersonalRelationREL_STRT_DT'),
                data: "rEL_STRT_DT"
            },
            {
                title: l('CcicPersonalRelationREL_END_DT'),
                data: "rEL_END_DT"
            },
            {
                title: l('CcicPersonalRelationREL_STRT_TIME'),
                data: "rEL_STRT_TIME"
            },
            {
                title: l('CcicPersonalRelationREL_END_TIME'),
                data: "rEL_END_TIME"
            },
            {
                title: l('CcicPersonalRelationDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicPersonalRelationCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicPersonalRelationCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPersonalRelationCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicPersonalRelationCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicPersonalRelationLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicPersonalRelationMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicPersonalRelationLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicPersonalRelationLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicPersonalRelationRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicPersonalRelationRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

  
});
