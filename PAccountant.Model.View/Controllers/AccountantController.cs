using BussinessLogic.ViewManagers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class AccountantController : Controller
    {
        // GET: Accountant
        [HttpPost]
        public JsonResult AddOperation(AddOperationModel model)
        {
            return null;
        }
    }
}