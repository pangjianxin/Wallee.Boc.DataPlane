$(function () {

    var l = abp.localization.getResource('DataPlane');

    var createByFileModal = new abp.ModalManager(abp.appPath + 'Reports/Pa/ConvertedCuses/ConvertedCus/CreateByFileModal');

   /* $('#ConvertedCusDetailsFilter div').addClass('col-sm-3');*/

    var convertedCusDetailWidget = new abp.WidgetManager({
        wrapper: '#convertedCusDetailWidget',
        filterCallback: function () {
            var input = {};
            $("#ConvertedCusFilter")
                .serializeArray()
                .forEach(function (data) {
                    if (data.value != '') {
                        input[abp.utils.toCamelCase(data.name.replace(/ConvertedCusFilter./g, ''))] = data.value;
                    }
                })
            return input;
        }
    });

    convertedCusDetailWidget.init();

    $("#ConvertedCusFilter :input").on('change', function (e) {
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
