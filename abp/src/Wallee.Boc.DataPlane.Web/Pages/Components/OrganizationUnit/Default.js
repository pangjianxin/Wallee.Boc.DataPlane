(function () {
    abp.widgets.OrganizationUnit = function ($wrapper) {

        var ouService = wallee.boc.dataPlane.identity.organizationUnits.organizationUnit;

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
                                        abp.event.trigger("organizationUnit:view", { currentOu: node.id });
                                        //currentOu = node.id;
                                        //$("#currentOuTitle_u").html(node.text);
                                        //$("#currentOuTitle_r").html(node.text);
                                        //checkUserAndRoleInfoPanel();
                                        //if (!ouUserDataTable) {
                                        //    initOuUserTable();
                                        //}
                                        //else {
                                        //    ouUserDataTable.ajax.reload();
                                        //}
                                        //if (!ouRoleDataTable) {
                                        //    initOuRoleTable();
                                        //}
                                        //else {
                                        //    ouRoleDataTable.ajax.reload();
                                        //}
                                    }
                                },
                                edit: {
                                    label: "编辑",
                                    icon: "fa fa-cog",
                                    _disabled: !abp.auth.isGranted("DataPlane.OrganizationUnit.Update"),
                                    action: function () {
                                        /* editModal.open({ organizationUnitId: node.original.id });*/
                                        abp.event.trigger("organizationUnit:edit", { currentOu: node.id });
                                    }
                                },
                                add_child: {
                                    label: "添加子机构",
                                    icon: "fa fa-plus",
                                    _disabled: !abp.auth.isGranted("DataPlane.OrganizationUnit.Update"),
                                    action: function () {
                                        /*createModal.open({ parentId: node.original.id });*/
                                        abp.event.trigger("organizationUnit:add-child", { currenteOu: node.id });
                                    }
                                },
                                remove_node: {
                                    label: "删除",
                                    icon: "fa fa-trash",
                                    _disabled: !abp.auth.isGranted("DataPlane.OrganizationUnit.Delete"),
                                    action: function () {
                                        //abp.message.confirm(`确认删除${node.original.text}?`, "删除确认", async (e) => {
                                        //    if (e === true) {
                                        //        ouService.delete(node.original.id).done(() => {
                                        //            refreshOrgUnitTree();
                                        //            abp.notify.info(l("SuccessfullyDeleted"));
                                        //        })
                                        //    }
                                        //});
                                        abp.event.trigger("organizationUnit:delete", { currentOu: node.id });
                                    }
                                }
                            }
                        }
                    }
                });
            });
        }

        const transformData = function (data) {
            let map = {};
            //初始化children
            data.forEach(item => map[item.id] = { id: item.id, text: item.displayName, orgNo: item.extraProperties.OrgNo, children: [] });
            //填充children
            data.forEach(item => {
                if (item.parentId) {
                    map[item.parentId].children.push({ ...map[item.id], children: map[item.id].children });
                }
            });
            return data.filter(item => item.parentId === null).map(item => ({ ...map[item.id], state: { opened: true }, }));
        }

        let getFilters = function () {
            return {

            };
        }

        let refresh = function (filters) {

        };

        let init = async function (filters) {
            initOrgUnitTree();
        };

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };
})();