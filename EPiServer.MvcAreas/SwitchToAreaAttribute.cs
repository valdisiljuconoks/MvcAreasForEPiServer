using System.Web.Mvc;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace MvcAreasForEPiServer
{
    public class SwitchToAreaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            /*

            We need test if current controller is actually a content controller - was request made against *normal* page,
            or this is other controller - like CMS UI.

            Check is needed - because there are weird side-effects if we alter area DataToken, and CMS module controllers start to render
            relative Urls in the menu - some really routings get generated, like /cms/cms?moduleArea=AddOn.

            Easiest way was to alter area token only then, when this is really necessary - request hits real content controller.

            */

            if (filterContext.Controller.GetType().IsSubclassOf(typeof (ActionControllerBase)))
            {
                // if there is an area with the same name of the site - switch to that area
                if (AreaTable.Areas.Contains(SiteDefinition.Current.Name))
                {
                    filterContext.RouteData.DataTokens["area"] = SiteDefinition.Current.Name;
                }
            }
        }
    }
}
