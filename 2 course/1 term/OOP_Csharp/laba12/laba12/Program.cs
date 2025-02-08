using System;
using System.IO;

namespace laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); //получение всех дисков

            foreach (DriveInfo drive in drives)
            {
                PAVLog.PAVDiskInfo.AllDiskInfo(drive);
                PAVLog.PAVDiskInfo.FileSystemInfo(drive);
                PAVLog.PAVDiskInfo.FreeSpaceInfo(drive);
                Console.WriteLine();
            }

            Console.WriteLine("\nВведите путь к файлу, о котором необходимо получить информацию:");
            string path1 = Console.ReadLine();
            PAVLog.PAVFileInfo.SizeExtensionNameInfo(path1);
            PAVLog.PAVFileInfo.FullPathInfo(path1);
            PAVLog.PAVFileInfo.CreationDateInfo(path1);

            Console.WriteLine("\nВведите путь к директории, о которой необходимо получить информацию:");
            string path2 = Console.ReadLine();
            PAVLog.PAVDirInfo.NumberOfFiles(path2);
            PAVLog.PAVDirInfo.CreationTimeInfo(path2);
            PAVLog.PAVDirInfo.NumberOfSubdir(path2);
            PAVLog.PAVDirInfo.ListOfParentDir(path2);

            Console.WriteLine("\nВведите имя диска, с которого хотите прочитать список папок и файлов:");
            string path3 = Console.ReadLine();
            PAVLog.PAVFileManager.ListOfFilesAndFolders(path3);
            PAVLog.PAVFileManager.CreateDir();
            PAVLog.PAVFileManager.CreateFile(path3);
            PAVLog.PAVFileManager.CreateCopyAndRename();

            Console.WriteLine("\nВведите путь к папке, из которой необходимо скопировать все файлы с расширением .docx в новую папку PAVFiles:");
            string path4 = Console.ReadLine();
            PAVLog.PAVFileManager.CreateAnotherDir(path4);
            PAVLog.PAVFileManager.CompressionFile();

            PAVLog.PAVFileManager.CheckedInfo.CheckedActions();
        }
    }
}
