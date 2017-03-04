angular.module('app').factory('tableFactory', [function () {

    me = this;

    me.currentPage = 1;
    me.elementsPerPage = 0;
    me.maxPageNumber = 0;
    me.tableElements = [];

    me.init = function (tableElementParam, elementsPerPageParam) {
        me.elementsPerPage = elementsPerPageParam ? elementsPerPageParam : 10;
        me.tableElements = tableElementParam;
        me.maxPageNumber = (me.tableElements.elementsPerPage / me.elementsPerPage).toFixed(0);
    }
    me.changeTableElements = function (newTableElementsParam) {
        me.tableElements = newTableElementsParam ? newTableElementsParam : me.tableElements;
        me.maxPageNumber = (me.tableElements.elementsPerPage / me.elementsPerPage).toFixed(0);
    }
    me.getPage = function (pageNumber) {
        if (me.maxPageNumber > pageNumber) {
            me.currentPage = pageNumber;
        }
        else {
            me.currentPage = me.maxPageNumber;
        }
        return getElementsForSelectedPage(me.currentPage);
    }

    var getElementsForSelectedPage = function (pageNumberParam) {
        if (pageNumberParam > 0) {
            var tempArray = [];
            var startIndexForNewArray = (pageNumberParam - 1) * me.elementsPerPage;
            for (var i = startIndexForNewArray, j = 0; i < me.elementsPerPage * me.elementsPerPage; i++, j++) {
                tempArray[j] = me.tableElements[i];
            }
            return tempArray;
        }
        else {
            return null;
        }
    }
    me.nextPage = function () {
        if (me.currentPage < me.maxPageNumber) {
            me.currentPage += 1;
            getElementsForSelectedPage(me.currentPage)
        }
    }
    me.prevPage = function () {
        if (me.currentPage > 0) {
            me.currentPage -= 1;
            getElementsForSelectedPage(me.currentPage)
        }
    }
    return me;
}]);