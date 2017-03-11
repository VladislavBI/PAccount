using System.Web.Mvc;

namespace PAccountant.Model.View.Areas.Investment
{
    public class InvestmentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Investment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Investment_default",
                "Investment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}