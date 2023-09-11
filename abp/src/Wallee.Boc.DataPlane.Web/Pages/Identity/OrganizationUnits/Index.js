$(function () {
    var l = abp.localization.getResource('DataPlane');
    var ouService = wallee.boc.dataPlane.identity.organizationUnits.organizationUnit;
    var createModal = new abp.ModalManager(abp.appPath + 'Identity/OrganizationUnits/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + "Identity/OrganizationUnits/EditModal");
    var addRoleToOuModal = new abp.ModalManager(abp.appPath + "Identity/OrganizationUnits/AddRoleToOuModal");
    var addUserToOuModal = new abp.ModalManager(abp.appPath + "Identity/OrganizationUnits/AddUserToOuModal");
    var currentOu = null;
    var ouDataTable = null;
    var ouUserDataTable = null;
    var ouRoleDataTable = null;

    function initOuUserTable() {

        var inputAction = function (requestData, dataTableSettings) {
            return {
                filter: "",
            };
        };

        ouUserDataTable = $('#ouUsersTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(function () {
                return ouService.getUsers(currentOu, inputAction);
            }),
            columnDefs: [
                {
                    title: "登录名",
                    data: "userName",
                }, {
                    title: "用户名称",
                    data: "name",
                }, {
                    rowAction: {
                        items:
                            [
                                {
                                    text: "删除",
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit.Delete'),
                                    confirmMessage: function (data) {
                                        return `确认删除当前用户吗?(${data.record.userName})`;
                                    },
                                    action: function (data) {
                                        ouService.deleteUser(currentOu, data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                ouUserDataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
            ]
        }));
    }

    function initOuRoleTable() {

        var inputAction = function (requestData, dataTableSettings) {
            return {
                filter: "",
            };
        };

        ouRoleDataTable = $('#ouRolesTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(function () {
                return ouService.getRoles(currentOu, inputAction);
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
                                    text: "删除",
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit.Delete'),
                                    confirmMessage: function (data) {
                                        return `确认删除当前角色吗?(${data.record.name})`;
                                    },
                                    action: function (data) {
                                        ouService.deleteRole(currentOu, data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                ouRoleDataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
            ]
        }));
    }

    function checkUserAndRoleInfoPanel() {
        if (!currentOu) {
            $("#userInfo").hide();
            $("#roleInfo").hide();
            $("#userInfoEmpty").show();
            $("#roleInfoEmpty").show();
        } else {
            $("#userInfoEmpty").remove();
            $("#roleInfoEmpty").remove();
            $("#userInfo").show();
            $("#roleInfo").show();
        }
    }

    function initOuDataTable() {
        ouDataTable = $('#ousTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: false,
            info: false,
            searching: false,//disable default searchbox
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(ouService.getAllList),
            columnDefs: [

                {
                    title: "机构名称",
                    data: "displayName",
                }, {
                    title: "机构编码",
                    data: "code",
                }, {
                    title: "机构号",
                    data: "extraProperties.OrgNo",
                }, {
                    title: "操作",
                    rowAction: {
                        items:
                            [
                                {
                                    text: "查看",
                                    iconClass: "fas fa-search",
                                    displayNameHtml: false,
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit'),
                                    action: function (data) {
                                        currentOu = data.record.id;
                                        $("#currentOuTitle_u").html(data.record.displayName);
                                        $("#currentOuTitle_r").html(data.record.displayName);
                                        checkUserAndRoleInfoPanel();
                                        if (!ouUserDataTable) {
                                            initOuUserTable();
                                        }
                                        else {
                                            ouUserDataTable.ajax.reload();
                                        }
                                        if (!ouRoleDataTable) {
                                            initOuRoleTable();
                                        }
                                        else {
                                            ouRoleDataTable.ajax.reload();
                                        }
                                    }
                                }, {
                                    text: l('Edit'),
                                    iconClass: "fas fa-edit",
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit.Update'),
                                    confirmMessage: function (data) {
                                        return `确认更新?(${data.record.displayName})`;
                                    },
                                    action: function (data) {
                                        editModal.open({ organizationUnitId: data.record.id });
                                    }
                                }, {
                                    text: "子机构",
                                    iconClass: "fas fa-plus",
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit.Update'),
                                    confirmMessage: function (data) {
                                        return `确认新增子机构?(${data.record.displayName})`;
                                    },
                                    action: function (data) {
                                        createModal.open({ parentId: data.record.id });
                                    }
                                }, {
                                    text: l('Delete'),
                                    iconClass: "fas fa-trash",
                                    visible: abp.auth.isGranted('DataPlane.OrganizationUnit.Delete'),
                                    confirmMessage: function (data) {
                                        return l('FileDeletionConfirmationMessage', data.record.id);
                                    },
                                    action: function (data) {
                                        ouService.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                ouDataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
            ]
        }));
    }

    initOuDataTable();

    checkUserAndRoleInfoPanel();

    $("#addUserToOuBtn").click(function (e) {
        addUserToOuModal.open({ organizationUnitId: currentOu });
    });

    $("#addRoleToOuBtn").click(function (e) {
        addRoleToOuModal.open({ organizationUnitId: currentOu });
    });

    $("#CreateNewRootOrganizationUnit").click(function () {
        createModal.open();
    });

    createModal.onResult(function (e, result) {
        ouDataTable.ajax.reload();
        abp.notify.success("操作成功");
    });

    editModal.onResult(function (e, result) {
        ouDataTable.ajax.reload();
        abp.notify.success("操作成功");
    });

    addRoleToOuModal.onResult(function (e, result) {
        ouRoleDataTable.ajax.reload();
        abp.notify.success("操作成功");
    });

    addUserToOuModal.onResult(function (e, result) {
        ouUserDataTable.ajax.reload();
        abp.notify.success("操作成功");
    })
});
