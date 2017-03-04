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

    return me;
}]);