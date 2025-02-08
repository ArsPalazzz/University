using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    internal class Train : Transport
    {
        int trainNumber;
        public override void ToString()
        {
            Console.WriteLine($"Это поезд {this}. Он может использовать Move, чтобы ехать по рельсам..");
        }
        public override void Move()
        {
            Console.WriteLine("Поезд движется по рельсам.");
        }
       
    }
}
