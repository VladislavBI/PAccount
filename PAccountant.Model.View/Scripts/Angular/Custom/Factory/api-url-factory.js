angular.module('app').factory('apiUrlFactory', [function () {

    me = this;
    
    me.addAccountOperation = '/Accountant/AddOperation';
    me.GetSources = '/Operation/GetSources';
    me.GetCurrencies = '/Operation/GetCurrencies';
    me.GetCategories = '/Operation/GetCategories';

    return me;
}]);