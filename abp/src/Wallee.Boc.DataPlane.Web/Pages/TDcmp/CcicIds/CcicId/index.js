$(function () {

    

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicIds.ccicId;
   

    var dataTable = $('#CcicIdTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicIdCRDT_TP'),
                data: "crdT_TP"
            },
            {
                title: l('CcicIdCRDT_SN'),
                data: "crdT_SN"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicIdCRAD'),
                data: "crad"
            },
            {
                title: l('CcicIdCRDT_ATR'),
                data: "crdT_ATR"
            },
            {
                title: l('CcicIdOTHR_CRTY_NOTE'),
                data: "othR_CRTY_NOTE"
            },
            {
                title: l('CcicIdCRDT_SGIS_ADDR4'),
                data: "crdT_SGIS_ADDR4"
            },
            {
                title: l('CcicIdISSCT_AHR_LO'),
                data: "isscT_AHR_LO"
            },
            {
                title: l('CcicIdCRDT_SGIS_AHR_NAME'),
                data: "crdT_SGIS_AHR_NAME"
            },
            {
                title: l('CcicIdCRDT_SGIS_DT'),
                data: "crdT_SGIS_DT"
            },
            {
                title: l('CcicIdCRDT_EXP_DT'),
                data: "crdT_EXP_DT"
            },
            {
                title: l('CcicIdCRDT_PRM_VLD_FLAG'),
                data: "crdT_PRM_VLD_FLAG"
            },
            {
                title: l('CcicIdANINS_DT'),
                data: "aninS_DT"
            },
            {
                title: l('CcicIdCRDT_IMAGE_ID'),
                data: "crdT_IMAGE_ID"
            },
            {
                title: l('CcicIdID_INF_DES'),
                data: "iD_INF_DES"
            },
            {
                title: l('CcicIdCRDT_STS'),
                data: "crdT_STS"
            },
            {
                title: l('CcicIdDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicIdCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicIdCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicIdCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicIdCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicIdLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicIdMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicIdLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicIdLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicIdRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicIdRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));

  
});
