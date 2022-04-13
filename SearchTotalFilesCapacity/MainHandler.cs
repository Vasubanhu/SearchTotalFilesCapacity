using static SearchTotalFilesCapacity.DataRepresentator;
using static SearchTotalFilesCapacity.FilesHandler;

namespace SearchTotalFilesCapacity
{
    internal class MainHandler
    {
        private readonly string? _defaultSearchPath = Directory.GetCurrentDirectory();
        internal delegate void Method(string path);
        private const string Message1 = @"Type the path to the directory to bypass in the format (e.g C:\path\to\your\folder)";
        private const string Message2 = @"Type the path to save to the result of calculate in the format (e.g C:\path\to\your\folder)";

        public void Initialize(string[]? args)
        {
            Method method1 = PrintDirectoryTree;
            Method method2 = OutputData;

            if (args != null)
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "-q":
                        case "--quite":
                            RedirectStream("Tree.txt", method1, _defaultSearchPath);
                            Console.WriteLine("The structure of current directory was saved.");
                            return;
                        case "-p":
                        case "--path":
                            var pathToSearch = InputPath(Message1);
                            RedirectStream("Tree.txt", method1, pathToSearch);
                            Console.WriteLine($"The structure for directory {pathToSearch} was saved.");
                            return;
                        case "-o":
                        case "--output":
                            var pathToSave = InputPath(Message2);
                            RedirectStream($"sizes-{DateTime.Now:yyyy-MM-dd}.txt", method2, _defaultSearchPath, pathToSave);
                            Console.WriteLine($"The total size of all files in a directory {_defaultSearchPath} was saved.");
                            return;
                        case "--h":
                        case "--humanread":
                            Console.WriteLine("Формирование размера файла.");
                            return;
                    }
                }
            }

            PrintDirectoryTree(_defaultSearchPath);
        }

        private static string? InputPath(string message)
        {
            Console.WriteLine(message);
            var path = Console.ReadLine();
            return path;
        }
    }
}
