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
        public void AddNewProject(ProjectData model)
        {
            model.UserId = Convert.ToInt32(User.Identity.Name);
            _freelanceManager.AddNewProject(model);
        }

        public void AddHours(HoursData model)
        {
            _freelanceManager.AddHours(model);
        }
        
        public void ChangeProjectData(other_Projects model)
        {
            model.UserId = Convert.ToInt32(User.Identity.Name);
            _freelanceManager.ChangeProjectData(model);
        }
        public void AddPayment(PaymentModel model)
        {
            _freelanceManager.AddPayement(model);
        }
        public JsonResult GetProjects()
        {
            return Json(_freelanceManager.GetProjects(User.Identity.Name), JsonRequestBehavior.AllowGet);
        }
        public void ChangeProjectStatus(int projectId)
        {
            _freelanceManager.ChangeProjectStatus(projectId);
        }
    }
}