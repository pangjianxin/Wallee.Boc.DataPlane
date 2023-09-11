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

    var service = wallee.boc.dataPlane.tDcmp.ccicBasics.ccicBasic;

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
                                text: "查看",
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
                data: "cusno"
            },
            {
                title: l('LGPER_CODE'),
                data: "lgpeR_CODE"
            },
            {
                title: l('CcicBasicAL_CODE'),
                data: "aL_CODE"
            },
            {
                title: l('CcicBasicCOMM_LNG'),
                data: "comM_LNG"
            },
            {
                title: l('CcicBasicCUSRL_TE_CHNL'),
                data: "cusrL_TE_CHNL"
            },
            {
                title: l('CcicBasicCSMGR_TLR_REFNO'),
                data: "csmgR_TLR_REFNO"
            },
            {
                title: l('CcicBasicOPNAC_ORG_REFNO'),
                data: "opnaC_ORG_REFNO"
            },
            {
                title: l('CcicBasicBLG_ORG_REFNO'),
                data: "blG_ORG_REFNO"
            },
            {
                title: l('CcicBasicOPNAC_DT'),
                data: "opnaC_DT",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicBasicCLS_DT'),
                data: "clS_DT",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicBasicLAST_CNMDT_PERI'),
                data: "lasT_CNMDT_PERI",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicBasicCSTST'),
                data: "cstst"
            },
            {
                title: l('CcicBasicDSABL_REASN'),
                data: "dsabL_REASN"
            },
            {
                title: l('CcicBasicDSABL_REASN_NOTE'),
                data: "dsabL_REASN_NOTE"
            },
            {
                title: l('CcicBasicPART_RL_TP_CODE'),
                data: "parT_RL_TP_CODE"
            },
            {
                title: l('CcicBasicDEL_FLAG'),
                data: "deL_FLAG"
            },
            {
                title: l('CcicBasicCRTR_TLR_REFNO'),
                data: "crtR_TLR_REFNO"
            },
            {
                title: l('CcicBasicCRT_TLR_ORG_REFNO'),
                data: "crT_TLR_ORG_REFNO"
            },
            {
                title: l('CcicBasicCRT_DTTM'),
                data: "crT_DTTM",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicBasicCUR_ACDT_PERI'),
                data: "cuR_ACDT_PERI",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicBasicLTST_MOD_TLR_REFNO'),
                data: "ltsT_MOD_TLR_REFNO"
            },
            {
                title: l('CcicBasicMOD_TLR_ORG_REFNO'),
                data: "moD_TLR_ORG_REFNO"
            },
            {
                title: l('CcicBasicLAST_MNT_STS_CODE'),
                data: "lasT_MNT_STS_CODE"
            },
            {
                title: l('CcicBasicLAST_MOD_DTTM'),
                data: "lasT_MOD_DTTM",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                }
            },
            {
                title: l('CcicBasicRCRD_VRSN_SN'),
                data: "rcrD_VRSN_SN"
            },
            {
                title: l('CcicBasicRCRD_CLNUP_STSCD'),
                data: "rcrD_CLNUP_STSCD"
            },
        ]
    }));
});
