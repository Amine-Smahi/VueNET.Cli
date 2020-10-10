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
                Name = "Amine",
                Namespace = "Test",
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
            component.CreateForProject(@"C:\Users\moham\source\repos\VueNET.Cli\VueNET.Cli\test");
        }
    }
}