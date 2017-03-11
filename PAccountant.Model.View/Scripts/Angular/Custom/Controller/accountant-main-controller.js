angular.module('app').controller('accountantMainController',
['$scope', 'validationService', 'httpService', 'apiUrlFactory', 'modalService', '$uibModal', "$rootScope",
function ($scope, validationService, httpService, apiUrlFactory, modalService, $uibModal, $rootScope) {

    me = {};
    $scope.validation = validationService;
    $scope.http = httpService;
    $scope.url = apiUrlFactory;
    $scope.modal = modalService;

    $scope.init = function () {
        $scope.http.get($scope.url.getCurrentPageType).then(function (result) {
            if (result) {
                $rootScope.pageType = result.date;
            }
        })
    };


    $scope.openNewOperationModal = function (isAddOperation) {
        $scope.modal.open('addOperationPopup.html', 'addOperationController', { isAdd: isAddOperation, type: "personal" });
    }
    $scope.openDebtOperationModal = function (isAddOperation) {
        $scope.modal.open('addDebtOperationPopup.html', 'addOperationController', { isAdd: isAddOperation, type: "debt" });
    }
}]);