$(function () {
    var l = abp.localization.getResource("DataPlane");
    var ouService = wallee.boc.dataPlane.identity.organizationUnits.organizationUnit;
    var createModal = new abp.ModalManager(abp.appPath + "Identity/OrganizationUnits/CreateModal");
    var editModal = new abp.ModalManager(abp.appPath + "Identity/OrganizationUnits/EditModal");
    var addRoleToOuModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Identity/OrganizationUnits/AddRoleToOuModal",
        modalClass: "AddRoleToOu"
    });
    var addUserToOuModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Identity/OrganizationUnits/AddUserToOuModal",
        modalClass: "AddUserToOu"
    });
    var currentOu = undefined;
    var ouUserDataTable = undefined;
    var ouRoleDataTable = undefined;

    const initOuUserTable = function () {
        ouUserDataTable = $("#ouUsersTable").DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            order: [[0, "asc"]],
            ajax: abp.libs.datatables.createAjax(function (input) {
                return ouService.getUsers(currentOu, input);
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
                                    visible: abp.auth.isGranted("DataPlane.OrganizationUnit.Delete"),
                                    confirmMessage: function (data) {
                                        return `确认删除当前用户吗?(${data.record.userName})`;
                                    },
                                    action: function (data) {
                                        ouService.deleteUser(currentOu, data.record.id)
                                            .then(function () {
                                                abp.notify.info(l("SuccessfullyDeleted"));
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

    const initOuRoleTable = function () {

        var inputAction = function (requestData, dataTableSettings) {
            return {
                filter: "",
            };
        };

        ouRoleDataTable = $("#ouRolesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                    visible: abp.auth.isGranted("DataPlane.OrganizationUnit.Delete"),
                                    confirmMessage: function (data) {
                                        return `确认删除当前角色吗?(${data.record.name})`;
                                    },
                                    action: function (data) {
                                        ouService.deleteRole(currentOu, data.record.id)
                                            .then(function () {
                                                abp.notify.info(l("SuccessfullyDeleted"));
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

    const checkUserAndRoleInfoPanel = function () {
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

    const initOrgUnitTree = function () {
        ouService.getAllList().done(ouData => {
            $("#ouTree").jstree({
                core: {
                    data: transformData(ouData.items),
                    check_callback: function (operation, node, node_parent, node_position, more) {
                        // operation参数表示操作类型，比如"move_node", "delete_node"等
                        // node参数表示被操作的节点
                        // node_parent参数表示新的父节点
                        // node_position参数表示新的位置
                        // more参数包含了更多的信息
                        if (operation === 'move_node') {
                            if (node.children && node.children.length > 0) {
                                return false;
                            } else {
                                return true;
                            }
                        }
                        return true; // 默认允许所有操作
                    },
                    themes: {
                        icons: true,
                        theme: "default",
                        dots: true,
                        ellipsis: true,
                        stripes: true
                    },
                    animation: 10,
                    dblclick_toggle: true,
                },
                plugins: ["contextmenu", "dnd"],  //启用contextmenu插件
                dhd: {
                    check_while_dragging: true
                },
                contextmenu: {             //配置contextmenu插件
                    items: function (node) {
                        return {
                            view: {
                                label: "查看",
                                icon: "fa fa-search",
                                _disabled: !abp.auth.isGranted("DataPlane.OrganizationUnit"),
                                action: function () {
                                    currentOu = node.id;
                                    $("#currentOuTitle_u").html(node.text);
                                    $("#currentOuTitle_r").html(node.text);
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
                            },
                            edit: {
                                label: "编辑",
                                icon: "fa fa-cog",
                                _disabled: !abp.auth.isGranted("DataPlane.OrganizationUnit.Update"),
                                action: function () {
                                    editModal.open({ organizationUnitId: node.original.id });
                                }
                            },
                            add_child: {
                                label: "添加子机构",
                                icon: "fa fa-plus",
                                _disabled: !abp.auth.isGranted("DataPlane.OrganizationUnit.Update"),
                                action: function () {
                                    createModal.open({ parentId: node.original.id });
                                }
                            },
                            remove_node: {
                                label: "删除",
                                icon: "fa fa-trash",
                                _disabled: !abp.auth.isGranted("DataPlane.OrganizationUnit.Delete"),
                                action: function () {
                                    abp.message.confirm(`确认删除${node.original.text}?`, "删除确认", async (e) => {
                                        if (e === true) {
                                            ouService.delete(node.original.id).done(() => {
                                                refreshOrgUnitTree();
                                                abp.notify.info(l("SuccessfullyDeleted"));
                                            })
                                        }
                                    });
                                }
                            }
                        }
                    }
                }
            });
        });
    }

    const refreshOrgUnitTree = function () {
        ouService.getAllList().done(ouData => {
            let instance = $("#ouTree").jstree(true);
            instance.settings.core.data = transformData(ouData.items)
            instance.refresh();
        });
    }

    const transformData = function (data) {
        let map = {};
        //初始化children
        data.forEach(item => map[item.id] = { id: item.id, text: `${item.displayName}(${item.extraProperties.OrgNo})`, orgNo: item.extraProperties.OrgNo, children: [] });
        //填充children
        data.forEach(item => {
            if (item.parentId) {
                map[item.parentId].children.push({ ...map[item.id], children: map[item.id].children });
            }
        });
        return data.filter(item => item.parentId === null).map(item => ({ ...map[item.id], state: { opened: true }, }));
    }

    initOrgUnitTree();

    checkUserAndRoleInfoPanel();

    $("#ouTree").on('move_node.jstree', function (e, data) {
        if (data.parent !== data.old_parent) {
            let id = data.node.id; // 被移动的节点ID
            let oldParent = data.old_parent;
            let newPparent = data.parent; // 新的父节点ID 
            abp.message.confirm(`确认移动该节点${data.node.original.text}?`, "移动确认", (e) => {
                if (e === true) {
                    ouService.move(id, { parentId: newPparent }).done(() => {
                        abp.notify.info("操作成功");
                    });
                } else {
                    refreshOrgUnitTree();
                    abp.notify.info("你已取消操作");
                }
            });
        }
    });

    $("#addUserToOuBtn").on("click", function (e) {
        addUserToOuModal.open({ organizationUnitId: currentOu });
    });

    $("#addRoleToOuBtn").on("click", function (e) {
        addRoleToOuModal.open({ organizationUnitId: currentOu });
    });

    $("#CreateNewRootOrganizationUnit").on("click", function () {
        createModal.open();
    });

    createModal.onResult(function (e, result) {
        refreshOrgUnitTree();
        abp.notify.success("操作成功");
    });

    editModal.onResult(function (e, result) {
        refreshOrgUnitTree();
        abp.notify.success("操作成功");
    });

    addRoleToOuModal.onResult(function (e, result) {
        ouRoleDataTable.ajax.reload();
        abp.notify.success("操作成功");
    });

    addUserToOuModal.onResult(function (e, result) {
        ouUserDataTable.ajax.reload();
        abp.notify.success("操作成功");
    });
});
