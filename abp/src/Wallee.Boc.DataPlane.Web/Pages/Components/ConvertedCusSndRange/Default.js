(
    function () {
        abp.widgets.ConvertedCusSndRange = function ($wrapper) {
            var l = abp.localization.getResource('DataPlane');
            var chartDomId = "convertedCusSndRange";
            var chartDom;
            var myChart;
            var option;
            var getFilters = function (filter) {
                return {

                };
            }

            var refresh = function (filters) {

            };

            var init = function (filters) {
                chartDom = document.getElementById(chartDomId);
                myChart = echarts.init(chartDom);
                option = {
                    tooltip: {
                        show: true,
                        trigger: 'item',
                        formatter: function (params) {
                            return `${params.value.label}<br/>${params.marker}${params.seriesName}:${params.value.value}`;
                        }
                    },
                    color: ['#617BDA', '#55BBF6'],
                    dataset: {
                        // 这里指定了维度名的顺序，从而可以利用默认的维度到坐标轴的映射。
                        // 如果不指定 dimensions，也可以通过指定 series.encode 完成映射，参见后文。
                        dimensions: ['label', 'upOrgidt', 'value'],
                        source: [

                        ]
                    },
                    xAxis: {
                        type: 'category',
                        axisLabel: {
                            rotate: 30
                        },
                    },
                    yAxis: {
                        splitLine: {
                            lineStyle: {
                                color: "#c3c4c6",
                                type: "dotted"
                            }
                        }
                    },
                    series: [
                        {
                            name: "20万-50万日均客户统计信息",
                            type: 'bar',
                            encode: {
                                x: "upOrgidt",
                                y: "value"
                            }
                        }
                    ]
                };

                option && myChart.setOption(option);

                myChart.setOption({
                    dataset: {
                        dimensions: ['label', 'upOrgidt', 'value'],
                        source: filters.items
                    }
                });

                var echartsResize = function () {
                    var element = document.getElementById(chartDomId);
                    var parentHeight = element.parentElement.parentElement.clientHeight;
                    var parentWidth = element.parentElement.parentElement.clientWidth;
                    myChart.resize({ width: parentWidth, height: parentHeight });
                }

                window.load = echartsResize();

                $(window).on("load", function () { });

                window.addEventListener("resize", echartsResize);
            }

            return {
                getFilters,
                init,
                refresh
            };
        };
    }
)();