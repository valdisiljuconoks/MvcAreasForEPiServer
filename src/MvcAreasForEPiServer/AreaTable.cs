using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcAreasForEPiServer
{
    public class AreaTable
    {
        private static readonly Dictionary<string, string> _controllersMap = new Dictionary<string, string>();
        public static AreaCollection Areas { get; } = new AreaCollection();

        public static string GetAreaForController(string controllerName)
        {
            return _controllersMap.TryGetValue(controllerName, out var value) ? value : null;
        }

        internal static AreaRegistration AddArea(Type area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area));

            var areaRegistration = (AreaRegistration)Activator.CreateInstance(area);
            Areas.Add(new Area(areaRegistration.AreaName));

            return areaRegistration;
        }

        internal static void RegisterController(string controllerName, string areaName)
        {
            if (!_controllersMap.ContainsKey(controllerName))
                _controllersMap.Add(controllerName, areaName);
        }
    }
}
