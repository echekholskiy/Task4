using System.IO;
using System.Linq;
using System.Reflection;

namespace Task4.Utils
{
    public static class DirectoryManager
    {
        private static string GetBaseSolutionFolderPath()
        {
            var directory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty);
            while (directory != null && !directory.GetDirectories("Test").Any())
            {
                directory = directory.Parent;
            }
            return directory?.FullName;
        }

        public static string GetResourceFolderPath()
        {
            return Path.Combine(GetBaseSolutionFolderPath(), "Resources");
        }
    }
}
