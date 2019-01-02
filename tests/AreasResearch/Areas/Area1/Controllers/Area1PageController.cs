using System.Web.Mvc;
using AreasResearch.Areas.Area1.Models;
using EPiServer.Web.Mvc;

namespace AreasResearch.Areas.Area1.Controllers
{
    public class Area1PageController : PageController<Area1Page>
    {
        public ActionResult Index(Area1Page currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            return View(currentPage);
        }
    }
}
