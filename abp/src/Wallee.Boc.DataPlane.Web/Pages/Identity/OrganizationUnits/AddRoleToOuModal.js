var abp = abp || {};
$(function () {
    var ouService = wallee.boc.dataPlane.identity.organizationUnits.organizationUnit;
    var inputAction = function (requestData, dataTableSettings) {
        return {
            filter: "",
        };
    };
    function initOuRoleTable() {
        ouRoleDataTable = $('#unAddedRoleTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(function () {
                return ouService.getUnaddedRoles(organizationUnitId, inputAction);
            }),
            columnDefs: [
                {
                    title: "角色名",
                    data: "name",
                }, {
                    rowAction: {
                        items:
                            [
                                {
                                    text: "添加",
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit.ManageRoles'),
                                    confirmMessage: function (data) {
                                        return `确认要添加该角色?(${data.record.name})`;
                                    },
                                    action: function (data) {
                                        ouService.addRoles(organizationUnitId, { RoleIds: [data.record.id] })
                                    }
                                }
                            ]
                    }
                },
            ]
        }));
    }
    abp.modals.AddRoleToOu = function () {
        function initModal(modalManager, args) {
            console.log("??");
            initOuRoleTable();
        };

        return {
            initModal: initModal
        };
    };
})