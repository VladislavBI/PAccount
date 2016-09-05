angular.module('app').service('httpService', ['$http', function ($http) {

    me = this;
    me.get = function (url, data, config) {
        url=createUrl(url, data);
        return $http.get(url, config);
    };

    me.post = function (url, data, config) {
        return $http.post(url, data, config);
    };

    var createUrl = function (url, data) {
        url = (data) ? url : url + appendData(data);
    }

    var appendData = function (data) {
        var dataString = null;
        for (var key in data) {
            if (p.hasOwnProperty(key)) {
                updateDataString(data, key, dataString)
            }
        }
    }

    var updateDataString = function (data, key, dataString) {
        if (!stringAlreadyExist) {
            dataString = "?" + key + "=" + data[key];
        }
        else {
            dataString = "?" + key + "=" + data[key];
        }
    }
}]);