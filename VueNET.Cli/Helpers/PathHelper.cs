using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VueNET.Cli.Helpers
{
    public static class PathHelper
    {
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public static string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public static List<string> SortFilesListByTreeDepth(IEnumerable<string> list)
        {
            return list.OrderBy(f => f.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length)
                .ToList();
        }
    }
}