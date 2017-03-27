angular.module('app').controller('notificationsController', ['$scope', 'httpService', 'apiUrlFactory', '$rootScope',
    function ($scope, httpService, apiUrlFactory, $rootScope) {
        var self = this;
        self.total = 0;
        self.init = function () {
            loadNotifications();
        }


        var loadNotifications = function () {
            httpService.get(apiUrlFactory.getDebtsNotifications).then(function (response) {
                self.notificationsList = response.data;
            });
        };
        $rootScope.$on("debtUpdated", self.init);

        return self;
    }]);