using BussinessLogic.DBModelManagers.Abstract;
using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract;
using BussinessLogic.ViewManagers.Concrete;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class OperationController : Controller
    {
        AddOperationProcessorBase _operatorProcessor;
        ISourceManager _sourceManager;
        ICurrencyManager _currencyManager;
        ICategoryManager _categoryManager;
        IOperationManager _operationManager;

        public OperationController(AddOperationProcessorBase operatorProcessorParam, ISourceManager sourceManagerParam,
            ICurrencyManager currencyManagerParam, ICategoryManager categoryManagerParam, IOperationManager operationManagerParam)
        {
            _operatorProcessor = operatorProcessorParam;
            _sourceManager = sourceManagerParam;
            _currencyManager = currencyManagerParam;
            _categoryManager = categoryManagerParam;
            _operationManager = operationManagerParam;
        }

        // GET: Accountant
        [HttpPost]
        public void AddOperation(AddOperationModel model)
        {
            _operatorProcessor.addNewOperation(model, User.Identity.Name);
        }

        public JsonResult GetSources()
        {
            var sourceList = _sourceManager.GetAllInList();
            return Json(sourceList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrencies()
        {
            var currencyList = _currencyManager.GetAllInList();
            return Json(currencyList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories(bool isAddOperation)
        {
            var categoriesList = _categoryManager.GetAllInList(isAddOperation ? OperationType.Income : OperationType.Outcome);
            return Json(categoriesList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMonthTotalFlow()
        {
            var totalFlowList = _operationManager.GetMonthTotalFlow();
            return Json(totalFlowList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetToTalFlowByMonth()
        {
            var totalFlowList = _operationManager.GetToTalFlowByMonth();
            return Json(totalFlowList, JsonRequestBehavior.AllowGet);
        }
    }
}