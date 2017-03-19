angular.module('app').controller('debtTransactionController', ['$scope', 'httpService', 'apiUrlFactory',
    function ($scope, httpService, apiUrlFactory) {
        var self = this;
        
        return self;
    }]);
$("#fullDebtTransactionStatistic").jsGrid({
    height: "auto",
    width: "100%",

    filtering: false,
    editing: false,
    sorting: true,
    paging: true,
    autoload: true,

    pageSize: 20,
    pageButtonCount: 5,


    controller: {
        loadData: function () {
            var d = $.Deferred();

            $.ajax({
                url: "GetTransactionsList",
                dataType: "json"
            }).done(function (response) {
                d.resolve(response);
            });

            return d.promise();
        }
    },

    fields: [
            { name: "DateString", type: "text" },
            { name: "Sum", type: "number", itemTemplate: function (value) {
                return value.toFixed(2) + "$" }
            },
            {
                name: "Left", type: "number", itemTemplate: function (value) {
                    return value.toFixed(2) + "$"
                }
            }
    ]
});