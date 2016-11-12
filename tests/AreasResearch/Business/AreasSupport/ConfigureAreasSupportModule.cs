using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using MvcAreasForEPiServer;

namespace AreasResearch.Business.AreasSupport
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ConfigureAreasSupportModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            AreaConfiguration.RegisterAllAreas(config =>
            {
                //config.EnableAreaDetectionByController = true;
                config.EnableAreaDetectionBySite = true;
            });
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}