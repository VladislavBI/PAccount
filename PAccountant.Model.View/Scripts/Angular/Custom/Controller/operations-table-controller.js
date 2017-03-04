angular.module('app').controller('operationTableController',
    ['$scope', 'httpService', 'apiUrlFactory',
function ($scope, httpService, apiUrlFactory) {
    var self = this;



    return self;
}]);

$("#monthOperationStatistic").jsGrid({
    height: "auto",
    width: "100%",

    filtering: true,
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
                url: "Statistic/GetMonthStatistic",
                dataType: "json"
            }).done(function (response) {
                d.resolve(response);
            });

            return d.promise();
        }
    },

    fields: [
            { name: "Date", type: "text" },
            { name: "Source", type: "text", width: 150 },
            { name: "Category", type: "text", width: 150 },
            { name: "Currency", type: "text", width: 150 },
            {
                name: "Summ", type: "number", width: 100,
                itemTemplate: function (value) {
                    return value.toFixed(2) + "$";
                }
            },
            { name: "Comment", type: "text", width: 150 },
    ]
});