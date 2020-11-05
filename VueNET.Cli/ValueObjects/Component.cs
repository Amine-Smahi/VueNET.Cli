using System.Collections.Generic;
using VueNET.Cli.Handlers;

namespace VueNET.Cli.ValueObjects
{
    public class Component
    {
        public Component()
        {
            ComponentHandler = new ComponentsCreationHandler(this);
        }

        public string Name { get; set; }
        public string Namespace { get; set; }
        public string OutputProjectLocation { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
        public ComponentsCreationHandler ComponentHandler { get; }
    }
}
