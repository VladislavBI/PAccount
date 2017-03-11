using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Investment.Controllers
{
    public class MainController : Controller
    {
        // GET: Investment/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}