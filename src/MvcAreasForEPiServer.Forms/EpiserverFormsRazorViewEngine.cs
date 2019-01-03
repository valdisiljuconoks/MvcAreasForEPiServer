using System.Linq;
using System.Web.Mvc;

namespace MvcAreasForEPiServer.Forms
{
    public class EpiserverFormsRazorViewEngine : RazorViewEngine
    {
        public EpiserverFormsRazorViewEngine()
        {
            AreaPartialViewLocationFormats = AreaPartialViewLocationFormats.Union(new[]
                                                                                  {
                                                                                      "~/Areas/{2}/Views/Shared/ElementBlocks/{0}.cshtml"
                                                                                  }).ToArray();
        }
    }
}
