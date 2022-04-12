using static SearchTotalFilesCapacity.DataRepresentator;
using static SearchTotalFilesCapacity.FilesHandler;

namespace SearchTotalFilesCapacity
{
    internal class MainHandler
    {
        //private const string TestPath = @"D:\Projects\ТЗ";
        private readonly string _defaultPath = Directory.GetCurrentDirectory();

        public void Initialize(string[]? args)
        {
            if (args != null)
            {
                foreach (var arg in args)
                {
                    switch (arg)
                    {
                        case "-q":
                        case "--quite":
                            Console.WriteLine("The structure was saved in the file.");
                            RedirectStream(_defaultPath);
                            return;
                        case "-p":
                        case "--path":
                            Console.WriteLine("Вывод структуры папки в консоль.");
                            return;
                        case "-o":
                        case "--output":
                            Console.WriteLine("Outputting the total volume to a file.");
                            OutputData(_defaultPath);
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
    }
}
