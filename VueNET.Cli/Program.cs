using System;
using VueNET.Cli.ValueObjects;

namespace VueNET.Cli
{
    internal static class Program
    {
        private static void Main()
        {
            var finished = false;
            var component = new Component();
            Console.WriteLine("\nWelcome to VueNET cli");
            Console.WriteLine(
                "\nThis tool is meant to help you to not repeat your self by creating components for you so lets get started\n");
            Console.WriteLine("Name of the solution");
            component.Namespace = Console.ReadLine();
            Console.WriteLine("Solution location");
            component.OutputProjectLocation = Console.ReadLine();
            Console.WriteLine("Name of the new entity");
            component.Name = Console.ReadLine();
            Console.WriteLine("Enter the properties of the entity \n");
            do
            {
                var property = new Property();
                Console.WriteLine("Enter the property type");
                property.Type = Console.ReadLine();
                Console.WriteLine("Enter the property name");
                property.Name = Console.ReadLine();
                component.Properties.Add(property);
                Console.WriteLine("\nAdd more ? (y/n)");
                var wantToAddMore = Console.ReadLine();
                Console.WriteLine();
                if (wantToAddMore != "n") continue;
                finished = true;
                Console.WriteLine("\nFinished\n");
            } while (!finished);

            component.ComponentHandler.CreateComponents();
        }
    }
}
