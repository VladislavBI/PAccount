angular.module('app').controller('extremumsController', ['$scope', 'httpService', 'apiUrlFactory', '$rootScope',
    function ($scope, httpService, apiUrlFactory, $rootScope) {
        var self = this;
        self.total = 0;
        self.init = function () {
            loadExtremums();
        }
        

        var loadExtremums = function () {
            httpService.get(apiUrlFactory.getExtremums).then(function (response) {
                self.operationsExtremums = response.data;
                self.operationsExtremums.ExtremumsList.forEach(function (element, index, array) {
                    array[index].Summ = element.Summ.toFixed(2) + "$"
                })
            });
        };
        $rootScope.$on("pAcUpdated", loadExtremums);
        return self;
    }]);