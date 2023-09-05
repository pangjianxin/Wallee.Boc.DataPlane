$(function () {

    $("#CcicAddressFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#CcicAddressCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#CcicAddressFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/CcicAddressFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.controllers.tDcmp.ccicAddresses.ccicAddress;

    var dataTable = $('#CcicAddressTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('DataPlane.CcicAddress'),
                                action: function (data) {
                                    //data.record.cUSNO
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
                title: l('CcicAddressADDR_TP'),
                data: "aDDR_TP"
            },
            {
                title: l('CcicAddressADDR_SN'),
                data: "aDDR_SN"
            },
            {
                title: l('LGPER_CODE'),
                data: "lGPER_CODE"
            },
            {
                title: l('CcicAddressADDR_LANG'),
                data: "aDDR_LANG"
            },
            {
                title: l('CcicAddressCNRG'),
                data: "cNRG"
            },
            {
                title: l('CcicAddressPRVC_MNCP'),
                data: "pRVC_MNCP"
            },
            {
                title: l('CcicAddressCITY'),
                data: "cITY"
            },
            {
                title: l('CcicAddressCNTY'),
                data: "cNTY"
            },
            {
                title: l('CcicAddressADDR1'),
                data: "aDDR1"
            },
            {
                title: l('CcicAddressPSALC'),
                data: "pSALC"
            },
            {
                title: l('CcicAddressRTNPT_FLAG'),
                data: "rTNPT_FLAG"
            },
            {
                title: l('CcicAddressPS_NAME'),
                data: "pS_NAME"
            },
            {
                title: l('CcicAddressCTY_LNG_CODE'),
                data: "cTY_LNG_CODE"
            },
            {
                title: l('CcicAddressCTY_RGON_RSK_GRD_CODE'),
                data: "cTY_RGON_RSK_GRD_CODE"
            },
            {
                title: l('CcicAddressRLTV_UNNPY_URBN_CODE'),
                data: "rLTV_UNNPY_URBN_CODE"
            },
            {
                title: l('CcicAddressBKCD_URBN_CODE'),
                data: "bKCD_URBN_CODE"
            },
            {
                title: l('CcicAddressREL_TP_CODE'),
                data: "rEL_TP_CODE"
            },
            {
                title: l('CcicAddressREL_STRT_DT'),
                data: "rEL_STRT_DT"
            },
            {
                title: l('CcicAddressREL_END_DT'),
                data: "rEL_END_DT"
            },
            {
                title: l('CcicAddressREL_STRT_TIME'),
                data: "rEL_STRT_TIME"
            },
            {
                title: l('CcicAddressREL_END_TIME'),
                data: "rEL_END_TIME"
            },
            {
                title: l('CcicAddressREL_DES'),
                data: "rEL_DES"
            },
            {
                title: l('CcicAddressDEL_FLAG'),
                data: "dEL_FLAG"
            },
            {
                title: l('CcicAddressCRTR_TLR_REFNO'),
                data: "cRTR_TLR_REFNO"
            },
            {
                title: l('CcicAddressCRT_TLR_ORG_REFNO'),
                data: "cRT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAddressCRT_DTTM'),
                data: "cRT_DTTM"
            },
            {
                title: l('CcicAddressCUR_ACDT_PERI'),
                data: "cUR_ACDT_PERI"
            },
            {
                title: l('CcicAddressLTST_MOD_TLR_REFNO'),
                data: "lTST_MOD_TLR_REFNO"
            },
            {
                title: l('CcicAddressMOD_TLR_ORG_REFNO'),
                data: "mOD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAddressLAST_MNT_STS_CODE'),
                data: "lAST_MNT_STS_CODE"
            },
            {
                title: l('CcicAddressLAST_MOD_DTTM'),
                data: "lAST_MOD_DTTM"
            },
            {
                title: l('CcicAddressRCRD_VRSN_SN'),
                data: "rCRD_VRSN_SN"
            },
        ]
    }));
});
