angular.module('app').controller('extremumsController', ['$scope', 'httpService', 'apiUrlFactory',
    function ($scope, httpService, apiUrlFactory) {
        var self = this;
        self.total = 0;
        self.init = function () {
            loadExtremums();
        }
        

        var loadExtremums = function () {
            httpService.get(apiUrlFactory.getExtremums).then(function (response) {
                self.operationsExtremums = response.data;
            });
        };
        
        return self;
    }]);