using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcAreasForEPiServer
{
    public class AreaConfiguration
    {
        public static AreaConfigurationSettings Settings { get; } = new AreaConfigurationSettings();

        public static void RegisterAllAreas(Action<AreaConfigurationSettings> configuration = null)
        {
            configuration?.Invoke(Settings);

            AreaRegistration.RegisterAllAreas();
            var areas = TypeAttributeHelper.GetTypesChildOf<AreaRegistration>();
            foreach (var area in areas)
            {
                var areaRegistration = AreaTable.AddArea(area);

                var ns = area.Namespace;
                if(string.IsNullOrEmpty(ns))
                    continue;

                var controllersInArea = TypeAttributeHelper.GetTypesChildOf<Controller>().Where(t => t.Namespace != null && t.Namespace.StartsWith(ns));
                controllersInArea.ToList().ForEach(t => AreaTable.RegisterController(t.FullName, areaRegistration.AreaName));
            }
        }
    }
}
