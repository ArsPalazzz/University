using System;

class Program
{
    static (int, int, char) FindCharacters(string dictionary, string bufferWord)
    {
        int indexInArray = 0;
        int length = 0;
        char lastElement = bufferWord[0];

        while (dictionary.Contains(bufferWord.Substring(0, length + 1)))
        {
            indexInArray = dictionary.IndexOf(bufferWord.Substring(0, length + 1)) + 1;
            length += 1;
            if (length == bufferWord.Length)
            {
                lastElement = '|';
                break;
            }
            else
            {
                lastElement = bufferWord[length];
            }
        }

        return (indexInArray, length, lastElement);
    }

    static (string, string) SendCharacters(string firstBuffer, string secondBuffer, int charactersCount)
    {
        charactersCount = Math.Min(charactersCount, secondBuffer.Length);
        if (charactersCount > 0)
        {
            firstBuffer += secondBuffer.Substring(0, charactersCount);
            secondBuffer = secondBuffer.Substring(charactersCount);
        }
        return (firstBuffer, secondBuffer);
    }

    static string TrimBuffer(string buffer, int size)
    {
        if (buffer.Length > size)
        {
            buffer = buffer.Substring(buffer.Length - size);
        }
        return buffer;
    }

    static void Main(string[] args)
    {
        const int dictionarySize = 8;
        const int bufferSize = 8;

        string inputMessage = "Palaznik Arseniy Viktorovich";
        string resultMessage = "";
        string word = inputMessage.Substring(0, bufferSize);
        string message = inputMessage.Substring(bufferSize);

        string dictionary = new string('0', dictionarySize);
        string codeWord = "";
        int iterationCount = 0;
        int totalIterations = inputMessage.Length / bufferSize;

        while (!string.IsNullOrEmpty(word))
        {
            (int p, int q, char c) = FindCharacters(dictionary, word);
            (dictionary, word) = SendCharacters(dictionary, word, q + 1);
            (word, message) = SendCharacters(word, message, q + 1);

            dictionary = TrimBuffer(dictionary, dictionarySize);
            word = TrimBuffer(word, bufferSize);

            codeWord += $"{p}{q}{c}";
            Console.WriteLine($"Dictionary:             {dictionary}");
            Console.WriteLine($"Buffer (Data):         {word}");
            Console.WriteLine($"Code Word:             {codeWord}");
            Console.WriteLine("-------------------------------");

            double lengthBeforeCompression = inputMessage.Length;
            double lengthAfterCompression = codeWord.Length;
            double compressionRatioBefore = lengthBeforeCompression / lengthAfterCompression;
            double compressionRatioAfter = (1 - compressionRatioBefore) * 100;
            Console.WriteLine($"Compression Ratio: {compressionRatioAfter:F2}%");

            iterationCount += 1;
        }

        dictionary = new string('0', dictionarySize);
        for (int i = 0; i < codeWord.Length; i += 3)
        {
            int p = int.Parse(codeWord[i].ToString());
            int q = int.Parse(codeWord[i + 1].ToString());
            char c = codeWord[i + 2];
            if (p == 0 && q == 0)
            {
                resultMessage += c;
                dictionary += c;
            }
            else
            {
                string strPart = dictionary.Substring(p - 1, q) + c;
                resultMessage += strPart;
                dictionary += strPart;
            }

            dictionary = TrimBuffer(dictionary, dictionarySize);
            Console.WriteLine($"Code:       {p} {q} {c}");
            Console.WriteLine($"Result:     {resultMessage}");
            Console.WriteLine($"Dictionary: {dictionary}");
            Console.WriteLine("-------------------------------");
        }
    }
}
