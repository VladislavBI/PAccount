using System.Web.Mvc;

namespace PAccountant.Model.View.Controllers
{
    public class AccountantController : Controller
    {
       public JsonResult GetCurrentPageType()
        {
            string type = string.Empty;
            try
            {
                type = Session["pageType"].ToString();
            }
            catch (System.Exception)
            {}
            return Json(type, JsonRequestBehavior.AllowGet);
        }
    }
}