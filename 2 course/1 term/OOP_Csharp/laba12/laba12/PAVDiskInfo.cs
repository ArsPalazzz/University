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
        public static class PAVDiskInfo
        {
            public static void FreeSpaceInfo(DriveInfo drive)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                }
                Checked($"Пользователь проверил свободное пространство на диске {drive.Name} с помощью метода FreeSpaceInfo");
            }
            public static void FileSystemInfo(DriveInfo drive)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Имя файловой системы: {drive.DriveFormat}");
                }
                Checked($"Пользователь определил имя файловой системы с помощью метода FileSystemInfo");
            }
            public static void AllDiskInfo(DriveInfo drive)     //Для каждого существующего диска - имя, объем, доступный объем, метка тома
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Объём свободного места на диске в байтах: {drive.AvailableFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Checked($"Пользователь проверил имя, объем, доступный объем и метку тома диска {drive.Name} с помощью метода AllDiskInfo");
            }
        }
    }
}
