using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.LogicManagers.State;
using BussinessLogic.ViewManagers.Abstract;
using BussinessLogic.ViewManagers.Concrete;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class OperationController : Controller
    {
        IDBStateManager _stateManager;
        IMapperManager _mapperManager;
        public OperationController(IDBStateManager stateManager, IMapperManager mapperManager)
        {
            _stateManager = stateManager;
            _mapperManager = mapperManager;
        }

        // GET: Accountant
        [HttpPost]
        public void AddOperation(AddOperationModel model)
        {
            AddOperationProcessor manager = new AddOperationProcessor(_stateManager, _mapperManager);
            manager.addNewOperation(model, User.Identity.Name);
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

        public JsonResult GetCategories(bool isAddOperation)
        {
            var categoriesList = _stateManager.DbMangerList[DbNames.Category].GetAllInList(isAddOperation?OperationType.Income:OperationType.Outcome);
            return Json(categoriesList, JsonRequestBehavior.AllowGet);
        }

       
    } 
}