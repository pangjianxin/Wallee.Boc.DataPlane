$(function () {
    abp.widgets.TDcmpWorkFlow = function ($wrapper) {

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
            tDcmpWorkFlowService.getCurrent().then(data => {
                tDcmpWorkFlowService.getDotGraph(data.id).then(data => {
                    console.log(data);
                    render(data)
                        .then(element => {
                            document.getElementById("shit").appendChild(element);
                        })
                        .catch(error => {
                            abp.message.error(`DOT-Graph:${error}`);
                        });
                })
            });

        };

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };

});
