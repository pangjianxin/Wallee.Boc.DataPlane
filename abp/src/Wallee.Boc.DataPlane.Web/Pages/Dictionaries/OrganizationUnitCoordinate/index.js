$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.dictionaries.organizationUnitCoordinate;
    var createModal = new abp.ModalManager(abp.appPath + 'Dictionaries/OrganizationUnitCoordinate/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dictionaries/OrganizationUnitCoordinate/EditModal');

    var dataTable = $('#OrganizationUnitCoordinateTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('DataPlane.Dictionaries.OrganizationUnitCoordinate'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DataPlane.Dictionaries.OrganizationUnitCoordinate'),
                                confirmMessage: function (data) {
                                    return l('OrganizationUnitCoordinateDeletionConfirmationMessage', data.record.id);
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
                title: l('OrganizationUnitCoordinateOrgName'),
                data: "orgName"
            },
            {
                title: l('OrganizationUnitCoordinateOrgNo'),
                data: "orgNo"
            },
            {
                title: l('OrganizationUnitCoordinateLatitude'),
                data: "latitude"
            },
            {
                title: l('OrganizationUnitCoordinateLongitude'),
                data: "longitude"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewOrganizationUnitCoordinateButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
