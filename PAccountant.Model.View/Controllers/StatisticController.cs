using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class StatisticController : Controller
    {
        StatisticManagerBase _statisticManager;
        ExtremumsManagerBase _managerEx;
        ISourceManager _sourceManager;
        ICategoryManager _categoryManager;
        ICurrencyManager _currencyManager;
        public StatisticController(StatisticManagerBase statisticManagerParam, ExtremumsManagerBase managerExParam,
            ISourceManager sourceManagerParam, ICategoryManager categoryManagerParam, ICurrencyManager currencyManagerParam)
        {
            _statisticManager = statisticManagerParam;
            _managerEx = managerExParam;
            _sourceManager = sourceManagerParam;
            _categoryManager = categoryManagerParam;
            _currencyManager = currencyManagerParam;
        }

        public JsonResult GetOperationsSumm()
        {
            return Json(_statisticManager.GetTotalBalance("usd"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetailedSourceInfo()
        {
            return View();
        }
        public JsonResult GetCurrenciesOperationsSumms()
        {
            var a = _statisticManager.GetDetailedSourceInfo();


            return Json(_statisticManager.GetCurrenciesOperationsSumm(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDetailedSourceInfo()
        {
            return Json(_statisticManager.GetDetailedSourceInfo(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMonthStatistic()
        {
            return Json(_statisticManager.GetMonthStatistics(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMonthExtremums()
        {
            ExtremumsModelsList extremumsList = new ExtremumsModelsList();
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxExpenditureCategory());
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxExpenditureCurrency());
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxExpenditureSource());
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxIncome());
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxOutcome());
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxProfitableCategory());
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxProfitableCurrency());
            extremumsList.ExtremumsList.Add(_managerEx.GetMaxProfitableSource());
            return Json(extremumsList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMonthCategoriesFlow()
        {
            return Json(_categoryManager.GetMonthFlow(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMonthSourceFlow()
        {
            return Json(_sourceManager.GetMonthFlow(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMonthCurrenciesFlow()
        {
            return Json(_currencyManager.GetMonthFlow(), JsonRequestBehavior.AllowGet);
        }
    }
}