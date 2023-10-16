(function () {
    abp.widgets.ConvertedCusDetail = function ($wrapper) {
        var l = abp.localization.getResource('DataPlane');
        var service = wallee.boc.dataPlane.reports.convertedCus;
        let getFilter;
        let dataTable;
        const initTable = function (filters) {
            getFilter = filters;
            dataTable = $('#ConvertedCusTable').DataTable(abp.libs.datatables.normalizeConfiguration({
                processing: true,
                serverSide: true,
                paging: true,
                searching: true,//disable default searchbox
                autoWidth: false,
                scrollCollapse: true,
                order: [[0, "asc"]],
                ajax: abp.libs.datatables.createAjax(service.getList, function () { return getFilter; }),
                columnDefs: [
                    {
                        title: "数据日期",
                        data: "dataDate",
                        render: function (data) {
                            var dataDate = luxon
                                .DateTime
                                .fromISO(data, { locale: abp.localization.currentCulture.name })
                                .toLocaleString(luxon.DateTime.DATE_SHORT);
                            return `<span class="badge bg-success">${dataDate}</span>`;
                        }
                    },
                    {
                        title: "客户号",
                        data: "cusIdentity"
                    },
                    {
                        title: "客户名称",
                        data: "cusName"
                    },
                    {
                        title: "存款年日均",
                        data: "depYavBal"
                    },
                    {
                        title: "存款时点",
                        data: "depCurBal"
                    },
                    {
                        title: "机构号",
                        data: "orgIdentity"
                    },
                    {
                        title: "机构名称",
                        data: "orgName"
                    }
                ]
            }));
        }

        var getFilters = function (filter) {

        }

        var refresh = function (filters) {
            getFilter = filters;
            console.log(filters);
            dataTable.ajax.reload();
        };

        var init = function (filters) {
            console.log("widgets init");
            initTable(filters);
        }

        return {
            getFilters,
            init,
            refresh
        };
    };
})();