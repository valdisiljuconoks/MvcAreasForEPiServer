using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using FormsInitializationModule = EPiServer.Forms.EditView.InitializationModule;

namespace MvcAreasForEPiServer.Forms
{
    [InitializableModule]
    [ModuleDependency(typeof(FormsInitializationModule))]
    public class MvcAreasFormsViewsInitModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ViewEngines.Engines.Insert(0, new EpiserverFormsWebFormViewEngine());
            ViewEngines.Engines.Insert(0, new EpiserverFormsRazorViewEngine());
        }

        public void Uninitialize(InitializationEngine context) { }
    }
}
