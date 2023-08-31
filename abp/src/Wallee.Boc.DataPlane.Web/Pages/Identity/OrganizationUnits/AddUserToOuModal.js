$(function () {
    var ouService = wallee.boc.vote.organizationUnits.organizationUnit;

    var inputAction = function (requestData, dataTableSettings) {
        console.log(requestData);
        console.log(dataTableSettings);
        return {
            filter: "admin",
        };
    };
    function initOuUserTable() {
        ouUserDataTable = $('#unAddedUsersTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: true,
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(function () {
                return ouService.getUnaddedUsers(organizationUnitId, inputAction);
            }),
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
                                    visible: abp.auth.isGranted('Vote.OrganizationUnit.ManageUsers'),
                                    confirmMessage: function (data) {
                                        return `确认要添加该用户?(${data.record.name})`;
                                    },
                                    action: function (data) {
                                        ouService.addUsers(organizationUnitId, { UserIds: [data.record.id] })
                                    }
                                }
                            ]
                    }
                },
            ]
        }));
    }

    initOuUserTable();
})