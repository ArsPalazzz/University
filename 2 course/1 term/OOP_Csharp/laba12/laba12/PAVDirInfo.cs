using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    partial class PAVLog
    {
        public static class PAVDirInfo
        {
            public static void NumberOfFiles(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    int number = 0;
                    Console.WriteLine($"Файлы из каталога '{directory.Name}': ");
                    string[] files = Directory.GetFiles(path);
                    foreach (string item in files)
                    {
                        Console.WriteLine(item);
                        number++;
                    }
                    Console.WriteLine($"Общее количество файлов данного каталога: {number}");
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует");
                Checked($"Пользователь проверил количество файлов каталога {directory.Name} с помощью метода NumberOfFiles");
            }
            public static void CreationTimeInfo(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    Console.WriteLine($"Название каталога: {directory.Name}");
                    Console.WriteLine($"Время создания каталога: {directory.CreationTime}");
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует");
                Checked($"Пользователь проверил время создания каталога {directory.Name} с помощью метода CreationTimeInfo");
            }
            public static void NumberOfSubdir(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    int number = 0;
                    Console.WriteLine($"Подкаталоги из каталога '{directory.Name}': ");
                    string[] subdir = Directory.GetDirectories(path);
                    foreach (string item in subdir)
                    {
                        Console.WriteLine(item);
                        number++;
                    }
                    Console.WriteLine($"Общее количество подкаталогов данного каталога: {number}");
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует");
                Checked($"Пользователь проверил количество подкаталогов каталога {directory.Name} с помощью метода NumberOfSubdir");
            }
            public static void ListOfParentDir(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    Console.WriteLine($"Каталог: {directory.Name}");
                    Console.WriteLine($"Родительский каталог: {directory.Parent}");
                }
                else
                    Console.WriteLine("Каталога по такому пути не существует");
                Checked($"Пользователь проверил родительский каталог каталога {directory.Name} с помощью метода ListOfParentDir");
            }
        }
    }
}
