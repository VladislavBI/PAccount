/*property
    GetCategories, GetCurrencies, GetSources, NullifyArguments,
    availableCategory, availableCurrency, availableSource, category,
    commentary, controller, currency, data, date, get, http, init,
    isAddOperation, module, newCategoryCheckBox, newCategoryText,
    newCurrencyCheckBox, newCurrencyRate, newCurrencyText, newSourceCheckBox,
    newSourceText, popUpArguments, source, summ, then, url, validation
*/
angular.module('app').controller('addOperationController',
['$scope', '$uibModalInstance', 'items', 'httpService', 'validationService', 'apiUrlFactory', 'AddPersonalOperationFactory', 'AddDebtOperationFactory',
function ($scope, $uibModalInstance, items, httpService, validationService, apiUrlFactory, AddPersonalOperationFactory, AddDebtOperationFactory) {


    $scope.validation = validationService;
    $scope.addFactory = {};
    $scope.url = apiUrlFactory;
    $scope.isAddOperation = null;
    $scope.http = httpService;
    $scope.popUpArguments = {};

    $scope.init = function () {
        $scope.isAddOperation = items.isAdd;
        chooseFactoryType(items.type);
        $scope.addFactory.init(items.isAdd);
        $scope.popUpArguments = $scope.addFactory.popUpArguments;
        $scope.templates = $scope.addFactory.templates;
    };

    $scope.NullifyArguments = function () {
        for (var key in $scope.popUpArguments) {
            if ($scope.popUpArguments.hasOwnProperty(key)) {
                $scope.popUpArguments[key] = changeFieldValues($scope.popUpArguments[key], key);
            }
        }
        $scope.isAddOperation = null;
    }

    var chooseFactoryType = function (type) {
        switch (type) {
            case "personal":
                $scope.addFactory = AddPersonalOperationFactory;
                break;
            case "debt":
                $scope.addFactory = AddDebtOperationFactory;
                break;
            default:
                $scope.addFactory = AddPersonalOperationFactory;
                break;
        }
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
        var postData = $scope.addFactory.createPostData();
        if (!$scope.validation.formIsValid(postData)) {
            $scope.http.post($scope.addFactory.addOperationUrl, postData, null).then(function (response) {
                $scope.cancel();
                $scope.NullifyArguments();
            }, function (e) {
                console.log(e);
                $scope.NullifyArguments();
            });
        }
    };

    $scope.appendTemplate = function () {
        $scope.addFactory.mapTemplate();
    }

    $scope.cancel = function () {
        $scope.NullifyArguments();
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
}]);