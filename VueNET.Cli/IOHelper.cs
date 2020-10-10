using System.Collections.Generic;
using System.IO;

namespace VueNET.Cli
{
    public static class IOHelper
    {
        public static List<string> GetFilesInFolder(string folderpath)
        {
            List<string> files = new List<string>();
            foreach (string f in Directory.GetFiles(folderpath))
            {
                files.Add(f);
            }
            foreach (string d in Directory.GetDirectories(folderpath))
            {
                files.AddRange(GetFilesInFolder(d));
            }
            return files;
        }

        public static void RenameFile(string filepath, string newName)
        {
            var folder = Path.GetDirectoryName(filepath);
            var newpath = Path.Combine(folder, newName);
            if (File.Exists(newpath))
            {
                File.Delete(newpath);
            }
            File.Move(filepath, newpath);
        }

        public static bool FileContainWord(string file, string word)
        {
            if (File.ReadAllText(file).Contains(word))
            {
                return true;
            }
            return false;
        }

        public static void ReplaceWord(string filepath, string oldword, string newword)
        {
            File.WriteAllText(filepath, File.ReadAllText(filepath).Replace(oldword, newword));
        }

        public static void CreateFolderIfNotExist(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public static void RemoveFolderIfExist(string folder)
        {
            if (!Directory.Exists(folder))
            {
                RemoveFolder(folder);
            }
        }

        public static void CopyFolder(string sourceDirName, string destDirName, bool copySubDirs)
        {

            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destDirName);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                if (!File.Exists(tempPath))
                {
                    file.CopyTo(tempPath, false);
                }
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    CopyFolder(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        public static void RemoveFolder(string folderpath)
        {
            Directory.Delete(folderpath, true);
        }

        public static void RemoveEmptyFolders(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                RemoveEmptyFolders(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }
    }
}
