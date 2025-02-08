using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    internal class StringCorrector
    {
        public static void DoOperation(string str1, string str2, Action<string, string> op) => op(str1, str2);
        public static void Concat(string str1, string str2) => Console.WriteLine("Контеканация строк: " + str1 + str2);
        public static void NoSpace(string str1, string str2) => Console.WriteLine("str1 без пробелов: " + str1.Replace(' ', ',') + "\tstr2 без пробелов: " + str2.Replace(' ', ','));
        public static void toUpper(string str1, string str2) => Console.WriteLine("str1: " + str1.ToUpper() + "\tstr2: " + str2.ToUpper());
        public static void toLower(string str1, string str2) => Console.WriteLine("str1: " + str1.ToLower() + "\tstr2: " + str2.ToLower());
        public static void NoComas(string str1, string str2) => Console.WriteLine("str1: " + str1.Replace(',', ' ') + "\tstr2: " + str2.Replace(',', ' '));
    }
}
