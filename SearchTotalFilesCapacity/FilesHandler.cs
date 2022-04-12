using static SearchTotalFilesCapacity.DataRepresentator;

namespace SearchTotalFilesCapacity
{
    internal class FilesHandler
    {
        internal static void RedirectStream(string path)
        {
            var sw = new StreamWriter(@".\Tree.txt");
            sw.AutoFlush = true;
            Console.SetOut(sw);
            PrintDirectoryTree(path);
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
            var output = @$"./ {DateTime.Now:yyyy-MM-dd}.txt";

            using (var sw = new StreamWriter(output))
            {
                Console.WriteLine($"Total files capacity: {CalculateTotalCapacity(directory)}");
            }
        }
    }
}
