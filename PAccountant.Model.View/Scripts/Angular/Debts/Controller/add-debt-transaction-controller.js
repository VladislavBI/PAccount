angular.module('app').controller('addDebtTransactionController',
    ['$scope', '$uibModalInstance', 'items', 'httpService', 'validationService', 'apiUrlFactory',
function ($scope, $uibModalInstance, items, httpService, validationService, apiUrlFactory) {


    $scope.validation = validationService;

    $scope.http = httpService;
    $scope.popUpArguments = {
        date: new Date(),
        summ: 0,
        currency:0,
        exception: ""
    };

    $scope.init = function () {
        $scope.operationId = items;
        $scope.http.get(apiUrlFactory.GetCurrencies).then(function (response) {
            $scope.popUpArguments.availableCurrency = response.data;
            $scope.popUpArguments.currency = (response.data) ? response.data[0] : null;
        });
    };

    $scope.NullifyArguments = function () {
        for (var key in $scope.popUpArguments) {
            if ($scope.popUpArguments.hasOwnProperty(key)) {
                $scope.popUpArguments[key] = changeFieldValues($scope.popUpArguments[key], key);
            }
        }
        $scope.isAddOperation = null;
    }

    var changeFieldValues = function (param, key) {
        switch (key) {
            case 'summ':
                param = 0;
                break;
            case 'date':
                param = new Date();
                break;
            default:
                param = null;
        }
        return param;
    }
    $scope.ok = function () {
        var postData = createPostData();
        if (!$scope.validation.formIsValid(postData)) {
            $scope.http.post(apiUrlFactory.addDebtTransction, postData, null).then(function (response) {
                $scope.cancel();
                $scope.NullifyArguments();
            }, function (e) {
                console.log(e);
                $scope.NullifyArguments();
            });
        }
    };
    var createPostData = function () {
        var postData = {};
        postData.Date = $scope.popUpArguments.date;
        postData.Sum = $scope.popUpArguments.summ;
        postData.CurrencyName = $scope.popUpArguments.currency.Name;
        postData.OperationId = $scope.operationId;
        return postData;
    };

    $scope.cancel = function () {
        $scope.NullifyArguments();
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
}]);