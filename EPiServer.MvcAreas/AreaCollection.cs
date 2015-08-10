using System.Collections.ObjectModel;
using System.Linq;

namespace EPiServer.MvcAreas
{
    public class AreaCollection : Collection<Area>
    {
        public bool Contains(string areaName)
        {
            return this.FirstOrDefault(a => a.Name.Equals(areaName)) != null;
        }
    }
}
