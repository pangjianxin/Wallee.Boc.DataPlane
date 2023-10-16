$(function () {

    var l = abp.localization.getResource('DataPlane');

    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertedCuses/ConvertedCus/CreateByFileModal');

   /* $('#ConvertedCusDetailsFilter div').addClass('col-sm-3');*/

    var convertedCusDetailWidget = new abp.WidgetManager({
        wrapper: '#convertedCusDetailWidget',
        filterCallback: function () {
            var input = {};
            $("#ConvertedCusDetailsFilter")
                .serializeArray()
                .forEach(function (data) {
                    if (data.value != '') {
                        input[abp.utils.toCamelCase(data.name.replace(/ConvertedCusDetailsFilter./g, ''))] = data.value;
                    }
                })
            return input;
        }
    });

    convertedCusDetailWidget.init();

    $("#ConvertedCusDetailsFilter :input").on('change', function (e) {
        convertedCusDetailWidget.refresh();
    });


    createByFileModal.onResult(function () {
        convertedCusDetailWidget.refresh();
    });


    $('#NewConvertedCusButton').click(function (e) {
        e.preventDefault();
        createByFileModal.open();
    });
});
