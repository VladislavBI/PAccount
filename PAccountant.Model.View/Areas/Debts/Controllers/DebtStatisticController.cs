using BussinessLogic.ViewManagers.Concrete.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Debts.Controllers
{
    public class DebtStatisticController : Controller
    {
        DebtStatisticManager _statisticManager;
        public DebtStatisticController()
        {
            _statisticManager = new DebtStatisticManager();
        }
        // GET: Debts/Statistic
        public ActionResult GetDebtsOperationsList()
        {
            return Json(_statisticManager.GetDebtTable(), JsonRequestBehavior.AllowGet);
        }
    }
}