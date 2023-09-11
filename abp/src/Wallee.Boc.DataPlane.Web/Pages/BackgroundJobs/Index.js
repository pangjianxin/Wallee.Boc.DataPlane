$(function () {
    var l = abp.localization.getResource('DataPlane');

    var _editModal = new abp.ModalManager({
        viewUrl: "/BackgroundJobs/UpdateModal"
    });

    var inputAction = function (requestData, dataTableSettings) {
        return {
            filter: $('#tableSearchInput').val()
        };
    };

    var _backgroundJobAppService = wallee.boc.dataPlane.backgroundJobs.backgroundJob;

    var dataTable = $('#backgroundJobsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            pagingType: 'simple',
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(_backgroundJobAppService.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items: [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted("DataPlane.BackgroundJobs.Update"),
                                icon: "fas fa-edit",
                                action: function (data) {
                                    _editModal.open({ id: data.record.id })
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted("DataPlane.BackgroundJobs.Delete"),
                                icon: "fas fa-trash",
                                confirmMessage: function (data) {
                                    return `确认要删除任务->${data.record.jobName}<-吗?`;
                                },
                                action: function (data) {
                                    _backgroundJobAppService.delete(data.record.id, { type: 'DELETE' })
                                        .then(function () {
                                            abp.notify.success("删除成功");
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    },

                }, {
                    title: "任务名称",
                    data: "jobName",
                }, {
                    title: "重试次数",
                    data: "tryCount",
                }, {
                    title: "下次重试时间",
                    data: "nextTryTime",
                    render: function (data) {
                        if (!data) {
                            return "暂无";
                        }
                        return luxon
                            .DateTime
                            .fromISO(data, { locale: abp.localization.currentCulture.name })
                            .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }, {
                    title: "上次重试时间",
                    data: "lastTryTime",
                    render: function (data) {
                        if (!data) {
                            return "暂无";
                        }
                        return luxon
                            .DateTime
                            .fromISO(data, { locale: abp.localization.currentCulture.name })
                            .toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }, {
                    title: "是否已放弃",
                    data: "isAbandoned",
                    render: function (data) {
                        var color = data === true ? 'bg-danger' : 'bg-success';
                        var text = data === true ? '是' : '否';
                        return `<span class='badge ${color}'>${text}</span>`;
                    }
                }, {
                    title: "优先级",
                    data: "priority",
                }, {
                    title: "创建日期",
                    data: "creationTime",
                    render: function (data) {
                        if (!data) {
                            return "暂无";
                        }
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }, {
                    title: "任务参数",
                    data: "jobArgs",
                    render: function (e) {
                        var json = JSON.stringify(e, null, 4);
                        //数据字符超过30截取
                        if (json.length > 30) {
                            return "<span title='" + json + "' style='text-decoration: none;'>" + json.trim().substring(0, 30) + "..." + "</span>";
                        } else {
                            return json;
                        }
                    }
                }
            ]
        })
    );

    _editModal.onResult(function (e, result) {
        dataTable.ajax.reload();
        abp.notify.success("操作成功");
    })
});
