$(function () {
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

    $("#ConvertedCusDetailsFilter :input").on('input', function () {
        convertedCusDetailWidget.refresh();
    });
});