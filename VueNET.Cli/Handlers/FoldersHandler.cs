using System.Collections.Generic;
using VueNET.Cli.Constants;
using VueNET.Cli.Helpers;

namespace VueNET.Cli.Handlers
{
    public static class FoldersHandler
    {
        internal static void MoveDirectoriesWithFiles(List<string> files, string tempDirectory, string @namespace,
            string name)
        {
            files = PathHelper.SortFilesListByTreeDepth(files);

            foreach (var file in files)
            {
                var directory = PathHelper.GetDirectoryName(file);
                if (directory == null) continue;
                var newDirectory = directory.Replace(Identifiers.Namespace, @namespace)
                    .Replace(Identifiers.Entity, name);

                DirectoryHelper.CreateDirectoryIfNotExist(newDirectory);

                DirectoryHelper.CopyDirectory(directory, newDirectory, true);
            }

            FilesHandler.RemoveOldFiles(files);
            RemoveOldDirectories(tempDirectory);
        }

        private static void RemoveOldDirectories(string tempDirectory)
        {
            DirectoryHelper.RemoveEmptyDirectories(tempDirectory);
        }
    }
}
