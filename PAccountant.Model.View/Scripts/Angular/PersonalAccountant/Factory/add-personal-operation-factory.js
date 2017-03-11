

angular.module('app').factory('AddPersonalOperationFactory', 
['validationService', 'httpService', 'apiUrlFactory',
function (validationService, httpService, apiUrlFactory) {

    var me = this;
    me.http = httpService;
    me.validation = validationService;
    me.addOperationUrl = apiUrlFactory.addAccountOperation;
    me.url = apiUrlFactory;
    me.isAddOperation = null;
    me.popUpArguments = {
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
        exception: ""
    };

    me.init = function (isAddOperationParam) {
        me.isAddOperation = isAddOperationParam;
        me.popUpArguments.exception = "";

        me.http.get(me.url.GetSources).then(function (response) {
            me.popUpArguments.availableSource = response.data;
            me.popUpArguments.source = (response.data) ? response.data[0] : null;
        });
        me.http.get(me.url.GetCurrencies).then(function (response) {
            me.popUpArguments.availableCurrency = response.data;
            me.popUpArguments.currency = (response.data) ? response.data[0] : null;
        });
        me.http.get(me.url.GetCategories, null, { isAddOperation: me.isAddOperation }).then(function (response) {
            me.popUpArguments.availableCategory = response.data;
            me.popUpArguments.category = (response.data) ? response.data[0] : null;
        });
    };


    me.createPostData = function () {
        var postData = {};

        postData.IsAddOperation = me.isAddOperation;
        postData.Date = me.popUpArguments.date;
        postData.Source = checkNewParam(me.popUpArguments.newSourceCheckBox, me.popUpArguments.source, me.popUpArguments.newSourceText);
        postData.Category = checkNewParam(me.popUpArguments.newCategoryCheckBox, me.popUpArguments.category, me.popUpArguments.newCategoryText);
        postData.Currency = checkNewParam(me.popUpArguments.newCurrencyCheckBox, me.popUpArguments.currency);
        postData.CurrencyRate = me.popUpArguments.newCurrencyRate;

        postData.Summ = me.popUpArguments.summ;
        postData.Commentary = me.popUpArguments.commentary;

        return postData;
    };

    var checkNewParam = function (newParamCheckBox, oldParam, newParam) {
        return (newParamCheckBox && newParam && newParam != "") ? newParam : oldParam.Name;
    };

    return me;
}]);