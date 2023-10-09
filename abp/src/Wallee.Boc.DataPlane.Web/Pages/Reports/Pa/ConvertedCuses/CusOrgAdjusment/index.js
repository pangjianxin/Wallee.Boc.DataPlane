$(function () {

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.reports.cusOrgAdjusment;
    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertedCuses/CusOrgAdjusment/CreateByFileModal');

    var dataTable = $('#CusOrgAdjusmentTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
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
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DataPlane.Reports.CusOrgAdjusment'),
                                confirmMessage: function (data) {
                                    return l('CusOrgAdjusmentDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete({
                                        cusidt: data.record.cusidt
                                    })
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
                title: "创建日期",
                data: "creationTime",
                render: function (data) {
                    var dataDate = luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATE_SHORT);
                    return `<span class="badge bg-success">${dataDate}</span>`;
                }
            },
            {
                title: "客户号",
                data: "cusidt"
            },
            {
                title: "调整后的机构号",
                data: "orgidt"
            },
        ]
    }));

    createByFileModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCusOrgAdjusmentButton').click(function (e) {
        e.preventDefault();
        createByFileModal.open();
    });
});
