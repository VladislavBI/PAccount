angular.module('app').factory('barChartFactory', [function () {

    me = this;

    me.getBarChart = function (paramNames, chartData, chartTitle, tagId) {
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            chartData.unshift(paramNames);
            var data = google.visualization.arrayToDataTable(chartData);

            var options = {
                title: chartTitle,
                bars: 'horizontal' // Required for Material Bar Charts.
            };

            var chart = new google.charts.Bar(document.getElementById(tagId));
            chart.draw(data, options);
        }

    }

    return me;
}]);