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
        public static class PAVFileInfo
        {
            public static void FullPathInfo(string path)
            {
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine($"Полный путь к файлу: {fileInf.FullName}");
                }
                else
                    Console.WriteLine("Файла по такому пути не существует");
                Checked($"Пользователь проверил полный путь к файлу {fileInf.Name} с помощью метода FullPathInfo");
            }
            public static void SizeExtensionNameInfo(string path)
            {
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine($"Имя файла: {fileInf.Name}");
                    Console.WriteLine($"Расширение: {fileInf.Extension}");
                    Console.WriteLine($"Размер: {fileInf.Length} байт");
                }
                else
                    Console.WriteLine("Файла по такому пути не существует");
                Checked($"Пользователь проверил размер, расширение и имя файла {fileInf.Name} с помощью метода SizeExtensionNameInfo");
            }
            public static void CreationDateInfo(string path)
            {
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine($"Время создания: {fileInf.CreationTime}");
                }
                else
                    Console.WriteLine("Невозможно определить время создания файла, т.к. файла по такому пути не существует");
                Checked($"Пользователь проверил время создания файла {fileInf.Name} с помощью метода CreationDateInfo");
            }
        }
    }
}
