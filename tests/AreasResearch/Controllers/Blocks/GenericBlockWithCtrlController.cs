using System.Web.Mvc;
using AreasResearch.Models.Blocks;
using EPiServer.Web.Mvc;

namespace AreasResearch.Controllers.Blocks
{
    public class GenericBlockWithCtrlController : BlockController<GenericBlockWithCtrl>
    {
        //[SwitchToArea]
        public override ActionResult Index(GenericBlockWithCtrl currentBlock)
        {
            return PartialView("_GenericBlockWithCtrl", currentBlock);
        }
    }
}
