angular.module('app').service('modalService', ['$uibModal', function ($uibModal) {

    me = this;

    me.open = function (templateUrl, controllerName, data) {
        controllerName =(controllerName)?controllerName: 'DefaultController';
        var ModalInstance = $uibModal.open({
            animation: true,
            templateUrl: templateUrl,
            controller: controllerName,
            controllerAs:'ctrl',
            //appendTo:     //appends the modal to a element
            backdrop: false,  //disables modal closing by click on the background
            //size:size,
            //template: 'myModal.html',
            //keyboard:true,     //dialog box is closed by hitting ESC key
            //openedClass:'nameofClass',  //class styles are applyed after dialog opens.
            resolve: {
                items: function () {
                    //we can send data from here to controller using resolve...
                    return data;
                }
            }
            //windowClass:'AddtionalClass',   //class that is added to styles the window template
            //windowTemplateUrl:'Modaltemplate.html',    template overrides the modal template
        });
    };

    return me;
}]);

angular.module('app').controller('DefaultController', function ($scope, $uibModalInstance, items) {
    $scope.ok = function () {
        $uibModalInstance.close($scope.data);
    };
    $scope.cancel = function () {
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
});