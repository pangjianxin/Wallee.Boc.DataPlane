(function ($) {
	$(function () {
		var l = abp.localization.getResource('DataPlane');
		$("#DataPlaneSettingsForm").on('submit', function (event) {
			event.preventDefault();

			if (!$(this).valid()) {
				return;
			}

			var form = $(this).serializeFormToObject();

			wallee.boc.dataPlane.dataPlaneSettings.dataPlaneSettings.updateDataPlaneSettings(form).then(function (result) {
				$(document).trigger("AbpSettingSaved");
			});

		});
	});

})(jQuery);