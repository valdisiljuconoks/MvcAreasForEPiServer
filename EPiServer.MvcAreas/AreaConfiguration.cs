using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace EPiServer.MvcAreas
{
    public class AreaConfiguration
    {
        public static void RegisterAllAreas()
        {
            AreaRegistration.RegisterAllAreas();

            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            var areas = types.Where(t => IsTypeOf(t, typeof(AreaRegistration)));

            foreach (var area in areas)
            {
                var areaRegistration = AreaTable.AddArea(area);

                var ns = area.Namespace;
                if (string.IsNullOrEmpty(ns))
                {
                    continue;
                }

                var allTypesInArea = types.Where(t => t.Namespace != null && t.Namespace.StartsWith(ns) && IsTypeOf(t, typeof(Controller)));
                allTypesInArea.ToList().ForEach(t => AreaTable.RegisterController(t.FullName, areaRegistration.AreaName));
            }
        }

        private static bool IsTypeOf(Type type, Type parentType)
        {
            return parentType.IsAssignableFrom(type);
        }
    }
}
