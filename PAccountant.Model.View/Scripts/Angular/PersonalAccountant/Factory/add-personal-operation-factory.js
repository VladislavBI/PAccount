

angular.module('app').factory('AddPersonalOperationFactory',
['validationService', 'httpService', 'apiUrlFactory',
function (validationService, httpService, apiUrlFactory) {

    var me = this;
    me.http = httpService;
    me.validation = validationService;
    me.addOperationUrl = apiUrlFactory.addAccountOperation;
    me.url = apiUrlFactory;
    me.isAddOperation = null;
    me.templates = {
        availableTemplate: [],
        template: {},
        newTemplateCheckBox: null,
        newTemplateName: null
    };
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
        me.http.get(me.url.getAllTemplates, null, { template: 1 }).then(function (response) {
            me.templates.availableTemplate = response.data;
            me.templates.template = (response.data) ? response.data[0] : null;
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
        postData.Template =
            {
                Name: me.templates.Name,
                IsTemplateCreated: me.templates.IsTemplateCreated
            };

        postData.Summ = me.popUpArguments.summ;
        postData.Commentary = me.popUpArguments.commentary;

        return postData;
    };

    var checkNewParam = function (newParamCheckBox, oldParam, newParam) {
        return (newParamCheckBox && newParam && newParam != "") ? newParam : oldParam.Name;
    };

    me.mapTemplate = function () {
        me.popUpArguments.date = me.templates.templates.Date;
        me.popUpArguments.source = me.popUpArguments.availableSource.filter(function (el) {
            return el.id == me.templates.templates.SourceId;
        })[0];
        me.popUpArguments.category = me.popUpArguments.availableCategory.filter(function (el) {
            return el.Id == me.templates.templates.CategoryId;
        })[0];
        me.popUpArguments.currency = me.popUpArguments.availableCurrency.filter(function (el) {
            return el.Id == me.templates.templates.CurrencyId;
        })[0];
        me.popUpArguments.summ = me.templates.template.Sum;
        me.popUpArguments.commentary = me.templates.templates.Commentary;
        me.nullifyTemplate();
    };

    me.nullifyTemplate = function () {
        me.templates.templates = {};
        me.templates.newTemplateCheckBox = false;
        me.templates.newTemplateName = null;
    };

    return me;
}]);