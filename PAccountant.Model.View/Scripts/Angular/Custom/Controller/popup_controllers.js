/*property
    GetCategories, GetCurrencies, GetSources, NullifyArguments,
    availableCategory, availableCurrency, availableSource, category,
    commentary, controller, currency, data, date, get, http, init,
    isAddOperation, module, newCategoryCheckBox, newCategoryText,
    newCurrencyCheckBox, newCurrencyRate, newCurrencyText, newSourceCheckBox,
    newSourceText, popUpArguments, source, summ, then, url, validation
*/
angular.module('app').controller('addOperationController',
['$scope', '$uibModalInstance', 'items', 'httpService', 'validationService', 'apiUrlFactory',
function ($scope, $uibModalInstance, items, httpService, validationService, apiUrlFactory) {


    $scope.validation = validationService;
    $scope.url = apiUrlFactory;
    $scope.isAddOperation = null;
    $scope.http = httpService;
    $scope.popUpArguments = {
        date: new Date(),
        availableSource: null,
        source: null,
        newSourceCheckBox: null,
        newSourceText: null,
        availableCategory: null,
        category: null,
        newCategoryCheckBox: null,
        newCategoryText: null,
        availableCurrency: null,
        currency: null,
        newCurrencyCheckBox: null,
        newCurrencyText: null,
        newCurrencyRate: 1,
        summ: 0,
        commentary: null,
        exception:""
    };

    $scope.init = function () {
        $scope.isAddOperation = items;
        $scope.popUpArguments.exception = "";

        $scope.http.get($scope.url.GetSources).then(function (response) {
            $scope.popUpArguments.availableSource = response.data;
            $scope.popUpArguments.source = (response.data) ? response.data[0] : null;
        });
        $scope.http.get($scope.url.GetCurrencies).then(function (response) {
            $scope.popUpArguments.availableCurrency = response.data;
            $scope.popUpArguments.currency = (response.data) ? response.data[0] : null;
        });
        $scope.http.get($scope.url.GetCategories, null, { isAddOperation: $scope.isAddOperation }).then(function (response) {
            $scope.popUpArguments.availableCategory = response.data;
            $scope.popUpArguments.category = (response.data) ? response.data[0] : null;
        });

        
    };

    $scope.NullifyArguments = function () {
        for (var key in $scope.popUpArguments) {
            if (p.hasOwnProperty(key)) {
                changeFieldValues($scope.popUpArguments[key]);
            }
        }
        $scope.isAddOperation = null;
    }

    var changeFieldValues = function (param) {
        switch (typeof param) {
            case 'Number':
                param = 0;
                break;
            case 'Date':
                param = new Date();
                break;
            default:
                param = null;
        }
    }
    $scope.ok = function () {
        postData = $scope.popUpArguments;
        postData.isAddOperation = $scope.isAddOperation;
        postData = createPostData(postData);
        if (!$scope.validation.formIsValid(postData)) {
            $scope.http.post($scope.url.addAccountOperation, postData, null).then(function (response) {
                $scope.cancel();
            });
        }
    };

    var createPostData = function (dataParam) {
        var postData = {};

        postData.IsAddOperation = dataParam.isAddOperation;
        postData.Date = dataParam.date;
        postData.Source = checkNewParam(dataParam.newSourceCheckBox, dataParam.source, dataParam.newSourceText);
        postData.Category = checkNewParam(dataParam.newCategoryCheckBox, dataParam.category, dataParam.newCategoryText);
        postData.Currency = checkNewParam(dataParam.newCurrencyCheckBox, dataParam.currency);
        postData.CurrencyRate = dataParam.newCurrencyRate;

        postData.Summ = dataParam.summ;
        postData.Commentary = dataParam.commentary;

        return postData;
    };

    var checkNullArguments = function () {

    }

    var checkNewParam = function (newParamCheckBox, oldParam, newParam) {
        return (newParamCheckBox && newParam && newParam != "") ? newParam : oldParam.Name;
    };

    $scope.cancel = function () {
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
}]);