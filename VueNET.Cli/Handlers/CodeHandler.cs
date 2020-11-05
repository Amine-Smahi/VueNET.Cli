using System.Collections.Generic;
using VueNET.Cli.Constants;
using VueNET.Cli.Helpers;
using VueNET.Cli.ValueObjects;

namespace VueNET.Cli.Handlers
{
    public static class CodeHandler
    {
        public static void UpdateCode(IEnumerable<string> files, string entity, string project,
            List<Property> properties)
        {
            foreach (var file in files)
            {
                UpdateNamespace(file, project);
                UpdateEntityName(file, entity);
                UpdateProperties(file, properties);
            }
        }

        private static void UpdateEntityName(string file, string entity)
        {
            FilesHelper.ReplaceWordInFile(file, Identifiers.Entity, entity);
        }

        private static void UpdateNamespace(string file, string project)
        {
            FilesHelper.ReplaceWordInFile(file, Identifiers.Namespace, project);
        }

        private static void UpdateProperties(string file, IEnumerable<Property> properties)
        {
            if (!FilesHelper.FileContainWord(file, Identifiers.AllProperties)) return;
            foreach (var property in properties)
                FilesHelper.ReplaceWordInFile(file, Identifiers.AllProperties,
                    property.GetDeclaration() + "\n\t\t" + Identifiers.AllProperties);
            FilesHelper.ReplaceWordInFile(file, Identifiers.AllProperties, string.Empty);
        }
    }
}
