$(function () {

    var l = abp.localization.getResource('DataPlane');

    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertedCuses/ConvertedCus/CreateByFileModal');

    let selectedOu = undefined;

    $('#ConvertedCusFilter div').addClass('col-sm-6').parent().addClass("row");
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

    abp.event.off("organizationUnit:view", onOrganizationUnitView);

    abp.event.on("organizationUnit:view", onOrganizationUnitView);


    createByFileModal.onResult(function () {
        convertedCusDetailWidget.refresh();
    });


    $('#NewConvertedCusButton').click(function (e) {
        e.preventDefault();
        createByFileModal.open();
    });
});
