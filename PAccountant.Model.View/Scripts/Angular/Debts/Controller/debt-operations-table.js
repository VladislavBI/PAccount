angular.module('app').controller('debtTableController',
    ['$scope', 'httpService', 'apiUrlFactory', '$compile', 'modalService', '$uibModal',
function ($scope, httpService, apiUrlFactory, $compile, modalService, $uibModal) {
    var self = this;

    $("#fullDebtStatistic").jsGrid({
        height: "auto",
        width: "100%",

        filtering: false,
        editing: false,
        sorting: true,
        paging: true,
        autoload: true,

        pageSize: 10,
        pageButtonCount: 5,


        controller: {
            loadData: function () {
                var d = $.Deferred();

                $.ajax({
                    url: "DebtStatistic/GetDebtsOperationsList",
                    dataType: "json"
                }).done(function (response) {
                    d.resolve(response);
                });

                return d.promise();
            }
        },

        fields: [
                { name: "Name", type: "text" },
                { name: "EndDate", type: "text", width: 150 },
                { name: "DebtType", type: "text", width: 150 },
                {
                    name: "AllSum", type: "number", width: 150, itemTemplate: function (value) {
                        return value.toFixed(2) + "$"
                    }
                },
                {
                    name: "LeftToReturn", type: "number", width: 150, itemTemplate: function (value) {
                        return value.toFixed(2) + "$"
                    }
                },
                { name: "EndDate", type: "text", width: 100 },
                { name: "Comment", type: "text", width: 150 },
                {
                    name: "Detailed", type: "text", width: 150,
                    itemTemplate: function (value) {
                        return $compile("<a  class='btn btn-default' ng-click='debtTable.openDetailedInfo(" + value + ")'> Detailed </a><a  class='btn btn-default' ng-click='debtTable.addTransaction(" + value + ")'> Add Transaction </a>")($scope);
                    }
                }
        ]
    });
    self.openDetailedInfo = function (operationId) {
        window.open(apiUrlFactory.getDebtTransctionDetailed + '?operationIdParam=' + operationId, '_blank');
    }
    self.addTransaction = function (operationId) {
        modalService.open('addDebtTransactionPopup.html', 'addDebtTransactionController', operationId);

    }
    return self;
}]);

