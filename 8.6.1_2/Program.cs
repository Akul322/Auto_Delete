using System;
using System.IO;

namespace _8._6._1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dtNow = DateTime.Now;

            Console.WriteLine("Введите путь до папки:");
            string Path = Console.ReadLine();

            DateTime dtModified = new DirectoryInfo(Path).LastAccessTime;

            try
            {
                if (Directory.Exists(Path))
                {
                    if (dtNow - dtModified > TimeSpan.FromMinutes(2.0))
                    {
                        var di = new DirectoryInfo(Path);

                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }

                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Папка была изменена менее 30 мин назад");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный путь до папки!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
            Console.ReadLine();
        }
    }
}
