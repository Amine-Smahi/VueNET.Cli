using System.IO;

namespace VueNET.Cli.Helpers
{
    public static class DirectoryHelper
    {
        public static void CreateDirectoryIfNotExist(string directory)
        {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }

        public static void CopyDirectory(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);

            var dirs = dir.GetDirectories();
            Directory.CreateDirectory(destDirName);

            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var tempPath = Path.Combine(destDirName, file.Name);
                if (!File.Exists(tempPath)) file.CopyTo(tempPath, false);
            }

            if (!copySubDirs) return;
            {
                foreach (var subDir in dirs)
                {
                    var tempPath = Path.Combine(destDirName, subDir.Name);
                    CopyDirectory(subDir.FullName, tempPath, true);
                }
            }
        }

        public static void DeleteDirectory(string directoryPath)
        {
            Directory.Delete(directoryPath, true);
        }

        public static void RemoveEmptyDirectories(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                RemoveEmptyDirectories(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                    Directory.Delete(directory, false);
            }
        }
    }
}
