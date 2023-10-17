$(function () {
    var l = abp.localization.getResource('DataPlane');

    var service = wallee.boc.dataPlane.reports.convertedCusOrgUnit;
    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertedCusOrgUnits/ConvertedCusOrgUnit/CreateByFileModal');
    var downloadFileModal = new abp.ModalManager(abp.appPath + "Reports/Pa/ConvertedCusOrgUnits/ConvertedCusOrgUnit/DownloadFileModal");
    let selectedOu = undefined;

    $('#ConvertedCusFilter div').addClass('col-sm-6').parent().addClass("row");
    //折效机构客户表初始化
    var dataTable = $('#ConvertedCusOrgUnitTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                title: l('ConvertedCusOrgUnitLabel'),
                data: "parentName"
            },
            {
                title: l('ConvertedCusOrgUnitUpOrgidt'),
                data: "parentIdentity"
            },
            {
                title: l('ConvertedCusOrgUnitDataDate'),
                data: "dataDate",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, { locale: abp.localization.currentCulture.name })
                        .toLocaleString(luxon.DateTime.DATE_SHORT);
                }
            },
            {
                title: l('ConvertedCusOrgUnitOrgidt'),
                data: "orgIdentity"
            },
            {
                title: l('ConvertedCusOrgUnitFirstLevel'),
                data: "firstLevel"
            },
            {
                title: l('ConvertedCusOrgUnitSecondLevel'),
                data: "secondLevel"
            },
            {
                title: l('ConvertedCusOrgUnitThirdLevel'),
                data: "thirdLevel"
            },
            {
                title: l('ConvertedCusOrgUnitFourthLevel'),
                data: "fourthLevel"
            },
            {
                title: l('ConvertedCusOrgUnitFifthLevel'),
                data: "fifthLevel"
            },
            {
                title: l('ConvertedCusOrgUnitSixthLevel'),
                data: "sixthLevel"
            }
        ]
    }));
    //折效账户表
    var convertedCusWidget = new abp.WidgetManager({
        wrapper: '#convertedCusWidget',
        filterCallback: function () {
            var input = {};
            $("#ConvertedCusFilter")
                .serializeArray()
                .forEach(function (data) {
                    if (data.value != '') {
                        input[abp.utils.toCamelCase(data.name.replace(/ConvertedCusFilter./g, ''))] = data.value;
                    }
                });
            input.orgIdentity = selectedOu;
            return input;
        }
    });
    convertedCusWidget.init();
    $("#ConvertedCusFilter :input").on('change', function (e) {
        convertedCusWidget.refresh();
    });

    //机构表初始化
    var organizationUnitWidget = new abp.WidgetManager({
        wrapper: "#organizationUnitWidget",
    })
    organizationUnitWidget.init();

    const onOrganizationUnitView = function (data) {
        selectedOu = data.currentOuIdentity;
        convertedCusWidget.refresh();
    }
    window.addEventListener("load", function () {
        abp.event.on("organizationUnit:view", onOrganizationUnitView);
    });
    window.addEventListener("unload", function () {
        abp.event.off("organizationUnit:view", onOrganizationUnitView);
    });

    createByFileModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewConvertedCusOrgUnitByFileButton").on("click", function () {
        createByFileModal.open();
    });

    $("#DownloadFileButton").on("click", function () {
        downloadFileModal.open();
    });

    downloadFileModal.onResult(function (event, response) {
        window.open(`/api/app/reports/converted-cus-org-unit/download/${response.responseText}`, "_self");
    });
});
