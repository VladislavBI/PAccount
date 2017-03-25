using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract.Investment;
using PAccountant.BussinessLogic.Infrastructure.Abstract;
using System;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Investment.Controllers
{
    public class PlanController : Controller
    {
        PlanManagerBase _planManager;
        IMapperHelper _mapperManager;
        public PlanController(PlanManagerBase planManagerParam, IMapperHelper mapperManagerParam)
        {
            _planManager = planManagerParam;
            _mapperManager = mapperManagerParam;
        }
        // GET: Debts/Plan
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void AddPlan(AddPlanToStoreModel model)
        {
            AddPlanToStoreWithUser modelToSend = _mapperManager.MapModel<AddPlanToStoreModel, AddPlanToStoreWithUser>(model);
            modelToSend.UserId = Convert.ToInt32(User.Identity.Name);
            _planManager.AddPlan(modelToSend);
        }
        public JsonResult GetPlanes()
        {
            var planes = _planManager.GetPlanes(Convert.ToInt32(User.Identity.Name));
            var a = User.Identity.Name;

            return Json(planes, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStoredMoney()
        {

            var moneyStored = _planManager.GetStoredMoney(Convert.ToInt32(User.Identity.Name));
            return Json(moneyStored, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void AddMoneyToStore(SumUserModel moneyModel)
        {
            moneyModel.UserId = Convert.ToInt32(User.Identity.Name);
            _planManager.AddSum(moneyModel);
        }
    }
}