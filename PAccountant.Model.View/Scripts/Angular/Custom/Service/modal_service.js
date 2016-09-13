angular.module('app').service('modalService', ['$uibModal', function ($uibModal) {

    me = this;

    me.open = function (resolveData, controllerName, ariadescribedby, templateurl, size) {
        var modalInstance = $uibModal.open({
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: ariadescribedby,
            templateUrl: "myModalContent.html",
            controller: controllerName,
            controllerAs: '$ctrl',
            size: size,
            resolve: resolveData
        });
    };

    return me;
}]);