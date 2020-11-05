using System.Collections.Generic;
using VueNET.Cli.Constants;
using VueNET.Cli.Helpers;

namespace VueNET.Cli.Handlers
{
    public static class FilesHandler
    {
        public static void UpdateFilesName(IEnumerable<string> files, string name)
        {
            foreach (var file in files)
            {
                var filename = PathHelper.GetFileName(file).Replace(Identifiers.Entity, name);
                FilesHelper.RenameFile(file, filename);
            }
        }

        public static void RemoveOldFiles(IEnumerable<string> files)
        {
            foreach (var file in files) FilesHelper.DeleteFile(file);
        }
    }
}
