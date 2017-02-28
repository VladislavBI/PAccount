(function () {
    var app=angular.module("app", ["ngAnimate", "ui.bootstrap"]);
    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.defaults.headers.common = { 'X-Requested-With': 'XMLHttpRequest' };
    }]);
}());