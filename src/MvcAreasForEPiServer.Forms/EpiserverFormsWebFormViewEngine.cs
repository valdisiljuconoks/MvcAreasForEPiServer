using System.Linq;
using System.Web.Mvc;

namespace MvcAreasForEPiServer.Forms
{
    public class EpiserverFormsWebFormViewEngine : WebFormViewEngine
    {
        public EpiserverFormsWebFormViewEngine()
        {
            AreaPartialViewLocationFormats = AreaPartialViewLocationFormats.Union(new[]
                                                                                  {
                                                                                      "~/Areas/{2}/Views/Shared/ElementBlocks/{0}.ascx"
                                                                                  }).ToArray();
        }
    }
}
