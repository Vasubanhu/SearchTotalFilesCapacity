using static SearchTotalFilesCapacity.DataRepresentator;
using static SearchTotalFilesCapacity.MainHandler;

namespace SearchTotalFilesCapacity
{
    internal class FilesHandler
    {
        internal static void RedirectStream(string? fileName, Method? method = null, string? pathToSearch = null, string? pathToSave = null)
        {
            var path = (pathToSave == null) ? fileName : $"{pathToSave}\\{fileName}";
            if (path == null) return;
            var sw = new StreamWriter(path);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            if (pathToSearch != null) method?.Invoke(pathToSearch);
            CloseStream(sw);
        }

        private static void CloseStream(StreamWriter sw)
        {
            if (sw == null) throw new ArgumentNullException(nameof(sw));

            Console.Out.Close();
            sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }

        internal static void OutputData(string path)
        {
            var directory = new DirectoryInfo(path);
            Console.WriteLine($"Total files capacity: {CalculateTotalCapacity(directory)} bytes.");
        }
    }
}
