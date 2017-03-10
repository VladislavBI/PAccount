angular.module('app').factory('apiUrlFactory', [function () {

    me = this;
    
    me.addAccountOperation = '/Operation/AddOperation';
    me.GetSources = '/Operation/GetSources';
    me.GetCurrencies = '/Operation/GetCurrencies';
    me.GetCategories = '/Operation/GetCategories';
    me.getTotalOperationsSumm = '/Statistic/GetOperationsSumm';
    me.getCurrenciesOperationsSumms = '/Statistic/GetCurrenciesOperationsSumms';
    me.getDetailedSourceInfo = '/Statistic/GetDetailedSourceInfo';
    me.detailedSourceInfo = '/Statistic/DetailedSourceInfo';
    me.getExtremums = '/Statistic/GetMonthExtremums';
    me.getMonthTotalFlow = '/Operation/GetMonthTotalFlow';
    me.getToTalFlowByMonth = '/Operation/GetToTalFlowByMonth';
    me.getMonthCategoriesFlow = '/Statistic/GetMonthCategoriesFlow';
    me.getMonthSourceFlow = '/Statistic/GetMonthSourceFlow';
    me.getMonthCurrenciesFlow = '/Statistic/GetMonthCurrenciesFlow';

    return me;
}]);