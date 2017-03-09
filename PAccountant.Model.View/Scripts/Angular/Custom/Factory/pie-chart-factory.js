angular.module('app').factory('pieChartFactory', [function () {

    me = this;

    me.getPieChart = function (paramNames, chartData, chartTitle, tagId) {
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            chartData.unshift(paramNames);
            var data = google.visualization.arrayToDataTable(chartData);

            var options = {
                title: chartTitle,
                is3D: true,
            };

            var chart = new google.visualization.PieChart(document.getElementById(tagId));
            chart.draw(data, options);
        }
    }

   
    return me;
}]);