using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class AccountantController : Controller
    {
       public JsonResult GetCurrentPageType()
        {
            string type = Session["pageType"].ToString();
            return Json(type, JsonRequestBehavior.AllowGet);
        }
    }
}