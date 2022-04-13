using static SearchTotalFilesCapacity.DataRepresentator;
using static SearchTotalFilesCapacity.FilesHandler;

namespace SearchTotalFilesCapacity
{
    internal class MainHandler
    {
        private readonly string? _defaultPath = Directory.GetCurrentDirectory();
        internal delegate void Method(string path);
        private const string Message = @"Type the path to the directory to bypass in the format (e.g C:\path\to\your\folder)";

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
                            RedirectStream(_defaultPath, "Tree.txt", method1);
                            Console.WriteLine("The structure of current directory was saved.");
                            return;
                        case "-p":
                        case "--path":
                            var path = InputPath();
                            RedirectStream(path, "Tree.txt", method1);
                            Console.WriteLine($"The structure for directory {path} was saved.");
                            return;
                        case "-o":
                        case "--output":
                            RedirectStream(_defaultPath, $"{DateTime.Now:yyyy-MM-dd}.txt", method2);
                            Console.WriteLine("Outputting the total volume to a file.");
                            return;
                        case "--h":
                        case "--humanread":
                            Console.WriteLine("Формирование размера файла.");
                            return;
                    }
                }
            }
            
            PrintDirectoryTree(_defaultPath);
        }

        private static string? InputPath()
        {
            Console.WriteLine(Message);
            var path = Console.ReadLine();
            return path;
        }
    }
}
