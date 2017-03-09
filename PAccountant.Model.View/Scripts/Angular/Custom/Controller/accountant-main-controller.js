angular.module('app').controller('accountantMainController', 
['$scope','validationService', 'httpService', 'chainOfResponsibilityService', 'modalService', '$uibModal',
function ($scope, validationService, httpService, chainOfResponsibilityService, modalService, $uibModal) {

        me = {};
        $scope.validation = validationService;
        $scope.http = httpService;
        $scope.chainOfResponsibility = chainOfResponsibilityService;
        $scope.modal = modalService;

    $scope.addOperationModalCallback = function () {
      
    };


    $scope.openNewOperationModal = function (isAddOperation) {
        $scope.modal.open('addOperationPopup.html', 'addOperationController', isAddOperation);
    }
}]);