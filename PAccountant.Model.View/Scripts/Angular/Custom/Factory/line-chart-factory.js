angular.module('app').factory('lineChartFactory', [function () {

    me = this;

    me.getLineChart = function (paramNames, chartData, chartTitle, tagId) {
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            chartData.unshift(paramNames);
            var data = google.visualization.arrayToDataTable(chartData);

            var options = {
                title: chartTitle,
                curveType: 'function',
                legend: { position: 'bottom' }
            };

            var chart = new google.visualization.LineChart(document.getElementById(tagId));
            chart.draw(data, options);
        }

    }

    return me;
}]);