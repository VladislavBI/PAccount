angular.module('app').controller('chartController', ['$scope', 'pieChartFactory', 'lineChartFactory', 'barChartFactory', 'apiUrlFactory', 'httpService', 'converterService',
function ($scope, pieChartFactory, lineChartFactory, barChartFactory, apiUrlFactory, httpService, converterService) {

    var me = this;
    me.periods = {
        sourceDate:
            {
                startPeriod: new Date(),
                endPeriod:  new Date()
            },
        categoryDate:
            {
                startPeriod: new Date(),
                endPeriod: new Date()
            },
        currencyDate:
         {
             startPerid: new Date(),
             endPeriod: new Date()
         }
    };

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

    me.applyDate = function (type) {
        switch (type){
            case "source":
                var periodModel = {
                    StartDate: me.periods.sourceDate.startPeriod,
                    EndDate: me.periods.sourceDate.endPeriod
                }
                httpService.post(apiUrlFactory.getMonthSourceFlow, periodModel).then(function (response) {
                    if (response) {
                        var chartProperties = converterService.convertObjectListToArrayList(response.data)
                        barChartFactory.getBarChart(['Source', 'Income', 'Outcome'], chartProperties, "Month source", "barchart_s");
                    }
                });
                break;
            case "currency":
                var periodModel = {
                    StartDate: me.periods.currencyDate.startPeriod,
                    EndDate: me.periods.currencyDate.endPeriod
                }
                httpService.post(apiUrlFactory.getMonthCurrenciesFlow, periodModel).then(function (response) {
                    if (response) {
                        var chartProperties = converterService.convertObjectListToArrayList(response.data)
                        barChartFactory.getBarChart(['Currency', 'Income', 'Outcome'], chartProperties, "Month currency", "barchart_cr");
                    }
                });
                break;
            case 'category':
                var periodModel = {
                    StartDate: me.periods.categoryDate.startPeriod,
                    EndDate: me.periods.categoryDate.endPeriod
                }
                httpService.post(apiUrlFactory.getMonthCategoriesFlow, periodModel).then(function (response) {
                    if (response) {
                        var chartProperties = converterService.convertObjectListToArrayList(response.data)
                        barChartFactory.getBarChart(['Category', 'Income', 'Outcome'], chartProperties, "Month category", "barchart_c");
                    }
                });
                break;
        }
    }
}]);