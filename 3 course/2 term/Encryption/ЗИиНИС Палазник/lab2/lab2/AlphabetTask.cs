using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace lab2
{
    public static class AlphabetTask
    {
        // Перечисление алфавитов
        public enum Alphabets
        {
            Danish,
            Kazakh,
            Binary
        }

        // Метод для вычисления энтропии алфавита
        public static double CalculateEntropy(Alphabets alphabet, float errorProbability = 0)
        {
            string symbols = "";
            string filePath = "";
            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            switch (alphabet)
            {
                case Alphabets.Danish:
                    symbols = "qwertyuiopasdfghjklzxcvbnmæøå";
                    filePath = "datch.txt";
                    break;
                case Alphabets.Kazakh:
                    symbols = "аәбвгдеёжзийклмнопрстуфхцчшщъыьэюяғқңөұҺ";
                    filePath = "kazakh.txt";
                    break;
                case Alphabets.Binary:
                    symbols = "01";
                    filePath = "binary.bin";
                    break;
            }

            foreach (var ch in symbols)
                occurrences[ch] = 0;

            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string content = reader.ReadToEnd().ToLower();
                foreach (var ch in content.Where(ch => symbols.Contains(ch)))
                {
                    occurrences[ch]++;
                }

                double entropy = 0;
                foreach (var ch in symbols)
                {
                    if (occurrences[ch] > 0)
                    {
                        double probability = (double)occurrences[ch] / content.Length * (1 - errorProbability);
                        entropy += probability * Math.Log2(probability);
                    }
                }

                return -entropy;
            }
        }

        // Метод для подсчета частоты символов
        public static void CountSymbolFrequency(Alphabets alphabet)
        {
            string filePath = "";
            string symbols = "";
            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            switch (alphabet)
            {
                case Alphabets.Danish:
                    filePath = "datch.txt";
                    symbols = "qwertyuiopasdfghjklzxcvbnmæøå";
                    break;
                case Alphabets.Kazakh:
                    filePath = "kazakh.txt";
                    symbols = "аәбвгдеёжзийклмнопрстуфхцчшщъыьэюяғқңөұҺ";
                    break;
            }

            foreach (var ch in symbols)
                occurrences[ch] = 0;

            string content;

            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }

            foreach (var ch in content.Where(ch => symbols.Contains(ch)))
            {
                occurrences[ch]++;
            }

            foreach (var kvp in occurrences)
            {
                char symbol = kvp.Key;
                int count = kvp.Value;
                double probability = (double)count / content.Length;

                Console.WriteLine($"Символ: {symbol}, Количество повторений: {count}, Вероятность: {probability}");
            }
        }

        // Метод для получения количества появлений символов в строке
        public static Dictionary<char, int> GetCharacterOccurrences(string text)
        {
            var occurrences = new Dictionary<char, int>();

            foreach (char ch in text)
            {
                if (occurrences.ContainsKey(ch))
                {
                    occurrences[ch]++;
                }
                else
                {
                    occurrences.Add(ch, 1);
                }
            }

            return occurrences;
        }
    }
}
