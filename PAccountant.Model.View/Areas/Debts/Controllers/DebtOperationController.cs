using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using BussinessLogic.ViewManagers.Abstract.Debts;
using BussinessLogic.ViewManagers.Concrete.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Debts.Controllers
{
    public class DebtOperationController : Controller
    {
        AddOperationProcessorBase _addOperationProcessor;
        DebtStatisticManager _statisticManager;
        public DebtOperationController(IDBManager dbManagerParam, ICurrencyManager currencyManagerParam, IAgentsManager agentsManagerParam)
        {
            _addOperationProcessor = new AddDebtOperationProcessor(dbManagerParam, currencyManagerParam, agentsManagerParam );
            _statisticManager = new DebtStatisticManager();
        }
       
        [HttpPost]
        public void AddOperation(AddDebtModel debtModel)
        {
            _addOperationProcessor.addNewOperation(debtModel, User.Identity.Name);
        }

        public JsonResult GetDebtsTotal()
        {
           return Json(_statisticManager.GetTotals(), JsonRequestBehavior.AllowGet);
        }

    }
}