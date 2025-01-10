using System.IO;

namespace DoxygenGenerator
{
    public static class FileUtils
    {
        internal static void CopyFolder(string source, string destination, bool overwrite)
        {
            if (!Directory.Exists(source))
            {
                throw new DirectoryNotFoundException($"Source folder not found: {source}");
            }
            
            // Create the destination folder if it doesn't exist
            Directory.CreateDirectory(destination);

            // Copy all files
            foreach (string file in Directory.GetFiles(source))
            {
                string destFile = Path.Combine(destination, Path.GetFileName(file));
                File.Copy(file, destFile, overwrite);
            }

            // Copy all subdirectories
            foreach (string subFolder in Directory.GetDirectories(source))
            {
                string destSubFolder = Path.Combine(destination, Path.GetFileName(subFolder));
                CopyFolder(subFolder, destSubFolder, overwrite);
            }
        }
    }
}