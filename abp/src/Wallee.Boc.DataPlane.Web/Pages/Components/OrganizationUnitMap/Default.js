(function () {
    abp.widgets.OrganizationUnitMap = function ($wrapper) {
        var ROOT_PATH = '/dashboard/geo/';
        var initialMapName = "包头";
        var chartDomId = "organizationUnitMap";
        var _dashboardService = wallee.boc.dataPlane.dashboards.dashboard;
        var chartDom;
        var myChart;
        var option;

        var echartsResize = function () {
            var element = document.getElementById(chartDomId);
            var parentHeight = element.parentElement.parentElement.clientHeight;
            var parentWidth = element.parentElement.parentElement.clientWidth;
            myChart.resize({ width: parentWidth, height: parentHeight });
        }

        var switchGeoMap = function (chart, mapPath, mapName, callback) {
            $.get(`${mapPath}${mapName}.json`, function (geoJson) {
                echarts.registerMap(mapName, { geoJson: geoJson });
                chart.setOption({
                    geo: {
                        show: true,
                        map: mapName,
                        roam: true,
                        //center: [109.899363, 40.6667],
                        zoom: 1.2,
                        scaleLimit: {
                            //min: 1,
                            //max: 1
                        },
                        nameMap: {

                        },
                        selectedMode: 'single',
                        label: {
                            show: true,
                            position: 'top',
                            distance: 5,
                            formatter: function (data) {
                                return data.name;
                            },
                        },
                        itemStyle: {
                            areaColor: 'rgb(252, 234, 115)'
                        },
                        emphasis: {
                            focus: 'none',
                        }
                    },
                });
                if (callback) {
                    callback();
                }
            });
        }

        var getFilters = function () {
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
                    trigger: 'item',
                    formatter: function (item) {
                        return `${item.data.orgName}<br/>${item.marker} 折效客户 : ${item.value.value}`;
                    }
                },
                toolbox: {
                    show: true,
                    left: 0,
                    feature: {
                        myRestore: {
                            show: true,
                            title: '还原',
                            icon: "image://dashboard/images/restore.png",
                            onclick: function () {
                                switchGeoMap(myChart, ROOT_PATH, initialMapName);
                            }
                        }
                    }
                },
                dataset: {
                    dimension: ['orgName', 'orgidt', 'lng', 'lat', 'value'],
                    source: []
                },
                visualMap: {
                    type: 'piecewise',
                    pieces: [
                        {
                            min: 0, max: 100, label: '0-100'
                        },
                        {
                            min: 101, max: 150, label: '100-150'
                        },
                        {
                            min: 151, max: 200, label: '150-200'
                        },
                        {
                            min: 201, max: 500, label: '200-500'
                        },
                        {
                            min: 501, label: '500以上'
                        }
                    ],
                    textStyle: {
                        color: "white"  // 这里设置标签的颜色
                    },
                    showLabel: true,
                    itemWidth: 30,
                    itemHeight: 16,
                    dimension: "value",//维度,需要将哪一列的数值映射到VisualMap上。
                    hoverLink: true,
                    realtime: false,
                    calculable: true,
                    inRange: {
                        //color: ['white', 'lightblue', 'yellow', 'orangered']
                        color: ['#313695', '#4575b4', '#74add1', '#abd9e9', '#e0f3f8', '#ffffbf', '#fee090', '#fdae61', '#f46d43', '#d73027', '#a50026']
                    },
                    left: 'right',
                    top: 'top'
                },
                series: [
                    {
                        type: 'effectScatter',
                        coordinateSystem: 'geo',
                        symbolSize: 15,
                        label: {
                            show: false,
                            itemStyle: {
                                borderColor: 'rgb(242, 242, 242)',
                                borderWidth: 5
                            }
                        },
                        encode: {
                            lng: "lng",
                            lat: "lat",
                            value: "value",
                        },
                    }
                ]
            };
            myChart.setOption(option);
            switchGeoMap(myChart, ROOT_PATH, initialMapName, () => {
                window.load = echartsResize();
                window.addEventListener("resize", echartsResize);
            });
            myChart.on("click", function (params) {
                console.log(params);
                if (params.componentType === 'geo') {
                    switchGeoMap(myChart, ROOT_PATH, params.name);
                }
            });
            _dashboardService.getConvertedCusOrgUnitDetails(null).then(data => {
                option && myChart.setOption({
                    dataset: {
                        dimension: ['orgName', 'orgidt', 'lng', 'lat', 'value'],
                        source: data.items
                    }
                });

            });

        }

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };
})();