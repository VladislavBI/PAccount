angular.module('app').controller('notificationsController', ['$scope', 'httpService', 'apiUrlFactory',
    function ($scope, httpService, apiUrlFactory) {
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

        return self;
    }]);