using System.Web;
using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using InitializationModule = EPiServer.Web.InitializationModule;

namespace MvcAreasForEPiServer
{
    [ModuleDependency(typeof(InitializationModule))]
    public class AddMvcAreasSupportModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if(AreaConfiguration.Settings.EnableAreaDetectionByController)
            {
                GlobalFilters.Filters.Add(ServiceLocator.Current.GetInstance<DetectAreaAttribute>());
            }

            if(AreaConfiguration.Settings.EnableAreaDetectionBySite)
            {
                GlobalFilters.Filters.Add(ServiceLocator.Current.GetInstance<SwitchToAreaAttribute>());
            }

            var emitter = context.Locate.Advanced.GetInstance<IContentRouteEvents>();
            emitter.RoutingContent += OnRoutingContent;
        }

        public void Uninitialize(InitializationEngine context) { }

        private void OnRoutingContent(object sender, RoutingEventArgs e)
        {
            PartialViewsInAreasRegistrar.Register(new HttpContextWrapper(HttpContext.Current));

            var emitter = ServiceLocator.Current.GetInstance<IContentRouteEvents>();
            emitter.RoutingContent -= OnRoutingContent;
        }
    }
}
