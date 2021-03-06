﻿angular.module('app').controller('operationTableController', 
    ['$scope', 'httpService', 'apiUrlFactory', '$rootScope',
function ($scope, httpService, apiUrlFactory, $rootScope) {
    var self = this;


    $rootScope.$on("pAcUpdated", function () {
        $("#monthOperationStatistic").jsGrid("loadData");
    });
    return self;
}]);

$("#monthOperationStatistic").jsGrid({
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
                url: "Statistic/GetMonthStatistic",
                dataType: "json"
            }).done(function (response) {
                d.resolve(response);
            });
            autoload: false;
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
                    return value.toFixed(2);
                }
            },
            { name: "Comment", type: "text", width: 150 },
    ]
});