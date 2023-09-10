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
                                text: "查看",
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
                data: "cusno"
            },
            {
                title: l('CcicAddressADDR_TP'),
                data: "addR_TP"
            },
            {
                title: l('CcicAddressADDR_SN'),
                data: "addR_SN"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicAddressADDR_LANG'),
                data: "addR_LANG"
            },
            {
                title: l('CcicAddressCNRG'),
                data: "cnrg"
            },
            {
                title: l('CcicAddressPRVC_MNCP'),
                data: "prvC_MNCP"
            },
            {
                title: l('CcicAddressCITY'),
                data: "city"
            },
            {
                title: l('CcicAddressCNTY'),
                data: "cnty"
            },
            {
                title: l('CcicAddressADDR1'),
                data: "addR1"
            },
            {
                title: l('CcicAddressPSALC'),
                data: "psalc"
            },
            {
                title: l('CcicAddressRTNPT_FLAG'),
                data: "rtnpT_FLAG"
            },
            {
                title: l('CcicAddressPS_NAME'),
                data: "pS_NAME"
            },
            {
                title: l('CcicAddressCTY_LNG_CODE'),
                data: "ctY_LNG_CODE"
            },
            {
                title: l('CcicAddressCTY_RGON_RSK_GRD_CODE'),
                data: "ctY_RGON_RSK_GRD_CODE"
            },
            {
                title: l('CcicAddressRLTV_UNNPY_URBN_CODE'),
                data: "rltV_UNNPY_URBN_CODE"
            },
            {
                title: l('CcicAddressBKCD_URBN_CODE'),
                data: "bkcD_URBN_CODE"
            },
            {
                title: l('CcicAddressREL_TP_CODE'),
                data: "reL_TP_CODE"
            },
            {
                title: l('CcicAddressREL_STRT_DT'),
                data: "reL_STRT_DT",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicAddressREL_END_DT'),
                data: "reL_END_DT",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicAddressREL_STRT_TIME'),
                data: "reL_STRT_TIME",
            },
            {
                title: l('CcicAddressREL_END_TIME'),
                data: "reL_END_TIME"
            },
            {
                title: l('CcicAddressREL_DES'),
                data: "reL_DES"
            },
            {
                title: l('CcicAddressDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicAddressCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicAddressCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAddressCRT_DTTM'),
                data: "crT_DTTM"
            },
            {
                title: l('CcicAddressCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI"
            },
            {
                title: l('CcicAddressLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicAddressMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicAddressLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicAddressLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM"
            },
            {
                title: l('CcicAddressRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
        ]
    }));
});
