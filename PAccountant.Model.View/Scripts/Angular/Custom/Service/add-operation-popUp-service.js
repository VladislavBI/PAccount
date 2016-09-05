angular.module('app').service('addOperationPopUpService', ['$rootScope', function ($rootScope) {

    me = this;

   
    me.isAddOperation = null;
    me.popUpArguments = {
        date: new Date(),
        source: null,
        newSourceCheckBox: null,
        newSourceText: null,
        category: null,
        newCategoryCheckBox: null,
        newCategoryText: null,
        currency: null,
        newCurrencyCheckBox: null,
        newCurrencyText: null,
        summ: 0,
        commentary: null
    };
    me.okCallback=null;

    me.init = function (callback, isAddOperation) {
        me.isAddOperation = isAddOperation;
        me.okCallback = callback;
        $rootScope.$broadcast('isAddOperation:updated', me.isAddOperation);
    };

    me.NullifyArguments = function() {
        for (var key in me.popUpArguments) {
            if (p.hasOwnProperty(key)) {
                changeFieldValues(me.popUpArguments[key]);
            }
        }
        me.isAddOperation = null;
        me.okCallback = null;
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

    return me;
}]);