(function () {
    abp.widgets.OrganizationUnitMap = function ($wrapper) {
        let ROOT_PATH = '/dashboard/geo/';
        let chartDomId = "organizationUnitMap";
        let _dashboardService = wallee.boc.dataPlane.dashboards.dashboard;
        let chartDom;
        let myChart;
        let option;
        let mapCache = new Map();

        let echartsResize = function () {
            let element = document.getElementById(chartDomId);
            let parentHeight = element.parentElement.parentElement.clientHeight;
            let parentWidth = element.parentElement.parentElement.clientWidth;
            myChart.resize({ width: parentWidth, height: parentHeight });
        };

        let getDetails = async function (dataDate, regionCode) {
            var data = await _dashboardService.getConvertedCusOrgUnitDetails({ dataDate: dataDate, regionCode: regionCode });
            return data;
        };

        let initGeoMap = async function (chart) {
            let initMapName = "包头";
            let geoJson = await $.get(`${ROOT_PATH}${initMapName}.json`);
            echarts.registerMap(initMapName, { geoJson: geoJson });
            mapCache.set(initMapName, { regionCode: "150202", center: [] })
            var features = geoJson["features"];
            features.forEach(item => {
                mapCache.set(item.properties.name, { regionCode: item.properties.adcode, center: item.properties.center });
            })

            chart.setOption({
                geo: {
                    show: true,
                    map: initMapName,
                    roam: true,
                    //center: currentMap.geoJSON.features[0].properties.center,
                    zoom: 1.2,
                    scaleLimit: {
                        //min: 1,
                        //max: 1
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
                        opacity: 0.8, // 设置地图的透明度为 0.5
                        areaColor: '#7088f2',
                        borderWidth: 1.5,
                        borderType: "dashed"
                    },
                    emphasis: {
                        focus: 'none',
                    }
                },
            });

            var data = await getDetails(null, null);

            option && myChart.setOption({
                dataset: {
                    dimension: ['orgName', 'orgidt', 'lng', 'lat', 'value'],
                    source: data.items
                }
            });
        }

        let switchGeoMap = async function (chart, mapName) {
            let currentMap = echarts.getMap(mapName);
            if (currentMap == undefined) {
                let geoJson = await $.get(`${ROOT_PATH}${mapName}.json`);
                echarts.registerMap(mapName, { geoJson: geoJson });
            }

            let regionCode = mapCache.get(mapName).regionCode;

            let res = await getDetails(null, regionCode);

            chart.setOption({
                geo: {
                    map: mapName,
                    center: mapCache.get(mapName).center
                },
                dataset: {
                    dimension: ['orgName', 'orgidt', 'lng', 'lat', 'value'],
                    source: res.items
                }
            });
        };
        let getFilters = function () {
            return {

            };
        }

        let refresh = function (filters) {

        };

        let init = async function (filters) {

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
                    right: 0,
                    itemSize: 25,
                    feature: {
                        myRestore: {
                            show: true,
                            title: '还原',
                            icon: "image://dashboard/images/restore.png",
                            onclick: function () {
                                initGeoMap(myChart);
                            }
                        }
                    }
                },
                dataset: {
                    dimension: ['orgName', 'orgidt', 'lng', 'lat', 'value'],
                    source: []
                },
                visualMap: {
                    show: true,
                    type: 'piecewise',
                    pieces: [
                        {
                            min: 0, max: 200, label: '折效:0-200'
                        },
                        {
                            min: 201, max: 500, label: '折效:200-500'
                        },
                        {
                            min: 501, label: '折效:500以上'
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
                        color: ['#313695', '#fdae61', '#f46d43', '#a50026']
                    },
                    left: 'left',
                    top: 'top'
                },
                series: [
                    {
                        type: 'effectScatter',
                        coordinateSystem: 'geo',
                        symbolSize: function (data) {
                            return Math.sqrt(data.value)/1.5; // 这里可以根据你的需求调整函数
                        },
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

            await initGeoMap(myChart);



            myChart.on("click", function (params) {
                //console.log(params);
                if (params.componentType === 'geo') {
                    switchGeoMap(myChart, params.name);
                }
            });

            window.load = echartsResize();
            window.addEventListener("resize", echartsResize);
        };

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };
})();