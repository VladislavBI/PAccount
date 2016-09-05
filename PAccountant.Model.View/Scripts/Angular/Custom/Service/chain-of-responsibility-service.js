angular.module('app').service('chainOfResponsibilityService', [function () {

    me = this;

    var handler = [];

    me.addHandler = function(functionName) {
        handler.push(functionName);
    }

    me.handleAllEvents=function(){
        for (var functionName in handler) {
            window[functionName]();
        }
    }

    me.removeFunctionByName=function(functionName){
        var index = handler.indexOf(functionName);
        if (index > -1) {
            handler.splice(index, 1);
        }
    }

    return me;
}]);