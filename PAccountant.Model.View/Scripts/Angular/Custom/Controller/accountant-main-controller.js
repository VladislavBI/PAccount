angular.module('app').controller('accountantMainController', ['$scope', 'validationService', 'httpService', 'chainOfResponsibilityService', 'addOperationPopUpService', 'modalService', '$uibModal',
    function ($scope, validationService, httpService, chainOfResponsibilityService, addOperationPopUpService, modalService, $uibModal) {

        me = {};

    $scope.validation = validationService;
    $scope.http = httpService;
    $scope.chainOfResponsibility = chainOfResponsibilityService;
    $scope.addOperationPopUp = addOperationPopUpService;
    $scope.modal = modalService;

    $scope.addOperationModalCallback = function () {
        postData = $scope.addOperationPopUp.popUpArguments;
        postData.isAddOperation = $scope.addOperationPopUp.isAddOperation;

        $scope.http.post("temp", postData, null).then(function (response) {
            $scope.addOperationPopUp.NullifyArguments();
        });
    };


    $scope.openNewOperationModal = function (isAddOperation) {
        $scope.modal.open({ isAddOperation: isAddOperation, callback: $scope.addOperationModalCallback },
            'operationPopupController', "modal-title", "myModalContent.html");
    }
    

    $scope.$on('isAddOperation:updated', function (event, data) {
        $scope.isAddOperation = data;
    });

    
}]);