using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Concrete.Debts;
using System;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Debts.Controllers
{
    public class DebtTransactionController : Controller
    {
        DebtTransactionManager _transactionManager;

        public DebtTransactionController()
        {
            _transactionManager = new DebtTransactionManager();
        }
        // GET: Debts/DebtTransaction
        [HttpPost]
        public void AddTransction(DebtTransactionModel model)
        {
            _transactionManager.AddTransaction(model);
        }
        [HttpGet]
        public ActionResult DetailedTransactionList(int operationIdParam)
        {
            Session["transactionOperationParam"] = operationIdParam;
            return View();
        }
        public ActionResult GetTransactionsList()
        {
            var operationId=Convert.ToInt32(Session["transactionOperationParam"]);

            return Json(_transactionManager.GetTransactionsList(operationId), JsonRequestBehavior.AllowGet);
        }
    }
}