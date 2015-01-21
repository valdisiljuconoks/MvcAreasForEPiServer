using System.Web.Mvc;

namespace EPiServer.MvcAreas
{
    public class DetectAreaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var areaName = AreaTable.GetAreaForController(filterContext.Controller.GetType().FullName);
            if (areaName != null)
            {
                filterContext.RouteData.DataTokens["area"] = areaName;
            }
        }
    }
}
