using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my
{ 

    public class Person
    {
        public string Name { get; }
        public Person(string name) => Name = name;
    }

    public interface IComparable
    {
        bool CompareTo();
    }
    public class Computer : IComparable
    {
        public static readonly int one = 45;
        public static int two = 54;
        public int three = 66;

        public override bool CompareTo()
        {
            if (Equals)
            {
                Console.WriteLine("У Ауди больше ассортимент");
            }
            if (arra2[0] < arra2[1])
            {
                Console.WriteLine("У Рино больше ассортимент");
            }
        }
    }
}
