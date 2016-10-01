using BussinessLogic.LogicManagers.State;
using PAccountant.Model.Infrastructure.Abstract;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class OperationController : Controller
    {
        IDBStateManager _stateManager;
        public OperationController(IDBStateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public JsonResult GetSources()
        {
            var sourceList = _stateManager.DbMangerList[DbNames.Source].GetAllInList();
            return Json(sourceList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrencies()
        {
            var currencyList = _stateManager.DbMangerList[DbNames.Currency].GetAllInList();
            return Json(currencyList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories()
        {
            var categoriesList = _stateManager.DbMangerList[DbNames.Category].GetAllInList();
            return Json(categoriesList, JsonRequestBehavior.AllowGet);
        }
    }
}