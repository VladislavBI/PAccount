using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Debts.Controllers
{
    public class MainController : Controller
    {
        // GET: Debts/Main
        public ActionResult Index()
        {
            Session["pageType"] = "debt";
            return View();
        }
    }
}