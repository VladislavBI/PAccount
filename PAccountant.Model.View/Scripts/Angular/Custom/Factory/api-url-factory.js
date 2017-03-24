angular.module('app').factory('apiUrlFactory', [function () {

    me = this;
    
    me.addAccountOperation = '/Operation/AddOperation';
    me.GetSources = '/Operation/GetSources';
    me.GetCurrencies = '/Operation/GetCurrencies';
    me.GetCategories = '/Operation/GetCategories';
    me.getTotalOperationsSumm = '/Statistic/GetOperationsSumm';
    me.getCurrenciesOperationsSumms = '/Statistic/GetCurrenciesOperationsSumms';
    me.getDetailedSourceInfo = '/Statistic/GetDetailedSourceInfo';
    me.detailedSourceInfo = '/Statistic/DetailedSourceInfo';
    me.getExtremums = '/Statistic/GetMonthExtremums';
    me.getMonthTotalFlow = '/Operation/GetMonthTotalFlow';
    me.getToTalFlowByMonth = '/Operation/GetToTalFlowByMonth';
    me.getMonthCategoriesFlow = '/Statistic/GetMonthCategoriesFlow';
    me.getMonthSourceFlow = '/Statistic/GetMonthSourceFlow';
    me.getMonthCurrenciesFlow = '/Statistic/GetMonthCurrenciesFlow';
    me.getCurrentPageType = '/Accountant/GetCurrentPageType';
    me.getAllTemplates = '/Operation/GetTemplatesForOperations'

    me.getDebtAgents = '/Debts/Agent/GetAgentsList';
    me.addNewDebtOperation = '/Debts/DebtOperation/AddOperation';
    me.getDebtsTotal = '/Debts/DebtOperation/GetDebtsTotal';
    me.addDebtTransction = '/Debts/DebtTransaction/AddTransction';
    me.getDebtTransctionDetailed = '/Debts/DebtTransaction/DetailedTransactionList';
    me.getDebtsNotifications = '/Debts/Notification/GetNotifications';

    me.getPlanes = '/Investment/Plan/GetPlanes';
    me.getStoredMoney = '/Investment/Plan/GetStoredMoney';
    me.addPlan = '/Investment/Plan/AddPlan';
    me.addMoneyToStore = '/Investment/Plan/AddMoneyToStore';

    me.addNewProject = '/Investment/Project/AddNewProject';
    me.getProjects = '/Investment/Project/GetProjects';
    me.addPayment = '/Investment/Project/AddPayment';
    me.changeProjectStatus = '/Investment/Project/ChangeProjectStatus';
    me.addHours = '/Investment/Project/AddHours';
    me.changeProjectData = '/Investment/Project/ChangeProjectData';

    return me;
}]);