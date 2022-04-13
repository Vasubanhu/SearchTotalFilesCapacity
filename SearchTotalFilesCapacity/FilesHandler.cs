using static SearchTotalFilesCapacity.DataRepresentator;
using static SearchTotalFilesCapacity.MainHandler;

namespace SearchTotalFilesCapacity
{
    internal class FilesHandler
    {
        internal static void RedirectStream(string? path, string fileName, Method? method = null)
        {
            var sw = new StreamWriter(fileName);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            if (path != null) method?.Invoke(path);
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
