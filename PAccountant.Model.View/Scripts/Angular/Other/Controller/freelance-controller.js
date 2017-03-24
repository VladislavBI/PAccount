angular.module('app').controller('FreelanceController',
['httpService', 'apiUrlFactory', 'modalService', '$uibModal',
function (httpService, apiUrlFactory, modalService, $uibModal) {

    var me = {};
    me.http = httpService;
    me.url = apiUrlFactory;

    me.newProject = {
        Name: null,
        SumPerHour: 0,
        TotalHours: 0,
        currency: 0,
        CurrencyId: 0
    }
    me.newPlan = {
        Sum: 0,
        Name: null,
        currency: {}
    }
    me.init = function () {
        me.http.get(me.url.getProjects).then(function (result) {
            if (result) {
                me.projectsList = result.data;
            }
        });
        me.http.get(me.url.GetCurrencies).then(function (result) {
            if (result) {
                me.availableCurrency = result.data;
                me.newProject.currency = me.availableCurrency[0];
            }
        });
    };


    me.addPayement = function (project) {
        modalService.open('freelancePaymentPopup.html', 'freelancePaymentController',
            {
                projectId: project.Id,
                sumPerHour: project.SumPerHour,
                unpaidHours: project.UnpayedHours
            });
    }
    me.editProject = function (project) {
        modalService.open('editFreelancePopup.html', 'editFreelanceController', project);
    }
    me.addNewProject = function () {
        me.newProject.CurrencyId = me.newProject.currency.Id;
        me.http.post(me.url.addNewProject,
            {
                model: me.newProject
            });
    }
    return me;
}]);