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
                title: l('CcicIdCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicIdCRDT_TP'),
                data: "cRDT_TP"
            },
            {
                title: l('CcicIdCRDT_SN'),
                data: "cRDT_SN"
            },
            {
                title: l('CcicIdLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicIdCRAD'),
                data: "cRAD"
            },
            {
                title: l('CcicIdCRDT_ATR'),
                data: "cRDT_ATR"
            },
            {
                title: l('CcicIdOTHR_CRTY_NOTE'),
                data: "oTHR_CRTY_NOTE"
            },
            {
                title: l('CcicIdCRDT_SGIS_ADDR4'),
                data: "cRDT_SGIS_ADDR4"
            },
            {
                title: l('CcicIdISSCT_AHR_LO'),
                data: "iSSCT_AHR_LO"
            },
            {
                title: l('CcicIdCRDT_SGIS_AHR_NAME'),
                data: "cRDT_SGIS_AHR_NAME"
            },
            {
                title: l('CcicIdCRDT_SGIS_DT'),
                data: "cRDT_SGIS_DT"
            },
            {
                title: l('CcicIdCRDT_EXP_DT'),
                data: "cRDT_EXP_DT"
            },
            {
                title: l('CcicIdCRDT_PRM_VLD_FLAG'),
                data: "cRDT_PRM_VLD_FLAG"
            },
            {
                title: l('CcicIdANINS_DT'),
                data: "aNINS_DT"
            },
            {
                title: l('CcicIdCRDT_IMAGE_ID'),
                data: "cRDT_IMAGE_ID"
            },
            {
                title: l('CcicIdID_INF_DES'),
                data: "iD_INF_DES"
            },
            {
                title: l('CcicIdCRDT_STS'),
                data: "cRDT_STS"
            },
            {
                title: l('CcicIdDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicIdCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicIdCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicIdCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicIdCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicIdLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicIdMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicIdLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicIdLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicIdRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicIdRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

  
});
