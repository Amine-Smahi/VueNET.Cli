using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VueNET.Cli.Helpers
{
    public static class FilesHelper
    {
        public static List<string> GetFilesInDirectory(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath).ToList();
            foreach (var d in Directory.GetDirectories(directoryPath)) files.AddRange(GetFilesInDirectory(d));
            return files;
        }

        public static void RenameFile(string filepath, string newName)
        {
            var directory = Path.GetDirectoryName(filepath);
            var newPath = Path.Combine(directory ?? string.Empty, newName);
            if (File.Exists(newPath)) File.Delete(newPath);
            File.Move(filepath, newPath);
        }

        public static bool FileContainWord(string file, string word)
        {
            return File.ReadAllText(file).Contains(word);
        }

        public static void ReplaceWordInFile(string filepath, string oldWord, string newWord)
        {
            File.WriteAllText(filepath, File.ReadAllText(filepath).Replace(oldWord, newWord));
        }

        public static void DeleteFile(string file)
        {
            if (File.Exists(file)) File.Delete(file);
        }
    }
}