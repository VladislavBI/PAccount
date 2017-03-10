angular.module('app').service('converterService', [function () {

    var me = this;

    me.convertObjectToArray = function (objectToConvert) {
        if (!objectToConvert) {
            return [];
        }
        var arrayToReturn = [];
        for (var key in objectToConvert) {            
            if (objectToConvert.hasOwnProperty(key)) {
                arrayToReturn.push(objectToConvert[key]);
            }          
        }
        return arrayToReturn;
    }

    me.convertObjectListToArrayList = function (objectList) {
        if (!objectList) {
            return [];
        }
        var arrayToReturn = [];
        for (var object in objectList) {
            arrayToReturn.push(me.convertObjectToArray(objectList[object]));
        }
        return arrayToReturn;
    }
    return me;

}]);