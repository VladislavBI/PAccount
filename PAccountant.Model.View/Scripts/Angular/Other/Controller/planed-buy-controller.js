angular.module('app').controller('PlanedBuyController',
['httpService', 'apiUrlFactory',
function (httpService, apiUrlFactory) {

    var me = {};
    me.http = httpService;
    me.url = apiUrlFactory;

    me.newSum = {
        Sum: 0,
        currency: {}
    }
    me.newPlan = {
        Sum: 0,
        Name: null,
        currency: {}
    }
    me.init = function () {
        me.http.get(me.url.getPlanes).then(function (result) {
            if (result) {
                me.wishList = result.data;
            }
        })
        me.http.get(me.url.getStoredMoney).then(function (result) {
            if (result) {
                me.storedMoney = result.data;
            }
        })
        me.http.get(me.url.GetCurrencies).then(function (result) {
            if (result) {
                me.availableCurrency = result.data;
                me.newSum.currency = me.availableCurrency[0];
                me.newPlan.currency = me.availableCurrency[0];
            }
        })
    };


    me.addSum = function () {
        var model = {
            Sum: me.newSum.Sum,
            CurrencyName: me.newSum.currency.Name
        }
        me.http.post(me.url.addMoneyToStore,
            { moneyModel: model });
    }
    me.addNewPlan = function () {
        var model = {
            Sum: me.newPlan.Sum,
            Name: me.newPlan.Name,
            CurrencyName: me.newPlan.currency.Name
        }
        me.http.post(me.url.addPlan,
            { model: model });
    }
    return me;
}]);