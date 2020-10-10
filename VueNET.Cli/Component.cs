using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VueNET.Cli
{
    public class Component
    {
        public string TemplatePath { get; set; }
        public string TempFolder { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public List<Property> Properties { get; set; }

        public void CreateForProject(string OutPutProjectPath)
        {
            IOHelper.CopyDirectory(TemplatePath, TempFolder, true);
            var files = IOHelper.GetFilesInFolder(TempFolder);
            UpdateCode(files, Name, Namespace);
            MoveFilesAndFolders(files);
            files = IOHelper.GetFilesInFolder(TempFolder);
            UpdateFilesName(files);
            IOHelper.CopyDirectory(TempFolder, OutPutProjectPath, true);
            IOHelper.RemoveFolder(TempFolder);
        }

        private void UpdateFilesName(List<string> files)
        {
            foreach (var file in files)
            {
                var filename = Path.GetFileName(file).Replace(Identifiers.Entity, Name);
                IOHelper.RenameFile(file, filename);
            }
        }

        private void MoveFilesAndFolders(List<string> files)
        {
            files = SortFilesListByTreeDepth(files);

            foreach (var file in files)
            {
                var folder = Path.GetDirectoryName(file);
                var newfolder = folder.Replace(Identifiers.Namespace, Namespace).Replace(Identifiers.Entity, Name);

                if (!Directory.Exists(newfolder))
                {
                    Directory.CreateDirectory(newfolder);
                }

                IOHelper.CopyDirectory(folder, newfolder, true);
            }
            RemoveOldFiles(files);
            RemoveOldFolders(TempFolder);
        }

        private void RemoveOldFolders(string tempFolder)
        {
            IOHelper.RemoveEmptyDirectories(tempFolder);
        }

        private void RemoveOldFiles(List<string> files)
        {
            foreach (var file in files)
            {
                var directory = Path.GetDirectoryName(file);

                if (Directory.Exists(directory))
                {
                    IOHelper.RemoveFolder(directory);
                }
            }
        }

        private void UpdateCode(List<string> files, string entity, string project)
        {
            foreach (var file in files)
            {
                UpdateNamespace(file, project);
                UpdateEntityName(file, entity);
                UpdateProperties(file, Properties);
            }
        }

        private void UpdateEntityName(string file, string entity)
        {
            IOHelper.ReplaceWord(file, Identifiers.Entity, entity);
        }

        private void UpdateNamespace(string file, string project)
        {
            IOHelper.ReplaceWord(file, Identifiers.Namespace, project);
        }

        private void UpdateProperties(string file, List<Property> properties)
        {
            WriteAllProperties(file, properties);
            WriteSortByProperty(file, properties.Where(x => x.IsForSorting == true)
                .FirstOrDefault().Name);
        }

        private void WriteAllProperties(string file, List<Property> properties)
        {
            if (IOHelper.FileContainWord(file, Identifiers.AllProperties))
            {
                foreach (var property in properties)
                {
                    IOHelper.ReplaceWord(file, Identifiers.AllProperties, property.GetDeclaration() + "\n\t\t" + Identifiers.AllProperties);
                }
                IOHelper.ReplaceWord(file, Identifiers.AllProperties, string.Empty);
            }
        }
        private void WriteSortByProperty(string file, string name)
        {
            IOHelper.ReplaceWord(file, Identifiers.Sort, name);
        }

        private List<string> SortFilesListByTreeDepth(List<string> list)
        {
            return list.OrderBy(f => f.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length)
                .ToList();
        }
    }
}
