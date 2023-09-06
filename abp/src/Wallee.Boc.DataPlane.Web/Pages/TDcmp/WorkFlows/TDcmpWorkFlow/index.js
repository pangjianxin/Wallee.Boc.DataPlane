$(function () {

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.controllers.tDcmp.workFlows.tDcmpWorkFlow;
    var createModal = new abp.ModalManager(abp.appPath + 'TDcmp/WorkFlows/TDcmpWorkFlow/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'TDcmp/WorkFlows/TDcmpWorkFlow/EditModal');

    var dataTable = $('#TDcmpWorkFlowTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('DataPlane.TDcmpWorkFlow.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('DataPlane.TDcmpWorkFlow.Delete'),
                                confirmMessage: function (data) {
                                    return l('TDcmpWorkFlowDeletionConfirmationMessage', data.record.id);
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
                title: l('TDcmpWorkFlowStatus'),
                data: "status",
                render: function (data) {
                    console.log(data);
                    let color = data === 1 ? "success" : "danger";
                    return `<span class='badge bg-${color}'>${l('Enum:TDcmpStatus:' + data)}</span>`;
                }
            },
            {
                title: "Cron表达式",
                data: "cronExpression"
            },
            {
                title: l('TDcmpWorkFlowDataDate'),
                data: "dataDate",
                render: function (data) {
                    return luxon.DateTime.fromISO(data, { locale: abp.localization.currentCulture.name }).toLocaleString(luxon.DateTime.DATE_SHORT);
                }
            },
            {
                title: l('TDcmpWorkFlowComment'),
                data: "comment"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTDcmpWorkFlowButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    var tDcmpWorkFlowWidget = new abp.WidgetManager({
        wrapper: '#tDcmpWorkFlowWidget',
        filterCallback: function () {
            var date = $('#localAuthStatisticEndTime').val();
            return { endTime: date }
        }
    });
    tDcmpWorkFlowWidget.init();
});
