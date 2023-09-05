$(function () {

    $("#CcicBasicFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#CcicBasicCollapse div').addClass('col-sm-3').parent().addClass('row');
    console.log(abp.timing);
    var getFilter = function () {
        var input = {};
        $("#CcicBasicFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/CcicBasicFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.controllers.tDcmp.ccicBasics.ccicBasic;

    var dataTable = $('#CcicBasicTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: "²é¿´",
                                visible: abp.auth.isGranted('DataPlane.CcicBasic'),
                                action: function (data) {
                                    //data.record.cUSNO,
                                }
                            }
                        ]
                }
            },
            {
                title: l('CUSNO'),
                data: "cUSNO"
            },
            {
                title: l('LGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicBasicAL_CODE'),
                data: "aL_CODE"
            },
            {
                title: l('CcicBasicCOMM_LNG'),
                data: "cOMM_LNG"
            },
            {
                title: l('CcicBasicCUSRL_TE_CHNL'),
                data: "cUSRL_TE_CHNL"
            },
            {
                title: l('CcicBasicCSMGR_TLR_REFNO'),
                data: "cSMGR_TLR_REFNO"
            },
            {
                title: l('CcicBasicOPNAC_ORG_REFNO'),
                data: "oPNAC_ORG_REFNO"
            },
            {
                title: l('CcicBasicBLG_ORG_REFNO'),
                data: "bLG_ORG_REFNO"
            },
            {
                title: l('CcicBasicOPNAC_DT'),
                data: "oPNAC_DT"
            },
            {
                title: l('CcicBasicCLS_DT'),
                data: "cLS_DT"
            },
            {
                title: l('CcicBasicLAST_CNMDT_PERI'),
                data: "lAST_CNMDT_PERI"
            },
            {
                title: l('CcicBasicCSTST'),
                data: "cSTST"
            },
            {
                title: l('CcicBasicDSABL_REASN'),
                data: "dSABL_REASN"
            },
            {
                title: l('CcicBasicDSABL_REASN_NOTE'),
                data: "dSABL_REASN_NOTE"
            },
            {
                title: l('CcicBasicPART_RL_TP_CODE'),
                data: "pART_RL_TP_CODE"
            },
            {
                title: l('CcicBasicDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicBasicCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicBasicCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicBasicCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicBasicCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicBasicLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicBasicMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicBasicLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicBasicLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicBasicRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
            {
                title: l('CcicBasicRCRD_CLNUP_STSCD'),
                data: "rCRD_CLNUP_STSCD"
            },
        ]
    }));
});
