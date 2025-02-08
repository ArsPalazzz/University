using System;
using System.IO;
using System.Collections.Generic;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine("Задание 1");
            Console.WriteLine("Энтропия алфавитов");
            Console.WriteLine("Датский: " + AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Danish));
            Console.WriteLine("Подсчет вероятности появления символа: ");
            AlphabetTask.CountSymbolFrequency(AlphabetTask.Alphabets.Danish);
            Console.WriteLine("Казахский: " + AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Kazakh));
            Console.WriteLine("Подсчет вероятности появления символа: ");
            AlphabetTask.CountSymbolFrequency(AlphabetTask.Alphabets.Kazakh);
            Console.WriteLine();

            // Задание 2
            Console.WriteLine("Задание 2");
            Console.WriteLine("Бинарный: " + AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Binary));
            Console.WriteLine();

            // Задание 3
            Console.WriteLine("Задание 3");
            Console.WriteLine("К-во информации в ФИО (датский): " + (AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Danish) * "ПалазникАрсенийВикторович".Length));
            Console.WriteLine("К-во информации в ФИО (ASCII): " +
                (AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Binary) *
                 System.Text.Encoding.Unicode.GetBytes("ПалазникАрсенийВикторович").Length));
            Console.WriteLine();

            // Задание 4
            Console.WriteLine("Задание 4");
            Console.WriteLine("К-во информации в ФИО (ASCII, вероятность ошибки 0.1): " +
                (AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Binary, 0.1f) *
                 System.Text.Encoding.Unicode.GetBytes("Palaznik Arseniy Viktorovich").Length));
            Console.WriteLine("К-во информации в ФИО (ASCII, вероятность ошибки 0.5): " +
                (AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Binary, 0.5f) *
                 System.Text.Encoding.Unicode.GetBytes("Palaznik Arseniy Viktorovich").Length));
            Console.WriteLine("К-во информации в ФИО (ASCII, вероятность ошибки 1): " +
                (Double.IsNaN(AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Binary, 1f)) ? 0 : AlphabetTask.CalculateEntropy(AlphabetTask.Alphabets.Binary, 1f) *
                 System.Text.Encoding.Unicode.GetBytes("Palaznik Arseniy Viktorovich").Length));
        }
    }
}
