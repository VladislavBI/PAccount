angular.module('app').controller('chartController', ['pieChartFactory', 'lineChartFactory', 'barChartFactory', 'apiUrlFactory', 'httpService', 'converterService',
function (pieChartFactory, lineChartFactory, barChartFactory, apiUrlFactory, httpService, converterService) {

    var me = this;
    me.initPersonalChart = function () {
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        me.getPieChart();
        me.getLineChart();
        me.getbarChartS();
        me.getbarChartC();
        me.getbarChartCr();
    }
    me.getPieChart = function (paramNames, chartData, chartTitle, tagId) {
        httpService.get(apiUrlFactory.getMonthTotalFlow).then(function (response) {
            if (response) {
                var chartProperties = converterService.convertObjectListToArrayList(response.data)
                pieChartFactory.getPieChart(['Direction', 'Money per month'], chartProperties, "Month cashflow", "piechart_3d");
            }           
        });      
    }
    me.getLineChart = function (paramNames, chartData, chartTitle, tagId) {
        httpService.get(apiUrlFactory.getToTalFlowByMonth).then(function (response) {
            if (response) {
                var chartProperties = converterService.convertObjectListToArrayList(response.data)
                lineChartFactory.getLineChart(['Month', 'Income', 'Outcome'], chartProperties, "Month dynamic", "barchart_month");
            }
        });
       
    }
    me.getbarChartS = function (paramNames, chartData, chartTitle, tagId) {
        httpService.get(apiUrlFactory.getMonthSourceFlow).then(function (response) {
            if (response) {
                var chartProperties = converterService.convertObjectListToArrayList(response.data)
                barChartFactory.getBarChart(['Source', 'Income', 'Outcome'], chartProperties, "Month source", "barchart_s");
            }
        });        
    }
    me.getbarChartC = function (paramNames, chartData, chartTitle, tagId) {
        httpService.get(apiUrlFactory.getMonthCategoriesFlow).then(function (response) {
            if (response) {
                var chartProperties = converterService.convertObjectListToArrayList(response.data)
                barChartFactory.getBarChart(['Category', 'Income', 'Outcome'], chartProperties, "Month category", "barchart_c");
            }
        });
        
    }
    me.getbarChartCr = function (paramNames, chartData, chartTitle, tagId) {
        httpService.get(apiUrlFactory.getMonthCurrenciesFlow).then(function (response) {
            if (response) {
                var chartProperties = converterService.convertObjectListToArrayList(response.data)
                barChartFactory.getBarChart(['Currency', 'Income', 'Outcome'], chartProperties, "Month currency", "barchart_cr");
            }
        });
    }

}]);