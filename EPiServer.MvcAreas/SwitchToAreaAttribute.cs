using System.Web.Mvc;
using EPiServer.Web;

namespace EPiServer.MvcAreas
{
    public class SwitchToAreaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            // if there is an area with the same name of the site - switch to that area
            if (AreaTable.Areas.Contains(SiteDefinition.Current.Name))
            {
                filterContext.RouteData.DataTokens["area"] = SiteDefinition.Current.Name;
            }
        }
    }
}
