$(function () {
    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.reports.convertedCusOrgUnit;
    var createModal = new abp.ModalManager(abp.appPath + 'Reports/ConvertCusOrgUnits/ConvertedCusOrgUnit/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Reports/ConvertCusOrgUnits/ConvertedCusOrgUnit/EditModal');

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
                                visible: abp.auth.isGranted('DataPlane.ConvertedCusOrgUnit.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DataPlane.ConvertedCusOrgUnit.Delete'),
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
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewConvertedCusOrgUnitButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});