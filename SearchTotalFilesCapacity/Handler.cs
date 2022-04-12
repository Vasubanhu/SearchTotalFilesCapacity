using static SearchTotalFilesCapacity.DataRepresentator;

namespace SearchTotalFilesCapacity
{
    internal class Handler
    {
        private const string TestPath = @"D:\Projects\ТЗ";
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
                        case "--q":
                            Console.WriteLine("Вывод структуры в файл.");
                            return;
                        case "-p":
                        case "--p":
                            Console.WriteLine("Вывод структуры папки в консоль.");
                            return;
                        case "-o":
                        case "--o":
                            Console.WriteLine("Вывод результата расчетов в файл");
                            return;
                        case "--h":
                            Console.WriteLine("Формирование размера файла.");
                            return;
                    }
                }
            }

            PrintDirectoryTree(_defaultPath);
        }
    }
}
