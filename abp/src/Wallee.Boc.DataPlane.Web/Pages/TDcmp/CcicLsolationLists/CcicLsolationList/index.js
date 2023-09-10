$(function () {


    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.ccicLsolationLists.ccicLsolationList;
    var createModal = new abp.ModalManager(abp.appPath + 'TDcmp/CcicLsolationLists/CcicLsolationList/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'TDcmp/CcicLsolationLists/CcicLsolationList/EditModal');

    var dataTable = $('#CcicLsolationListTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('CcicLsolationListCUSNO'),
                data: "cUSNO"
            },
            {
                title: l('CcicLsolationListLGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicLsolationListQUARN_STS'),
                data: "qUARN_STS"
            },
            {
                title: l('CcicLsolationListQUARN_TP'),
                data: "qUARN_TP"
            },
            {
                title: l('CcicLsolationListQUARN_REASN'),
                data: "qUARN_REASN"
            },
            {
                title: l('CcicLsolationListDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicLsolationListCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicLsolationListCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicLsolationListCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicLsolationListCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicLsolationListLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicLsolationListMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicLsolationListLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicLsolationListLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicLsolationListRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicLsolationListRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));

  
});
