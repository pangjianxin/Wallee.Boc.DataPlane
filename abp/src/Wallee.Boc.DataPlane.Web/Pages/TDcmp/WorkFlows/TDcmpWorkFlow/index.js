$(function () {

    $("#TDcmpWorkFlowFilter :input").on('input', function () {
        dataTable.ajax.reload();
    });

    //After abp v7.2 use dynamicForm 'column-size' instead of the following settings
    //$('#TDcmpWorkFlowCollapse div').addClass('col-sm-3').parent().addClass('row');

    var getFilter = function () {
        var input = {};
        $("#TDcmpWorkFlowFilter")
            .serializeArray()
            .forEach(function (data) {
                if (data.value != '') {
                    input[abp.utils.toCamelCase(data.name.replace(/TDcmpWorkFlowFilter./g, ''))] = data.value;
                }
            })
        return input;
    };

    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.tDcmp.workFlows.tDcmpWorkFlow;
    var createModal = new abp.ModalManager(abp.appPath + 'TDcmp/WorkFlows/TDcmpWorkFlow/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'TDcmp/WorkFlows/TDcmpWorkFlow/EditModal');

    var dataTable = $('#TDcmpWorkFlowTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList,getFilter),
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
                data: "status"
            },
            {
                title: l('TDcmpWorkFlowDataDate'),
                data: "dataDate"
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
});
