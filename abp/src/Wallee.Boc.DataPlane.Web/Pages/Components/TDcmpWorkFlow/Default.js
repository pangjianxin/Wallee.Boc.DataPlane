$(function () {
    abp.widgets.TDcmpWorkFlow = function ($wrapper) {
        var l = abp.localization.getResource('DataPlane');
        let vizPromise;
        let render = function (src) {
            if (typeof vizPromise === "undefined") {
                vizPromise = Viz.instance();
            }
            return vizPromise.then(viz => viz.renderSVGElement(src));
        }
        var getFilters = function () {
            return {

            };
        }

        var refresh = function (filters) {
            console.log(filters);
        };
        var init = function (filters) {
            var tDcmpWorkFlowService = wallee.boc.dataPlane.controllers.tDcmp.workFlows.tDcmpWorkFlow;
            tDcmpWorkFlowService.getExecuting().then(data => {
                console.log(data.dto)
                $("#tdcmpStatus").append($(`
                <span class="badge bg-success d-flex flex-column justify-content-center">
                <span class="fs-5">${luxon.DateTime.fromISO(data.dto.creationTime, { locale: abp.localization.currentCulture.name }).toLocaleString(luxon.DateTime.DATE_SHORT)}</span>
                <span class="mt-1 text-light">创建日期</span>
                </span>`));
                $("#tdcmpStatus").append($(`
                <span class="badge bg-secondary d-flex flex-column justify-content-center" style="margin-left:5px">
                <span class="fs-5">${luxon.DateTime.fromISO(data.dto.dataDate, { locale: abp.localization.currentCulture.name }).toLocaleString(luxon.DateTime.DATE_SHORT)}</span>
                <span class="mt-1 text-light">数据日期</span>
                </span>`));
                $("#tdcmpStatus").append($(`
                <span class="badge bg-primary d-flex flex-column justify-content-center" style="margin-left:5px">
                <span class="fs-5">${l('Enum:TDcmpStatus:' + data.dto.status)}</span>
                <span class="mt-1 text-light">当前状态</span>
                </span>`));
                render(data.dotGraph)
                    .then(element => {
                        element.removeAttribute("height");
                        element.removeAttribute("width");
                        $("#dotGraph").append(element);
                    })
                    .catch(error => {
                        abp.message.error(`DOT-Graph:${error}`);
                    });
            }).catch(error => {
                abp.message.error(`${error}`);
            });;

        };

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };

});
