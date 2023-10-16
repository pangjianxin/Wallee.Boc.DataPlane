$(function () {
    var l = abp.localization.getResource('DataPlane');

    var ouHierarchyService = wallee.boc.dataPlane.dictionaries.orgUnitHierachy;
    var createModal = new abp.ModalManager(abp.appPath + 'Dictionaries/OrgUnitHierarchy/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Dictionaries/OrgUnitHierarchy/EditModal');


    const transformData = function (data) {
        let map = {};
        //初始化children
        data.forEach(item => map[item.id] = { id: item.id, text: `${item.name}-${item.orgIdentity}`, type: "default", identity: item.identity, children: [] });
        //填充children
        data.forEach(item => {
            if (item.parentId) {
                map[item.parentId].children.push({ ...map[item.id], children: map[item.id].children });
            }
        });
        return data.filter(item => item.parentId === null).map(item => ({ ...map[item.id], state: { opened: true }, }));
    }
    const initOrgUnitHierarchyTreee = function () {
        ouHierarchyService.getAll().done(items => {
            $("#orgUnitHierarchyTree").jstree({
                core: {
                    data: transformData(items),
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
                plugins: ["contextmenu", "dnd", "types"],  //启用contextmenu插件
                types: {
                    default: {
                        icon: "/images/bank.png",  // 默认节点的图标
                        li_attr: {
                            class: "default_class"  // 默认节点的样式
                        }
                    }
                },
                dhd: {
                    check_while_dragging: true
                },
                contextmenu: {  //配置contextmenu插件
                    items: function (node) {
                        return {
                            edit: {
                                label: "编辑",
                                icon: "fa fa-cog",
                                _disabled: !abp.auth.isGranted("DataPlane.Dictionaries.OrgUnitHierarchy"),
                                action: function () {
                                    editModal.open({ id: node.original.id });
                                }
                            },
                            add_child: {
                                label: "添加子机构",
                                icon: "fa fa-plus",
                                _disabled: !abp.auth.isGranted("DataPlane.Dictionaries.OrgUnitHierarchy"),
                                action: function () {
                                    createModal.open({ parentId: node.original.id });
                                }
                            },
                            remove_node: {
                                label: "删除",
                                icon: "fa fa-trash",
                                _disabled: !abp.auth.isGranted("DataPlane.Dictionaries.OrgUnitHierarchy"),
                                action: function () {
                                    abp.message.confirm(`确认删除${node.original.text}?`, "删除确认", async (e) => {
                                        if (e === true) {
                                            ouHierarchyService.delete(node.original.id).done(() => {
                                                refreshOrgUnitHierarchyTree();
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

    const refreshOrgUnitHierarchyTree = function () {
        ouHierarchyService.getAll().done(items => {
            let instance = $("#orgUnitHierarchyTree").jstree(true);
            instance.settings.core.data = transformData(items)
            instance.refresh();
        });
    }

    initOrgUnitHierarchyTreee();


    $("#orgUnitHierarchyTree").on('move_node.jstree', function (e, data) {
        if (data.parent !== data.old_parent) {
            let id = data.node.id; // 被移动的节点ID
            let oldParent = data.old_parent;
            let newPparent = data.parent; // 新的父节点ID 
            abp.message.confirm(`确认移动该节点${data.node.original.text}?`, "移动确认", (e) => {
                if (e === true) {
                    ouHierarchyService.move(id, { parentId: newPparent }).done(() => {
                        abp.notify.info("操作成功");
                    });
                } else {
                    refreshOrgUnitHierarchyTree();
                    abp.notify.info("你已取消操作");
                }
            });
        }
    });

    createModal.onResult(function () {
        refreshOrgUnitHierarchyTree();
        abp.notify.success("操作成功");
    });

    editModal.onResult(function () {
        refreshOrgUnitHierarchyTree();
        abp.notify.success("操作成功");
    });

    $('#NewOrgUnitHierarchyButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
