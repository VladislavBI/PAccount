angular.module('app').service('validationService', ['$http', function ($http) {

    me = this;
    me.formIsValid=function(Form){
        if (Form.$valid) {
            return true;
        }
        else {
            return false;
        }
    }

    me.variableIsTrue = function () {
        for (var i = 0; i < arguments.length; i++) {
            if (!arguments[i]) {
                return false;
            }
        }
        return true;
    }

    me.formContainsNullParams = function (objectForCheck, exceptionsNamesArray) {
        exceptionsArray = exceptionsArray ? exceptionsArray : [];
        for (var key in objectForCheck) {
            if (p.hasOwnProperty(key) && !exceptionsNamesArray.includes(key)&&!objectForCheck[key]) {
                return key + " should contain value";
            }
        }
        return false;
    }
}]);