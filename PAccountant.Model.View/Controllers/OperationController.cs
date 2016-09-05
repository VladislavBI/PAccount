using PAccountant.Model.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class OperationController : Controller
    {
        IUnitOfWork unitOfWork;

        public OperationController(IUnitOfWork unitParam)
        {
            unitOfWork = unitParam;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}