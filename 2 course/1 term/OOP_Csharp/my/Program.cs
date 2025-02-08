using System;
using my;

namespace kr
{
    class Program
    {
        enum months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        static void Main(string[] args)
        {
            //1A
            Console.WriteLine("1A\n");
           Console.WriteLine($"{months.January}\n{months.February}\n{months.March}\n{months.April}\n{months.May}\n{months.June}\n{months.July}\n{months.August}\n" +
               $"{months.September}\n{months.October}\n{months.November}\n{months.December}");

            //1B
            Console.WriteLine("\n1B\n");
            string text = "123. 345. 678.";
            string[] numbs = text.Split(new char[] { ' ' });

            foreach (string s in numbs)
            {
                Console.WriteLine(s);
            }

            //2

            Person first = new Person("first");
            Person second = new Person("second");

            Console.WriteLine(first.Name);
            Console.WriteLine(second.Name);
        }
    }
}