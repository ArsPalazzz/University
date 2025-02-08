using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace laba3
{
    public static class PreviousLab
    {
        public enum AlphabetList
        {
            Danish,
            Kazakh,
            Binary,
            Base64
        }

        public static double CalculateEntropy(AlphabetList alphabet, float errorProbability = 0)
        {
            string alphabetSymbols = "";
            string filePath = "";

            switch (alphabet)
            {
                case AlphabetList.Danish:
                    alphabetSymbols = "qwertyuiopasdfghjklzxcvbnmæøå";
                    filePath = "datch.txt";
                    break;
                case AlphabetList.Kazakh:
                    alphabetSymbols = "аәбвгдеёжзийклмнопрстуфхцчшщъыьэюяғқңөұҺ";
                    filePath = "kazakh.txt";
                    break;
                case AlphabetList.Binary:
                    alphabetSymbols = "01";
                    filePath = "binary.bin";
                    break;
                case AlphabetList.Base64:
                    alphabetSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
                    filePath = "base64.txt";
                    break;
            }

            Dictionary<char, int> symbolCounts = new Dictionary<char, int>();
            foreach (char ch in alphabetSymbols)
            {
                symbolCounts[ch] = 0;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd().ToLower();
                foreach (char ch in content)
                {
                    if (alphabetSymbols.Contains(ch))
                    {
                        symbolCounts[ch]++;
                    }
                    else if (alphabet != AlphabetList.Base64)
                    {
                        content = content.Remove(content.IndexOf(ch), 1);
                    }
                }

                double entropy = 0;
                foreach (char ch in alphabetSymbols)
                {
                    if (symbolCounts[ch] > 0)
                    {
                        double probability = (double)symbolCounts[ch] / content.Length * (1 - errorProbability);
                        entropy += probability * Math.Log(probability, 2);
                    }
                }

                return -entropy;
            }
        }
    }
}
