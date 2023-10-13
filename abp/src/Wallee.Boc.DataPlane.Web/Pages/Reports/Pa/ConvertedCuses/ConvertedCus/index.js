$(function () {



    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.reports.convertedCus;
    console.log(service);
    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertedCuses/ConvertedCus/CreateByFileModal');

    var dataTable = $('#ConvertedCusTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: true,//disable default searchbox
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
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
                data: "cusidt"
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
                data: "orgidt"
            },
            {
                title: "机构名称",
                data: "orgName"
            }
        ]
    }));

    createByFileModal.onResult(function () {
        dataTable.ajax.reload();
    });


    $('#NewConvertedCusButton').click(function (e) {
        e.preventDefault();
        createByFileModal.open();
    });
});
