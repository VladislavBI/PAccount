

angular.module('app').factory('AddDebtOperationFactory',
['validationService', 'httpService', 'apiUrlFactory',
function (validationService, httpService, apiUrlFactory) {

    var me = this;
    me.http = httpService;
    me.validation = validationService;
    me.url = apiUrlFactory;
    me.addOperationUrl = apiUrlFactory.addNewDebtOperation;
    me.isAddOperation = null;
    me.popUpArguments = {
        startDate: new Date(),
        endDate: new Date(),
        availableAgents: null,
        agent: null,
        newAgentCheckBox: null,
        newAgentText: null,
        availableCurrency: null,
        currency: null,
        summ: 0,
        rewardSumm:0,
        commentary: null,
        exception: ""
    };

    me.init = function (isAddOperationParam) {
        me.isAddOperation = isAddOperationParam;
        me.popUpArguments.exception = "";

        me.http.get(me.url.getDebtAgents).then(function (response) {
            me.popUpArguments.availableAgents = response.data;
            me.popUpArguments.agent = (response.data) ? response.data[0] : null;
        });
        me.http.get(me.url.GetCurrencies).then(function (response) {
            me.popUpArguments.availableCurrency = response.data;
            me.popUpArguments.currency = (response.data) ? response.data[0] : null;
        });
    };


    me.createPostData = function () {
        var postData = {};

        postData.DebtType = me.isAddOperation ? 1 : 2;
        postData.StartDate = me.popUpArguments.startDate;
        postData.EndDate = me.popUpArguments.startDate <= me.popUpArguments.endDate ? me.popUpArguments.endDate : me.popUpArguments.startDate;
        postData.AgentName = checkNewParam(me.popUpArguments.newAgentCheckBox, me.popUpArguments.agent, me.popUpArguments.newAgentText);
        postData.CurrencyId = me.popUpArguments.currency.Id;

        postData.StartSum = me.popUpArguments.summ;
        postData.RewardSum = me.popUpArguments.rewardSumm;

        postData.Commentary = me.popUpArguments.commentary;

        return postData;
    };

    var checkNewParam = function (newParamCheckBox, oldParam, newParam) {
        return (newParamCheckBox && newParam && newParam != "") ? newParam : oldParam.Name;
    };

    return me;
}]);