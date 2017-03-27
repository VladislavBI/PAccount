using BussinessLogic.Model;
using BussinessLogic.ViewManagers.Abstract.Investment;
using PAccountant.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Investment.Controllers
{
    public class ProjectController : Controller
    {
        FreelanceManagerBase _freelanceManager;
        public ProjectController(FreelanceManagerBase freelanceManagerParam)
        {
            _freelanceManager = freelanceManagerParam;
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddNewProject(ProjectData model)
        {
            model.UserId = Convert.ToInt32(User.Identity.Name);
            _freelanceManager.AddNewProject(model);
            return Json(null);
        }

        public JsonResult AddHours(HoursData model)
        {
            _freelanceManager.AddHours(model);
            return Json(null);
        }

        public JsonResult ChangeProjectData(other_Projects model)
        {
            model.UserId = Convert.ToInt32(User.Identity.Name);
            _freelanceManager.ChangeProjectData(model);
            return Json(null);
        }
        public JsonResult AddPayment(PaymentModel model)
        {
            _freelanceManager.AddPayement(model);
            return Json(null);
        }
        public JsonResult GetProjects()
        {
            return Json(_freelanceManager.GetProjects(User.Identity.Name), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangeProjectStatus(int projectId)
        {
            _freelanceManager.ChangeProjectStatus(projectId);
            return Json(null);

        }
    }
}