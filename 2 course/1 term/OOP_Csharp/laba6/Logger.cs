using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    internal class Logger
    {
        public static void LogErrorinFile(Exception e)
        {
            //using - чтобы неуправляемые ресурсы были правильно удалены
            using var stream = new StreamWriter(@"D:\Study\ООПиП(Экзамен)\laba6\log.log", true); 
            stream.WriteLine($"Time: {DateTime.Now}");
            stream.WriteLine($"Info: {e.GetType()} - {e.Message}\n");
        }

        public static void LogErrorinConsole(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Time: {DateTime.Now}");
            Console.WriteLine($"Info: {e.GetType()} - {e.Message}");
        }
    }
}
