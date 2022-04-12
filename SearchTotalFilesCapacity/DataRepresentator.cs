namespace SearchTotalFilesCapacity
{
    internal class DataRepresentator
    {
        private const int RootLevel = 0;
        private const string Indent = "--";

        internal static void PrintDirectoryTree(string? rootDirectoryPath)
        {
            try
            {
                if (!Directory.Exists(rootDirectoryPath))
                {
                    throw new DirectoryNotFoundException($"Directory {rootDirectoryPath} not found.");
                }

                var rootDirectory = new DirectoryInfo(rootDirectoryPath);
                PrintDirectoryTree(rootDirectory, RootLevel);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintDirectoryTree(DirectoryInfo directory, int currentLevel)
        {
            var indent = string.Empty;

            for (var i = RootLevel; i < currentLevel; i++)
            {
                indent += Indent;
            }

            Console.WriteLine(@$"{indent}- {directory.Name} ({directory.GetDirectories("*.*", SearchOption.AllDirectories)
                                                                       .Select(d => d.GetFiles()
                                                                       .Select(f => f.Length)
                                                                       .Sum())
                                                                       .Sum()} bytes)");
            PrintFiles(pattern: indent, dir: directory);

            var nextLevel = currentLevel + 1;

            try
            {
                foreach (var subDirectory in directory.GetDirectories())
                {
                    PrintDirectoryTree(subDirectory, nextLevel);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"{indent}- {e.Message}");
            }
        }

        private static void PrintFiles(DirectoryInfo dir, string pattern)
        {
            FileInfo[]? files = null;

            try
            {
                files = dir.GetFiles(".");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files == null) return;

            foreach (var fi in files)
            {
                Console.WriteLine($"{pattern}- {fi.Name} ({fi.Length} bytes)");
            }
        }
    }
}
