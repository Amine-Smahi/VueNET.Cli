using VueNET.Cli.Constants;
using VueNET.Cli.Helpers;
using VueNET.Cli.ValueObjects;

namespace VueNET.Cli.Handlers
{
    public class ComponentsCreationHandler
    {
        private readonly Component _component;

        public ComponentsCreationHandler(Component component)
        {
            _component = component;
        }

        public void CreateComponents()
        {
            DirectoryHelper.CopyDirectory(Project.TemplatePath, Project.TempDirectory, true);
            var files = FilesHelper.GetFilesInDirectory(Project.TempDirectory);
            CodeHandler.UpdateCode(files, _component.Name, _component.Namespace, _component.Properties);
            FoldersHandler.MoveDirectoriesWithFiles(files, Project.TempDirectory, _component.Namespace,
                _component.Name);
            files = FilesHelper.GetFilesInDirectory(Project.TempDirectory);
            FilesHandler.UpdateFilesName(files, _component.Name);
            DirectoryHelper.CopyDirectory(Project.TempDirectory, _component.OutputProjectLocation, true);
            DirectoryHelper.DeleteDirectory(Project.TempDirectory);
        }
    }
}
