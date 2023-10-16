$(function () {
    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.reports.convertedCusOrgUnit;
    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertedCusOrgUnits/ConvertedCusOrgUnit/CreateByFileModal');
    var downloadFileModal = new abp.ModalManager(abp.appPath + "Reports/Pa/ConvertedCusOrgUnits/ConvertedCusOrgUnit/DownloadFileModal");
    var convertedCusOrgDetailModal = new abp.ModalManager(abp.appPath + "Reports/Pa/ConvertedCuses/ConvertedCus/ConvertedCusDetailsModal");

    var dataTable = $('#ConvertedCusOrgUnitTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                rowAction: {
                    items:
                        [
                            {
                                text: l('View'),
                                visible: abp.auth.isGranted('DataPlane.Reports.ConvertedCus'),
                                action: function (data) {
                                    convertedCusOrgDetailModal.open({ orgidt: data.record.orgIdentity });
                                }
                            }
                        ]
                }
            },
            {
                title: l('ConvertedCusOrgUnitLabel'),
                data: "parentName"
            },
            {
                title: l('ConvertedCusOrgUnitUpOrgidt'),
                data: "parentIdentity"
            },
            {
                title: l('ConvertedCusOrgUnitDataDate'),
                data: "dataDate",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATE_SHORT);
                }
            },
            {
                title: l('ConvertedCusOrgUnitOrgidt'),
                data: "orgIdentity"
            },
            {
                title: l('ConvertedCusOrgUnitFirstLevel'),
                data: "firstLevel"
            },
            {
                title: l('ConvertedCusOrgUnitSecondLevel'),
                data: "secondLevel"
            },
            {
                title: l('ConvertedCusOrgUnitThirdLevel'),
                data: "thirdLevel"
            },
            {
                title: l('ConvertedCusOrgUnitFourthLevel'),
                data: "fourthLevel"
            },
            {
                title: l('ConvertedCusOrgUnitFifthLevel'),
                data: "fifthLevel"
            },
            {
                title: l('ConvertedCusOrgUnitSixthLevel'),
                data: "sixthLevel"
            }
        ]
    }));

    createByFileModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewConvertedCusOrgUnitByFileButton").on("click", function () {
        createByFileModal.open();
    });

    $("#DownloadFileButton").on("click", function () {
        downloadFileModal.open();
    });

    downloadFileModal.onResult(function (event, response) {
        window.open(`/api/app/converted-cus-org-unit/download/${response.responseText}`, "_self");
    });
});
