using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    public delegate void allUserActions(string msg);
    partial class PAVLog
    {
        private const string path = @"D:\Study\ООПиП(Экзамен)\laba12\pavlogfile.txt";
        public static event allUserActions Checked = (msg) =>
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    sw.WriteLine($"Дата использования: {DateTime.Now} --- {msg}\n");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        };
    }
}
