$(function () {
    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.reports.convertedCusOrgUnit;
    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertCusOrgUnits/ConvertedCusOrgUnit/CreateByFileModal');
    var downloadFileModal = new abp.ModalManager(abp.appPath + "Reports/Pa/ConvertCusOrgUnits/ConvertedCusOrgUnit/DownloadFileModal");

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
                                text: l('Edit'),
                                visible: abp.auth.isGranted('DataPlane.Reports.ConvertedCusOrgUnit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DataPlane.Reports.ConvertedCusOrgUnit'),
                                confirmMessage: function (data) {
                                    return l('ConvertedCusOrgUnitDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('ConvertedCusOrgUnitLabel'),
                data: "label"
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
                title: l('ConvertedCusOrgUnitUpOrgidt'),
                data: "upOrgidt"
            },
            {
                title: l('ConvertedCusOrgUnitOrgidt'),
                data: "orgidt"
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
            },
            {
                title: "最后维护日期",
                data: "lastModificationTime",
                render: function (data) {
                    var dataDate = luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toFormat("yyyy-MM-dd HH:mm:ss");
                    return `<span class="badge bg-success">${dataDate}</span>`;
                }
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
        console.log(response.responseText);
        window.open(`/api/app/converted-cus-org-unit/download/${response.responseText}`, "_self");
    });
});
