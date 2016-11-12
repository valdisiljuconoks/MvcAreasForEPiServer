using System;

namespace MvcAreasForEPiServer
{
    public class Area
    {
        public Area(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
        }

        public string Name { get; private set; }
    }
}
