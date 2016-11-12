using System.Linq;
using System.Web.Mvc;

namespace AreasResearch.Business.Rendering
{
    /// <summary>
    ///     Extends the Razor view engine to include the folders ~/Views/Shared/Blocks/ and ~/Views/Shared/PagePartials/
    ///     when looking for partial views.
    /// </summary>
    public class SiteViewEngine : RazorViewEngine
    {
        /*
         Placeholders:
         *      {2} - Name of the area
         *      {1} - Name of the controller
         *      {0} - Name of the action (name of the partial view)
         */

        private static readonly string[] AdditionalPartialViewFormats =
        {
            TemplateCoordinator.BlockFolder + "{0}.cshtml",
            TemplateCoordinator.PagePartialsFolder + "{0}.cshtml"
        };

        public SiteViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(AdditionalPartialViewFormats).ToArray();

            AreaPartialViewLocationFormats = AreaPartialViewLocationFormats
                .Union(new[]
                {
                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/Blocks/{0}.cshtml"
                }).ToArray();
        }
    }
}
