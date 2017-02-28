angular.module('app').service('httpService', ['$http', function ($http) {

    me = {};

    me.get = function (url, config, data) {
        //url=createUrl(url, data);
        if (!config) {
        config = {};
        }
        if (data) {
            config.params = data;
        }
        return $http.get(url, config);
    };

    me.post = function (url, data, config) {
        return $http.post(url, data, config);
    };

    //var createUrl = function (url, data) {
    //    url = (!data) ? url : url + appendData(data);
    //};

    ////create params
    //var appendData = function (data) {
    //    var dataString = null;
    //    for (var key in data) {
    //        if (p.hasOwnProperty(key)) {
    //            updateDataString(data, key, dataString)
    //        }
    //    }
    //};

    //var updateDataString = function (data, key, dataString) {
    //    if (!stringAlreadyExist) {
    //        dataString = "?" + key + "=" + data[key];
    //    }
    //    else {
    //        dataString = "?" + key + "=" + data[key];
    //    }
    //}
    return me;
}]);