angular.module('app').controller('accountantMainController', ['$scope', 'validationService', 'httpService', 'chainOfResponsibilityService', 'addOperationPopUpService',
    function ($scope, validationService, httpService, chainOfResponsibilityService, addOperationPopUpService) {

        me = {};

    $scope.validation = validationService;
    $scope.http = httpService;
    $scope.chainOfResponsibility = chainOfResponsibilityService;
    $scope.addOperationPopUp = addOperationPopUpService;

    $scope.addOperationModalCallback = function () {
        postData = $scope.addOperationPopUp.popUpArguments;
        postData.isAddOperation = $scope.addOperationPopUp.isAddOperation;

        $scope.http.post("temp", postData, null).then(function (response) {
            $scope.addOperationPopUp.NullifyArguments();
        });
    };

    $scope.$on('isAddOperation:updated', function (event, data) {
        $scope.isAddOperation = data;
    });

    
}]);