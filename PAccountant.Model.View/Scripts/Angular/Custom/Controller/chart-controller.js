angular.module('app').controller('chartController', ['pieChartFactory', 'lineChartFactory', 'barChartFactory',
    function (pieChartFactory, lineChartFactory, barChartFactory) {

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
            pieChartFactory.getPieChart(['Direction', 'Money per month'], [['Income', 5200],
              ['Outcome', 1500]], "Month cashflow", "piechart_3d");
        }
        me.getLineChart = function (paramNames, chartData, chartTitle, tagId) {
            lineChartFactory.getLineChart(['Month', 'Income', 'Outcome'], [['01.17', 5200, 3100],
              ['02.17', 4021, 2544], ['03.17', 100, 250]], "Month dynamic", "barchart_month");
        }
        me.getbarChartS = function (paramNames, chartData, chartTitle, tagId) {
            barChartFactory.getBarChart(['Source', 'Income', 'Outcome'], [['Work', 2250, 1800],
              ['Additional work', 2354, 125], ['Entertaiment', 0, 754], ['Other', 685, 325]], "Month source", "barchart_s");
        }
        me.getbarChartC = function (paramNames, chartData, chartTitle, tagId) {
            barChartFactory.getBarChart(['Category', 'Income', 'Outcome'], [['Salary', 250, 300],
              ['Privat', 125, 256], ['Presents', 245, 754], ['Other', 0, 52]], "Month category", "barchart_c");
        }
        me.getbarChartCr = function (paramNames, chartData, chartTitle, tagId) {
            barChartFactory.getBarChart(['Currency', 'Income', 'Outcome'], [['USD', 1250, 800],
              ['UAH', 5354, 4256], ['EUR', 25, 754], ['RUB', 105, 0]], "Month currency", "barchart_cr");
        }
    
    }]);