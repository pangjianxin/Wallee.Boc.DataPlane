$(function () {
    var _dashboardService = wallee.boc.dataPlane.dashboards.dashboard;
    $(window).on("load", function () {
        $(".loading").fadeOut()
    });

    $(document).ready(function () {
        var whei = $(window).width()
        $("html").css({ fontSize: whei / 20 })
        $(window).resize(function () {
            var whei = $(window).width()
            $("html").css({ fontSize: whei / 20 })
        });
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

    //地图
    var innerMongoliaMap = new abp.WidgetManager({
        wrapper: '#mapChartWidgets',
        filterCallback: function () {
            return {
                'startDate': '2021-01-18',
                'endDate': '2021-08-26'
            }
        }
    });
    innerMongoliaMap.init();

    //信用乡镇
    var creditTownWidget = new abp.WidgetManager({
        wrapper: '#creditTownWidget',
        filterCallback: function () {
            return {
                'startDate': '2021-01-18',
                'endDate': '2021-08-26'
            }
        }
    });

    creditTownWidget.init();

    //信用村
    var creditVillageWidget = new abp.WidgetManager({
        wrapper: '#creditVillageWidget',
        filterCallback: function () {
            return {
                'startDate': '2021-01-18',
                'endDate': '2021-08-26'
            }
        }
    });

    creditVillageWidget.init();

    //农牧户
    var herdsmanChartWidget = new abp.WidgetManager({
        wrapper: '#herdsmanChartWidget',
        filterCallback: function () {
            return {
                'startDate': '2021-01-18',
                'endDate': '2021-08-26'
            }
        }
    });
    herdsmanChartWidget.init();

    //新型农业经营主体
    var newAgriMngEntityWidget = new abp.WidgetManager({
        wrapper: '#newAgriMngEntityWidget',
        filterCallback: function () {
            return {
                'startDate': '2021-01-18',
                'endDate': '2021-08-26'
            }
        }
    });
    newAgriMngEntityWidget.init();

    var herdsmanLoanInfoWidget = new abp.WidgetManager({
        wrapper: "#herdsmanLoanInfoWidget",
        filterCallback: function () {
            return {
                'startDate': '2021-01-18',
                'endDate': '2021-08-26'
            }
        }
    });
    herdsmanLoanInfoWidget.init();

    var newAgriMngEntityLoanInfoChartWidget = new abp.WidgetManager({
        wrapper: "#newAgriMngEntityLoanInfoChartWidget",
        filterCallback: function () {
            return {
                'startDate': '2021-01-18',
                'endDate': '2021-08-26'
            }
        }
    });
    newAgriMngEntityLoanInfoChartWidget.init();

    _dashboardService.getComprehensiveSummary().then(function (res) {
        $("#creditTownSummaryTotal").text(res.creditTown.toString().padStart(5, "0"));
        $("#creditVillageSummaryTotal").text(res.creditVillage.toString().padStart(5, "0"));
        $("#herdsmanSummaryTotal").text(res.herdsman.toString().padStart(5, "0"));
        $("#newAgriMngEntitySummaryTotal").text(res.newAgriMngEntity.toString().padStart(5, "0"));
    });
});