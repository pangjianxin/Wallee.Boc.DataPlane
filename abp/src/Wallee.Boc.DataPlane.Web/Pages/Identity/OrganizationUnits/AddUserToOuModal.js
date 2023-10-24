var abp = abp || {};
$(function () {
    var ouService = wallee.boc.dataPlane.identity.organizationUnits.organizationUnit;
    var inputAction = function (requestData, dataTableSettings) {
        return {
            id: organizationUnitId,
        };
    };
    function initOuUserTable() {
        ouUserDataTable = $('#unAddedUsersTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(ouService.getUnaddedUsers, inputAction),
            columnDefs: [
                {
                    title: "登录名",
                    data: "userName",
                }, {
                    title: "用户名",
                    data: "name",
                }, {
                    rowAction: {
                        items:
                            [
                                {
                                    text: "添加",
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit.ManageUsers'),
                                    confirmMessage: function (data) {
                                        return `确认要添加该用户?(${data.record.name})`;
                                    },
                                    action: function (data) {
                                        ouService.addUsers(organizationUnitId, { userIds: [data.record.id] })
                                    }
                                }
                            ]
                    }
                },
            ]
        }));
    }
    abp.modals.AddUserToOu = function () {
        function initModal(modalManager, args) {

            initOuUserTable();
        };

        return { initModal };
    }
})