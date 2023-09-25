$(function () {
    abp.widgets.CcicCusInfoWorkFlow = function ($wrapper) {
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
           
        };
        var init = function (filters) {
            var ccicCusInfoWorkFlowService = wallee.boc.dataPlane.workFlows.ccicCusInfoWorkFlow;
            ccicCusInfoWorkFlowService.getExecuting().then(data => {
                $("#tdcmpCreationDate").append($(`<span>
                <i class="fas fa-clock">&nbsp;创建日期</i>
                ${luxon.DateTime.fromISO(data.dto.creationTime, { locale: abp.localization.currentCulture.name }).toLocaleString(luxon.DateTime.DATE_SHORT)}
                </span>`));

                $("#tdcmpDataDate").append($(`
                <span class="badge bg-warning" style="margin-left:5px;" title="数据日期">
                <i class="fas fa-calendar"></i>
                ${luxon.DateTime.fromISO(data.dto.dataDate, { locale: abp.localization.currentCulture.name }).toLocaleString(luxon.DateTime.DATE_SHORT)}
                </span>`));

                $("#tdcmpStatus").append($(`
                <span class="badge bg-secondary" style="margin-left:5px;" title="任务总数">
                 <i class="far fa-lightbulb" style="margin-right:5px;"></i>
                ${data.dto.totalTaskCount}
                </span>
                `));
                $("#tdcmpStatus").append($(`
                <span class="badge bg-secondary" style="margin-left:5px;" title="完成数量">
                <i class="fas fa-lightbulb" style="margin-right:5px;"></i>
                ${data.dto.completedCount}
                </span>
                `));
                $("#tdcmpStatus").append($(`
                <span class="badge bg-primary" style="margin-left:5px;" title="当前状态">
                <i class="fas fa-thermometer-three-quarters" style="margin-right:5px;"></i>
                ${l('Enum:TDcmpStatus:' + data.dto.status)}
                </span>
                `));

                $("#tdcmpProgress").append($(`<span>${Math.ceil(data.dto.completedCount / data.dto.totalTaskCount * 100)}%</span>`));
                render(data.dotGraph)
                    .then(element => {
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
