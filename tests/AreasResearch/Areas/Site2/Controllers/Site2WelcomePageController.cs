using System.Web.Mvc;
using AreasResearch.Areas.Site2.Models;
using EPiServer.Web.Mvc;

namespace AreasResearch.Areas.Site2.Controllers
{
    public class Site2WelcomePageController : PageController<Site2WelcomePage>
    {
        public ActionResult Index(Site2WelcomePage currentPage)
        {
            return View(currentPage);
        }
    }
}
