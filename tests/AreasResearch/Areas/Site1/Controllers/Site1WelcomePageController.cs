using System.Web.Mvc;
using AreasResearch.Areas.Site1.Models;
using EPiServer.Web.Mvc;

namespace AreasResearch.Areas.Site1.Controllers
{
    public class Site1WelcomePageController : PageController<Site1WelcomePage>
    {
        public ActionResult Index(Site1WelcomePage currentPage)
        {
            return View(currentPage);
        }
    }
}
