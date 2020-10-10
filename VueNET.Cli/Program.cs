using System;

namespace VueNET.Cli
{
    class Program
    {
        static void Main()
        {
            bool finished = false;

            Component component = new Component();

            Console.WriteLine("\nWelcome to VueNET cli");
            Console.WriteLine("\nThis tool is ment to help you to not repeat your self by creating components for you so lets get started\n");
            Console.WriteLine("Name of the solution");
            component.Namespace = Console.ReadLine();
            Console.WriteLine("Solution location");
            component.OutputProjectLocation = Console.ReadLine();
            Console.WriteLine("Name of the new entity");
            component.Name = Console.ReadLine();
            Console.WriteLine("Enter the properties of the entity \n");
            do
            {
                Property property = new Property();
                Console.WriteLine("Enter the property type");
                property.Type = Console.ReadLine();
                Console.WriteLine("Enter the property name");
                property.Name = Console.ReadLine();
                Console.WriteLine("is the property for filter? (y/n)");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    property.IsForSorting = true;
                }
                else
                {
                    property.IsForSorting = false;
                }
                component.Properties.Add(property);
                Console.WriteLine("\nAdd more ? (y/n)");
                string addmoreanswer = Console.ReadLine();
                Console.WriteLine();
                if (addmoreanswer == "n")
                {
                    finished = true;
                    Console.WriteLine("\nFinished\n");
                }
            } while (!finished);

            component.CreateForProject();
        }
    }
}