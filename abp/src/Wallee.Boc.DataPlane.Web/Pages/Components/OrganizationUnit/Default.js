(function () {
    abp.widgets.OrganizationUnit = function ($wrapper) {
        var ouService = wallee.boc.dataPlane.identity.organizationUnits.organizationUnit;
        const initOrgUnitTree = function () {
            ouService.getVisibleOrganizationUnits().done(ouData => {
                $("#ouTree").jstree({
                    core: {
                        data: transformData(ouData.items),
                        check_callback: function (operation, node, node_parent, node_position, more) {
                            // operation参数表示操作类型，比如"move_node", "delete_node"等
                            // node参数表示被操作的节点
                            // node_parent参数表示新的父节点
                            // node_position参数表示新的位置
                            // more参数包含了更多的信息
                            return true; // 默认允许所有操作
                        },
                        themes: {
                            icons: true,
                            theme: "default",
                            dots: true,
                            ellipsis: true,
                            stripes: false
                        },
                        animation: 10,
                        dblclick_toggle: true,
                    },
                    plugins: ["contextmenu"],  //启用contextmenu插件

                    contextmenu: {             //配置contextmenu插件
                        items: function (node) {
                            return {
                                view: {
                                    label: "查看",
                                    icon: "fa fa-search",
                                    _disabled: () => node.children && node.children.length > 0,
                                    action: function () {

                                        abp.event.trigger("organizationUnit:view",
                                            {
                                                currentOuId: node.original.id,
                                                currentOuIdentity: node.original.orgIdentity,
                                                currentOuCode: node.original.text
                                            });
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
            data.forEach(item => map[item.id] =
            {
                id: item.id,
                text: item.displayName,
                icon: "fas fa-home",
                orgIdentity: item.extraProperties.OrgNo,
                children: []
            });
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