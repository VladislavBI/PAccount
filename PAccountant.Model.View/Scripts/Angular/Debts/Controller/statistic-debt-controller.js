angular.module('app').controller('statisticDebtController', ['$scope', 'httpService', 'apiUrlFactory',
    function ($scope, httpService, apiUrlFactory) {
        var self = this;
        self.totalDebit = 0;
        self.totalCredit = 0;

        self.init = function () {
            loadTotalDebts();
            getDetailedInfo();
        }
        var loadTotalDebts = function () {
            httpService.get(apiUrlFactory.getDebtsTotal).then(function (response) {
                if (response && response.data) {
                    self.totalDebit = response.data.DebitTotal ? parseFloat(response.data.DebitTotal).toFixed(2) : 0;
                    self.totalCredit = response.data.CreditTotal ? parseFloat(response.data.CreditTotal).toFixed(2) : 0;
                }
            });
        };

        var getDetailedInfo = function () {
            //httpService.get(apiUrlFactory.getDetailedSourceInfo).then(function (response) {
            //    self.sourceInfoList = response.data;
            //});
        };
        return self;
    }]);