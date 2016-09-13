using PAccountant.Model.Infrastructure.Abstract;
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