using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace lab9
{
    public class ShannonFanoSymbol
    {
        public char Symbol { get; set; }
        public int Count { get; set; }
        public double Probability { get; set; }
        public string Code { get; set; }

        public ShannonFanoSymbol(char symbol, int count, double probability, string code)
        {
            Symbol = symbol;
            Count = count;
            Probability = probability;
            Code = code;
        }

        public static List<ShannonFanoSymbol> AddSymbols(List<ShannonFanoSymbol> symbols, string line)
        {
            foreach (var character in line)
            {
                var existingSymbol = symbols.FirstOrDefault(x => x.Symbol == character);
                if (existingSymbol == null)
                {
                    symbols.Add(new ShannonFanoSymbol(character, 1, 0.0, ""));
                }
                else
                {
                    existingSymbol.Count++;
                }
            }
            return symbols;
        }

        public static void Show(List<ShannonFanoSymbol> symbols)
        {
            foreach (var symbol in symbols)
            {
                Console.Write($"Символ: {symbol.Symbol}  Кол-во: {symbol.Count}");
                if (symbol.Probability != 0)
                {
                    Console.Write($"  Вероятность: {symbol.Probability}");
                }
                if (!string.IsNullOrEmpty(symbol.Code))
                {
                    Console.Write($"  Код: {symbol.Code}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ShannonFanoSymbol> symbols = new List<ShannonFanoSymbol>();

            using (StreamReader stream = new StreamReader("fio.txt", Encoding.Default))
            {
                string messagef;
                while ((messagef = stream.ReadLine()) != null)
                {
                    symbols = ShannonFanoSymbol.AddSymbols(symbols, messagef);
                }
            }

            Console.WriteLine();
            Console.WriteLine("На основе данных, полученных в лабораторной работе № 2");
            Console.WriteLine("Таблица символов: ");
            Console.WriteLine();

            ShannonFanoSymbol.Show(symbols);

            double symbolssum = symbols.Sum(x => x.Count);
            Console.WriteLine("Сумма всех символов текста на латинском языке: " + symbolssum);

            foreach (var symbol in symbols)
            {
                symbol.Probability = symbol.Count / symbolssum;
            }
            Console.WriteLine("Сумма вероятностей всех символов таблицы: " + symbols.Sum(x => x.Probability));
            Console.WriteLine();


            symbols = symbols.OrderByDescending(x => x.Probability).ToList();
            ShannonFanoSymbol.Show(symbols);

            Console.WriteLine();
            Console.WriteLine("Таблица с кодом для каждого символа: ");
            Console.WriteLine();


            symbols = AddCodes(symbols);
            foreach (var symbol in symbols)
            {
                symbol.Code = symbol.Code.Remove(symbol.Code.Length - 1, 1);
            }
            ShannonFanoSymbol.Show(symbols);

            string blockofFIO = "Palaznik Arseniy Viktorovich";
            string decodingOfFIO = "";
            foreach (var charFIO in blockofFIO)
            {
                decodingOfFIO += (symbols.FirstOrDefault(x => x.Symbol == charFIO)?.Code) ?? "";
            }
            Console.WriteLine("Исходное сообщение: ");
            Console.WriteLine(blockofFIO);
            Console.WriteLine("Сообщение после кодировки: ");
            Console.WriteLine(decodingOfFIO);
            Console.WriteLine("Количество битов в кодах ASCII:  " + blockofFIO.Length * 8);
            Console.WriteLine("Количество битов по таблице Шеннон-Фано: " + decodingOfFIO.Length);

            Console.WriteLine("_____________________________________________");
            Console.WriteLine();
            Console.WriteLine("Декодирование: ");
            Console.WriteLine();


            string Encoded = "";
            string FIOdecoded = "";
            for (int i = 0; i < decodingOfFIO.Length; i++)
            {
                Encoded += decodingOfFIO[i];
                if (symbols.Find(x => x.Code == Encoded) != null)
                {
                    FIOdecoded += symbols.Find(x => x.Code == Encoded).Symbol;
                    Encoded = "";
                }
            }
            Console.WriteLine(FIOdecoded);

            Console.WriteLine("_____________________________________________");
            Console.WriteLine();

            Console.WriteLine("Динамически, на основе анализа сжимаемого сообщения: ");
            Console.WriteLine();


            symbols.Clear();

            string message = "Palaznik";
            symbols = ShannonFanoSymbol.AddSymbols(symbols, message);
            ShannonFanoSymbol.Show(symbols);

            symbolssum = symbols.Sum(x => x.Count);
            Console.WriteLine("Сумма всех символов текста на латинском языке: " + symbolssum);

            foreach (var symbol in symbols)
            {
                symbol.Probability = symbol.Count / symbolssum;
            }
            Console.WriteLine("Сумма вероятностей всех символов таблицы: " + symbols.Sum(x => x.Probability));

            Console.WriteLine();

            symbols = symbols.OrderByDescending(x => x.Probability).ToList();
            ShannonFanoSymbol.Show(symbols);

            Console.WriteLine();
            Console.WriteLine("Таблица с кодом для каждого символа: ");
            Console.WriteLine();

            symbols = AddCodes(symbols);
            foreach (var symbol in symbols)
            {
                symbol.Code = symbol.Code.Remove(symbol.Code.Length - 1, 1);
            }

            ShannonFanoSymbol.Show(symbols);

            blockofFIO = "Palaznik";
            decodingOfFIO = "";
            foreach (var charFIO in blockofFIO)
            {
                decodingOfFIO += (symbols.FirstOrDefault(x => x.Symbol == charFIO)?.Code) ?? "";
            }
            Console.WriteLine("Исходное сообщение: ");
            Console.WriteLine(blockofFIO);
            Console.WriteLine("Сообщение после кодировки: ");
            Console.WriteLine(decodingOfFIO);
            Console.WriteLine("Количество битов в кодах ASCII: " + blockofFIO.Length * 8);
            Console.WriteLine("Количество битов по таблице Шеннон-Фано: " + decodingOfFIO.Length);
            Console.WriteLine("____________________________________");
            Console.WriteLine();
            Console.WriteLine("Декодирование");


            Encoded = "";
            FIOdecoded = "";
            for (int i = 0; i < decodingOfFIO.Length; i++)
            {
                Encoded += decodingOfFIO[i];
                if (symbols.Find(x => x.Code == Encoded) != null)
                {
                    FIOdecoded += symbols.Find(x => x.Code == Encoded).Symbol;
                    Encoded = "";
                }
            }
            Console.WriteLine(FIOdecoded);

            Console.ReadLine();
        }

        public static List<ShannonFanoSymbol> AddCodes(List<ShannonFanoSymbol> symbols)
        {
            int counter = 0;
            double probability = 0.0;
            List<ShannonFanoSymbol> first = new List<ShannonFanoSymbol>();
            List<ShannonFanoSymbol> second = new List<ShannonFanoSymbol>();

            while (probability < (symbols.Sum(x => x.Probability) / 2))
            {
                probability += symbols[counter].Probability;
                counter++;
            }
            for (int i = 0; i < counter; i++)
            {
                symbols[i].Code += "0";
                first.Add(symbols[i]);
            }
            for (int i = counter; i < symbols.Count; i++)
            {
                symbols[i].Code += "1";
                second.Add(symbols[i]);
            }
            if (symbols.Count > 1)
            {
                first = AddCodes(first);
                second = AddCodes(second);

                first.AddRange(second);

                symbols = first;
            }

            return symbols;
        }
    }
}