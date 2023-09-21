$(function () {
    var _dashboardService = wallee.boc.dataPlane.dashboards.dashboard;
    $(window).on("load", function () {
        $(".loading").fadeOut()
    });


    $(document).ready(function () {
        var whei = $(window).width()
        $("html").css({ fontSize: whei / 20 })
        window.addEventListener("resize", function () {
            var whei = $(window).width()
            $("html").css({ fontSize: whei / 20 })
        })
    });


    var t = null;
    t = setTimeout(time, 1000);
    function time() {
        clearTimeout(t);
        dt = new Date();
        var y = dt.getFullYear();
        var mt = dt.getMonth() + 1;
        var day = dt.getDate();
        var h = dt.getHours();
        var m = dt.getMinutes();
        var s = dt.getSeconds();
        document.getElementById("showTime").innerHTML = y + "年" + mt + "月" + day + "日" + h + "时" + m + "分" + s + "秒";
        t = setTimeout(time, 1000);
    }

    ////地图
    var organizationUnitMapWidget = new abp.WidgetManager({
        wrapper: '#organizationUnitMapWidget',
        filterCallback: function () {
            return {
                dataDate: new Date()
            }
        }
    });
    organizationUnitMapWidget.init();

    _dashboardService.getConvertedCusOrgUnitSummary({ dataDate: null }).then(data => {
        var date = luxon
            .DateTime
            .fromISO(data.dataDate, { locale: abp.localization.currentCulture.name })
            .toLocaleString(luxon.DateTime.DATE_SHORT);

        $("#dashboardTitle").text(`包头分行对公折效客户数据统计(${date})`);

        //2000-20万日均客户
        var convertedCusFstRangeWidget = new abp.WidgetManager({
            wrapper: '#convertedCusFstRangeWidget',
            filterCallback: function () {
                return {
                    items: data.items.map(it => {
                        return {
                            label: it.label,
                            upOrgidt: it.upOrgidt,
                            value: it.firstLevel
                        }
                    })
                }
            }
        });

        convertedCusFstRangeWidget.init();

        //20-50万日均客户
        var convertedCusSndRangeWidget = new abp.WidgetManager({
            wrapper: '#convertedCusSndRangeWidget',
            filterCallback: function () {
                return {
                    items: data.items.map(it => {
                        return {
                            label: it.label,
                            upOrgidt: it.upOrgidt,
                            value: it.secondLevel
                        }
                    })
                }
            }
        });

        convertedCusSndRangeWidget.init();

        //50-500万日均客户
        var convertedCusThdRangeWidget = new abp.WidgetManager({
            wrapper: '#convertedCusThdRangeWidget',
            filterCallback: function () {
                return {
                    items: data.items.map(it => {
                        return {
                            label: it.label,
                            upOrgidt: it.upOrgidt,
                            value: it.thirdLevel
                        }
                    })
                }
            }
        });

        convertedCusThdRangeWidget.init();

        //500-2000万日均客户
        var convertedCusFourthRangeWidget = new abp.WidgetManager({
            wrapper: '#convertedCusFourthRangeWidget',
            filterCallback: function () {
                return {
                    items: data.items.map(it => {
                        return {
                            label: it.label,
                            upOrgidt: it.upOrgidt,
                            value: it.fourthLevel
                        }
                    })
                }
            }
        });

        convertedCusFourthRangeWidget.init();

        //2000万-1亿日均客户存款
        convertedCusFifthRangeWidget = new abp.WidgetManager({
            wrapper: '#convertedCusFifthRangeWidget',
            filterCallback: function () {
                return {
                    items: data.items.map(it => {
                        return {
                            label: it.label,
                            upOrgidt: it.upOrgidt,
                            value: it.fifthLevel
                        }
                    })
                }
            }
        });

        convertedCusFifthRangeWidget.init();

        //1亿以上日均客户存款
        convertedCusSixthRangeWidget = new abp.WidgetManager({
            wrapper: '#convertedCusSixthRangeWidget',
            filterCallback: function () {
                return {
                    items: data.items.map(it => {
                        return {
                            label: it.label,
                            upOrgidt: it.upOrgidt,
                            value: it.sixthLevel
                        }
                    })
                }
            }
        });

        convertedCusSixthRangeWidget.init();
    })


    //_dashboardService.getComprehensiveSummary().then(function (res) {
    //    $("#creditTownSummaryTotal").text(res.creditTown.toString().padStart(5, "0"));
    //    $("#creditVillageSummaryTotal").text(res.creditVillage.toString().padStart(5, "0"));
    //    $("#herdsmanSummaryTotal").text(res.herdsman.toString().padStart(5, "0"));
    //    $("#newAgriMngEntitySummaryTotal").text(res.newAgriMngEntity.toString().padStart(5, "0"));
    //});
});