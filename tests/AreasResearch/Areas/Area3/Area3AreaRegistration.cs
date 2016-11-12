using System.Web.Mvc;

namespace AreasResearch.Areas.Area3
{
    public class Area3AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Area3";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Area3_default",
                "Area3/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}