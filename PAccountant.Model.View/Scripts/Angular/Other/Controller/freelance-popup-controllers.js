﻿angular.module('app').controller('freelancePaymentController',
['$scope', '$uibModalInstance', 'items', 'httpService', 'apiUrlFactory', '$rootScope',
function ($scope, $uibModalInstance, items, httpService, apiUrlFactory, $rootScope) {


    $scope.url = apiUrlFactory;
    $scope.http = httpService;
    $scope.newPayment = {
        PayedHours: 0,
        PayedSum: 0
    };

    $scope.init = function () {

        $scope.newPayment.ProjectId = items.projectId;
        $scope.sumPereHour = items.sumPerHour;
        $scope.newPayment.UnpayedHours = items.unpaidHours;
        $scope.hoursTotal = $scope.newPayment.UnpayedHours;

        $scope.http.get($scope.url.GetCurrencies).then(function (result) {
            if (result) {
                $scope.availableCurrency = result.data;
                $scope.newPayment.currency = $scope.availableCurrency[0];
            }
        });
    };


    $scope.sumChanged = function () {
        $scope.newPayment.PayedHours = $scope.newPayment.PayedSum / $scope.sumPereHour;
        $scope.newPayment.UnpayedHours = $scope.hoursTotal - $scope.newPayment.PayedHours;
    }
    $scope.hourChanged = function () {
        $scope.newPayment.PayedSum = $scope.newPayment.PayedHours * $scope.sumPereHour;
        $scope.newPayment.UnpayedHours = $scope.hoursTotal - $scope.newPayment.PayedHours;
    }

    $scope.ok = function () {
        $scope.cancel();
        $scope.newPayment.CurrencyId = $scope.newPayment.currency.Id;
        $scope.http.post($scope.url.addPayment, $scope.newPayment, null).then(function (response) {
            $rootScope.$broadcast('flUpdated');
        });

    }


    $scope.cancel = function () {
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
}]);

angular.module('app').controller('editFreelanceController',
['$scope', '$uibModalInstance', 'items', 'httpService', 'apiUrlFactory', 'modalService', '$uibModal', '$rootScope',
function ($scope, $uibModalInstance, items, httpService, apiUrlFactory, modalService, $uibModal, $rootScope) {


    $scope.url = apiUrlFactory;
    $scope.http = httpService;

    $scope.init = function () {
        $scope.project = items;
    };


    $scope.addSpendedHours = function () {
        modalService.open('freelanceHoursSpendedPopup.html', 'freelanceHoursSpendedController',
            {
                projectId: $scope.project.Id
            });
        $scope.cancel();
    }
    $scope.changeProjectData = function () {
        window.setTimeout(function () {
            modalService.open('changeFreelanceProjectDataPopUp.html', 'changeFreelanceProjectDataController', $scope.project);
        });
        $scope.cancel();
    }
    $scope.changeProjectStatus = function () {
        $scope.cancel();
        $scope.http.post($scope.url.changeProjectStatus, { projectId: $scope.project.Id }, null).then(function (response) {
            $rootScope.$broadcast('flUpdated');
        });
    }

    $scope.cancel = function () {
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
}]);
angular.module('app').controller('freelanceHoursSpendedController',
['$scope', '$uibModalInstance', 'items', 'httpService', 'apiUrlFactory', '$rootScope',
function ($scope, $uibModalInstance, items, httpService, apiUrlFactory, $rootScope) {


    $scope.url = apiUrlFactory;
    $scope.http = httpService;
    $scope.spendedModel = {
        ProjectId: 0,
        Hours: 0
    };
    $scope.init = function () {
        $scope.spendedModel.ProjectId = items.projectId;
    };

    $scope.ok = function () {
        $scope.cancel();
        $scope.http.post($scope.url.addHours, $scope.spendedModel, null).then(function (response) {
            $rootScope.$broadcast('flUpdated');
        });
    }

    $scope.cancel = function () {
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
}]);
angular.module('app').controller('changeFreelanceProjectDataController',
['$scope', '$uibModalInstance', 'items', 'httpService', 'apiUrlFactory', '$rootScope',
function ($scope, $uibModalInstance, items, httpService, apiUrlFactory, $rootScope) {


    $scope.url = apiUrlFactory;
    $scope.http = httpService;
    $scope.changedProject = {};
    $scope.init = function () {
        $scope.changedProject = items;
    };

    $scope.ok = function () {
        $scope.changedProject.TotalHours = $scope.changedProject.FullHours;
        $scope.http.post($scope.url.changeProjectData, $scope.changedProject, null).then(function (response) {
            $rootScope.$broadcast('flUpdated');
        });
        $scope.cancel();
    }

    $scope.cancel = function () {
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
}]);