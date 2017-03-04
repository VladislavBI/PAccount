angular.module('app').controller('statisticPersonalController', ['$scope', 'httpService', 'apiUrlFactory',
    function ($scope, httpService, apiUrlFactory) {
        var self = this;
        self.total = 0;
        self.init = function () {
            loadTotalSumm();
            loadCurrenciesSumm();
        }
        var loadTotalSumm = function () {
            httpService.get(apiUrlFactory.getTotalOperationsSumm).then(function (response) {
                self.total = parseFloat(response.data).toFixed(2);
            });
        };

        var loadCurrenciesSumm = function () {
            httpService.get(apiUrlFactory.getCurrenciesOperationsSumms).then(function (response) {
                self.currenciesOperations = response.data;
            });
        };
        self.redirectToDetailedSourceInfo = function () {
            window.open(apiUrlFactory.detailedSourceInfo, '_blank');
        };
        self.getDetailedSourceInfo = function () {
            httpService.get(apiUrlFactory.getDetailedSourceInfo).then(function (response) {
                self.sourceInfoList = response.data;
            });
        };
        return self;
    }]);