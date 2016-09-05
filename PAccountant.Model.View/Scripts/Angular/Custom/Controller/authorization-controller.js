angular.module('app').controller('authorizationController', ['$scope', '$http', 'validationService',  function ($scope, $http, validationService) {
  
    $scope.validation = validationService;

}]);