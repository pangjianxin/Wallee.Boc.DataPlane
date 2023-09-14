(function () {
    abp.widgets.MapChart = function ($wrapper) {
        var ROOT_PATH = '/map/baotou.json';
        var chartDom;
        var myChart;
        var _evaluationAppService = wallee.ccm.indicators.indicatorEvaluation;
        var option;
        var convertData = function (data) {
            var res = [];
            var geoCoordMap = {
                '04247': [109.866842, 40.661226],
                '23003': [109.832041, 40.638942],
                '04248': [110.007678, 40.59122],
                '04097': [109.806419, 40.665754],
                '04087': [109.97065, 40.608869],
                '04108': [110.027613, 40.592817],
                '23015': [109.863497, 40.65137],
                '04124': [109.899363, 40.6667],
                '04103': [109.881883, 40.656353],
                '04091': [109.786546, 40.665249],
                '04111': [110.155872, 40.571927],
                '04116': [110.039238, 40.596562],
                '04127': [109.889455, 40.649989],
                '04101': [109.819358, 40.653204],
                '04100': [109.836334, 40.652927],
                '04102': [109.831127, 40.676803],
                '23009': [110.540111, 40.5806],
                '04123': [109.876116, 40.679171],
                '04106': [110.041955, 40.590748],
                '04109': [110.047419, 40.581014],
                '04089': [109.849418, 40.651909],
                '04088': [109.845301, 40.63369],
                '23021': [109.869237, 40.647277],
                '23035': [109.913461, 40.660349],
                '04086': [109.844242, 40.662189],
                '04094': [109.851716, 40.645354],
                '04093': [109.828776, 40.668834],
                '23041': [109.836988, 40.662414],
                '04104': [109.850099, 40.659685],
                '04122': [109.878119, 40.670293],
                '04114': [110.027046, 40.579795],
                '04110': [110.037426, 40.590407],
                '04113': [110.019765, 40.596145],
                '23045': [109.925981, 40.654179],
                '04095': [109.974509, 40.621247],
                '04118': [109.906952, 40.652248],
                '04117': [109.884836, 40.673781],
                '04098': [109.819713, 40.670633],
                '04099': [109.85675, 40.675125],
                '23058': [110.071582, 41.0238],
                '23050': [109.931055, 40.623446],
                '23059': [110.442018, 41.705317],
                //ref:http://www.gpsspg.com/maps.html  //这里可以得到对应地点的gps经纬度，也可批量查询
                //http://lbsyun.baidu.com/index.php?title=jspopular/guide/conflux 
                //http://lbsyun.baidu.com/custom/
            };
            for (var i = 0; i < data.length; i++) {
                var geoCoord = geoCoordMap[data[i].brNo];
                if (geoCoord) {
                    res.push([
                        data[i].brNo,
                        data[i].name,
                        ...geoCoord.concat(data[i].value)
                    ]);
                }
            }
            return res;
        };



        var getFilters = function () {
            return {

            };
        }

        var refresh = function (filters) {
        };

        var init = function (filters) {

            var today = new Date();
            chartDom = document.getElementById('organizationUnitMap');
            myChart = echarts.init(chartDom);
            myChart.showLoading();
            $.get(ROOT_PATH, function (geoJson) {
                echarts.registerMap('baotou', { geoJson: geoJson });
                // 将坐标与值对应并反映在地图上
                option = {
                    title: {
                        // year: 'numeric', month: 'long', day: 'numeric' ,weekday: 'long',
                        text: `全辖机构数据【${today.toLocaleDateString([], { month: 'long' })}】`,
                        subtext: '每小时刷新，累计值',
                        left: 'left'
                    },
                    tooltip: {
                        trigger: 'item',
                        formatter: function (item) {
                            return `${item.data[1]}<br/>${item.data[4]}`;
                        }
                    },
                    toolbox: {
                        show: true,
                        left: 'right',
                        top: 'top',
                        feature: {
                            dataView: { readOnly: false },
                            saveAsImage: {}
                        }
                    },
                    visualMap: {
                        type: 'piecewise',
                        pieces: [
                            {
                                min: 0, max: 10, label: '0-10'
                            },
                            {
                                min: 11, max: 20, label: '10-20'
                            },
                            {
                                min: 21, max: 50, label: '20-50'
                            },
                            {
                                min: 51, max: 100, label: '51-100'
                            },
                            {
                                min: 100, label: '100以上'
                            }
                        ],
                        showLabel: true,
                        itemWidth: 30,
                        itemHeight: 16,
                        dimension: 4,//维度,需要将哪一列的数值映射到VisualMap上。
                        hoverLink: true,
                        realtime: false,
                        calculable: true,
                        inRange: {
                            //color: ['white', 'lightblue', 'yellow', 'orangered']
                            color: ['#313695', '#4575b4', '#74add1', '#abd9e9', '#e0f3f8', '#ffffbf', '#fee090', '#fdae61', '#f46d43', '#d73027', '#a50026']
                        },
                        left: 'right'
                    },
                    dataset: {
                        dimension: ['brNo', 'name', 'lng', 'lat', 'value'],
                        source: []
                    },
                    geo: {
                        show: true,
                        map: 'baotou',
                        roam: true,
                        center: [109.913461, 40.781800],
                        zoom: 5.5,
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
                            //{a}：系列名。
                            //{ b } ：数据名。
                            //  { c } ：数据值。
                            //  { @xxx } ：数据中名为 'xxx' 的维度的值，如 { @product } 表示名为 'product' 的维度的值。
                            //   { @[n] } ：数据中维度 n 的值，如 { @[3] } 表示维度 3 的值，从 0 开始计数。
                            formatter: function (data) {
                                return data.name;
                            },
                        },
                        itemStyle: {
                            //areaColor:'rgb(98, 124, 220)'
                        },
                        emphasis: {
                            focus: 'none',
                        },
                        regions: [{
                            name: '达尔罕茂明安联合旗',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '白云鄂博矿区',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '固阳县',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '土默特右旗',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '石拐区',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '青山区',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '东河区',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '九原区',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }, {
                            name: '昆都仑区',
                            itemStyle: {
                                areaColor: 'rgb(235, 238, 238)',
                                borderColor: 'rgb(255, 0, 0)',
                                borderWidth: 0.2
                            }
                        }]
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
                                lng: 2,
                                lat: 3,
                                value: 4,
                            },
                        }
                    ]
                }
                myChart.setOption(option);
            });

            //_evaluationAppService.getMapSummary().then(function (data) {
            //    var items = data.items;
            //    option && myChart.setOption({
            //        dataset: {
            //            dimension: ['brNo', 'name', 'lng', 'lat', 'value'],
            //            source: convertData(items)
            //        }
            //    });
            //    myChart.hideLoading();
            //});

            option && myChart.setOption({
                dataset: {
                    dimension: ['brNo', 'name', 'lng', 'lat', 'value'],
                    source: convertData(items)
                }
            });
        }

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };
})();