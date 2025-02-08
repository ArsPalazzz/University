using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0
{
    abstract class Parrot
    {
        public string Name { get; }
        public string Weight { get; }
        public int Age { get; }

        public virtual void SayHello()
        {
            Console.WriteLine("Hi");
        }

    }

    class Parrot2 : Parrot
    {
        public string Name { get; }
        public string Weight { get; }
        public int Age { get; }

        public override void SayHello()
        {
            Console.WriteLine($"Hello, it's {Name}");
        }

        public Parrot2(string n, string w, int a)
        {
            Name = n;
            Weight = w;
            Age = a;
        }
    }
}
