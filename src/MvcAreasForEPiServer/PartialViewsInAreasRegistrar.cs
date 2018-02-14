using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.DataAbstraction;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;

namespace MvcAreasForEPiServer
{
    public class PartialViewsInAreasRegistrar
    {
        private static volatile bool _isInitialized;
        private static readonly object _lockObj = new object();
        private readonly IContentTypeModelScanner _contentTypeModelScanner;
        private readonly ITemplateRepository _templateModelRepository;
        private readonly CachingViewEnginesWrapper _viewEngineWrapper;

        public PartialViewsInAreasRegistrar(
            IContentTypeModelScanner contentTypeModelScanner,
            ITemplateRepository templateModelRepository,
            CachingViewEnginesWrapper viewEngineWrapper)
        {
            _contentTypeModelScanner = contentTypeModelScanner;
            _templateModelRepository = templateModelRepository;
            _viewEngineWrapper = viewEngineWrapper;
        }

        public static void Register(HttpContextBase context)
        {
            lock (_lockObj)
            {
                if (_isInitialized)
                {
                    return;
                }

                var reg = ServiceLocator.Current.GetInstance<PartialViewsInAreasRegistrar>();
                reg.RegisterPartials(context);

                _isInitialized = true;
            }
        }

        private void RegisterPartials(HttpContextBase context)
        {
            var controllerContext = new ControllerContext
            {
                RequestContext = new RequestContext
                {
                    RouteData = new RouteData(),
                    HttpContext = context
                },
                HttpContext = context
            };

            controllerContext.RouteData.Values["controller"] = "[Unknown]";

            foreach (var area in AreaTable.Areas)
            {
                controllerContext.RouteData.DataTokens["area"] = area.Name;
                FindPartialViewInArea(controllerContext);
            }
        }

        private void FindPartialViewInArea(ControllerContext controllerContext)
        {
            foreach (var type in _contentTypeModelScanner.ContentTypes)
            {
                var contentType = type;
                if (
                    _templateModelRepository.List(contentType)
                                            .Any(p => p.TemplateTypeCategory.IsCategory(TemplateTypeCategories.MvcPartialView) && string.IsNullOrEmpty(p.Path)))
                {
                    continue;
                }

                // NOTE: this line in Release Mode was scanning only first area.
                // If there were more than one area and requested block would be located
                // in 2nd or any other area, EPiServer would add this template to noHit
                // cache and would assume that view does not exist at all.

                //  Replaced with view search directly via ViewEngines collection.
                // If this hits performance - we would need to search for another solution here.

                // var partialView = _viewEngineWrapper.FindPartialView(controllerContext, contentType.Name);
                var partialView = ViewEngines.Engines.FindPartialView(controllerContext, contentType.Name);

                if (partialView.View == null)
                {
                    continue;
                }

                var templateModel = new TemplateModel
                {
                    Name = contentType.Name,
                    TemplateTypeCategory = TemplateTypeCategories.MvcPartialView
                };

                var view = partialView.View as BuildManagerCompiledView;
                if (view != null)
                {
                    templateModel.Path = view.ViewPath;
                }

                _templateModelRepository.AddTemplates(contentType, templateModel);

                partialView.ViewEngine.ReleaseView(controllerContext, partialView.View);
            }
        }
    }
}
