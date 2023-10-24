var abp = abp || {};
$(function () {
    var ouService = wallee.boc.dataPlane.identity.organizationUnits.organizationUnit;

    function initOuRoleTable(orgId) {
        ouRoleDataTable = $('#unAddedRoleTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: true,
            autoWidth: true,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(function (input) {
                return ouService.getUnaddedRoles(orgId, input);
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
                                        ouService.addRoles(orgId, { roleIds: [data.record.id] })
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
            initOuRoleTable(args.organizationUnitId);
        };

        return {
            initModal: initModal
        };
    };
})