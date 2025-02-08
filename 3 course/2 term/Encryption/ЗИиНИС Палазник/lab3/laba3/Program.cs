using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba3
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            // Создание документа в формате Base64
            CurrentLab.GenerateBase64Document();

            // Создание и вывод отчета
            Console.WriteLine(CurrentLab.GenerateReport());

            // ASCII XOR операции
            Console.Write("ASCII XOR: ");
            string lastName = "Palaznik", firstName = "Arseniy";
            string lastNameAscii = "", firstNameAscii = "";

            foreach (char ch in lastName)
            {
                lastNameAscii += Convert.ToInt32(ch);
            }

            foreach (char ch in firstName)
            {
                firstNameAscii += Convert.ToInt32(ch);
            }

            while (lastNameAscii.Length != firstNameAscii.Length)
            {
                firstNameAscii += '0';
            }

            foreach (byte b in CurrentLab.XOR(Encoding.Unicode.GetBytes(lastNameAscii), Encoding.Unicode.GetBytes(firstNameAscii)))
            {
                Console.Write(b);
            }
            Console.WriteLine();

            // Base64 XOR операции
            Console.Write("Base64 XOR: ");
            string firstNameBase64 = Convert.ToBase64String(Encoding.Unicode.GetBytes(firstName));
            string lastNameBase64 = Convert.ToBase64String(Encoding.Unicode.GetBytes(lastName));

            while (lastNameBase64.Length != firstNameBase64.Length)
            {
                firstNameBase64 += '0';
            }

            foreach (byte b in CurrentLab.XOR(Encoding.Unicode.GetBytes(lastNameBase64), Encoding.Unicode.GetBytes(firstNameBase64)))
            {
                Console.Write(b);
            }
            Console.WriteLine();

            // aXORbXORb операция
            Console.Write("aXORbXORb: \t");
            byte[] aXORbXORbResult = CurrentLab.XOR(Encoding.Unicode.GetBytes(lastNameBase64), CurrentLab.XOR(Encoding.Unicode.GetBytes(firstNameBase64), Encoding.Unicode.GetBytes(lastNameBase64)));

            foreach (byte b in aXORbXORbResult)
            {
                Console.Write(b);
            }
            Console.WriteLine();

            // Вывод имени в Base64
            Console.Write("a: \t\t");
            foreach (byte b in Encoding.Unicode.GetBytes(firstNameBase64))
            {
                Console.Write(b);
            }
            Console.WriteLine();
        }
    }
}
