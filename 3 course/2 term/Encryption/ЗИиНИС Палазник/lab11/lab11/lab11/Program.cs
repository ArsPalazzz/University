using System;
using System.Collections.Generic;

public class Node
{
    public char Symbol { get; set; }
    public double Low { get; set; }
    public double High { get; set; }

    public Node( char symbol, double low, double high )
    {
        Symbol = symbol;
        Low = low;
        High = high;
    }

    public override string ToString()
    {
        return $"Low: {Low} | High: {High}";
    }
}

public class Compressor
{
    private List<Node> nodes;
    private Dictionary<char, double> frequencies;
    private Node resultNode;

    public Compressor()
    {
        nodes = new List<Node>();
        frequencies = new Dictionary<char, double>();
        resultNode = new Node('*', 1, 0);
    }

    public void Build( string source )
    {
        double inc = 1.0 / source.Length;
        foreach (char c in source)
        {
            if (!frequencies.ContainsKey(c))
            {
                frequencies[c] = 0;
            }
            frequencies[c] += inc;
        }

        double low = 0;
        foreach (var item in frequencies)
        {
            nodes.Add(new Node(item.Key, low, low + frequencies[item.Key]));
            low += frequencies[item.Key];
        }
    }

    public double Compress( string source )
    {
        List<string> infoString = new List<string>();
        foreach (char item in source)
        {
            double oldHigh = resultNode.High;
            double oldLow = resultNode.Low;
            infoString.Add(resultNode.ToString());
            resultNode.Symbol = '*';
            resultNode.High = oldLow + (oldHigh - oldLow) * nodes.Find(x => x.Symbol == item).High;
            resultNode.Low = oldLow + (oldHigh - oldLow) * nodes.Find(x => x.Symbol == item).Low;
        }
        infoString.Add(resultNode.ToString());
        return resultNode.Low;
    }

    public string Decompress( double compress, int leng, int t )
    {
        List<char> sb = new List<char>();
        List<string> infoString = new List<string>();
        for (int i = 0; i < leng; i++)
        {
            char symbol = nodes.Find(x => compress >= x.Low && compress < x.High).Symbol;
            infoString.Add($"{compress} -- {symbol}");
            sb.Add(symbol);
            Node tempNode = nodes.Find(x => x.Symbol == symbol);
            compress = (compress - tempNode.Low) / (tempNode.High - tempNode.Low);
        }
        return string.Join("", sb);
    }
}

class Program
{
    static void CalculateCompressionEfficiency( string compressed, string original )
    {
        int compressedLength = Math.Min(compressed.Length, 4);
        double efficiency = (1 - (double)compressedLength / original.Length) * 100;
        Console.WriteLine($"\nЭффективность сжатия арифметическим методом: {efficiency:F2}%");
    }

    static void CheckCompressionOverflow( double compressResult )
    {
        int maxBits = (int)Math.Log2(long.MaxValue) + 1;
        int bitsNeeded = Convert.ToString((long)compressResult, 2).Length;
        if (bitsNeeded > maxBits)
        {
            Console.WriteLine("Возможно переполнение при сжатии данных.");
        }
        else
        {
            Console.WriteLine("Переполнение при сжатии данных маловероятно.");
        }
    }

    static void Main( string[] args )
    {
        string word = "сорокадневный";
        Compressor wordCompressor = new Compressor();
        wordCompressor.Build(word);
        double compressResult = wordCompressor.Compress(word);
        Console.WriteLine($"Сжатые данные: {compressResult}");
        string decompressResult = wordCompressor.Decompress(compressResult, word.Length, word.Length / 2 + 1);
        Console.WriteLine($"Расжатые данные: {decompressResult}");
        CheckCompressionOverflow(compressResult);
        CalculateCompressionEfficiency(compressResult.ToString(), word);
    }
}
