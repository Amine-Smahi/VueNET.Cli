using System.Collections.Generic;

namespace VueNET.Cli
{
    class Program
    {
        static void Main()
        {
            Component component = new Component
            {
                TemplatePath = @".\template",
                TempFolder = @".\temp",
                Name = "MyComponent",
                Namespace = "MyApp",
                Properties = new List<Property>
                {
                    new Property
                    {
                        Modifier = "public",
                        Type = "string",
                        Name =  "Title",
                        IsForSorting = true
                    },
                    new Property
                    {
                        Modifier = "public",
                        Type = "string",
                        Name =  "Description"
                    }
                }
            };
            component.CreateForProject(@".\result");
        }
    }
}