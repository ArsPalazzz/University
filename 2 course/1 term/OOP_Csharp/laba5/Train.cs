using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    internal class Train : Transport
    {
        int trainNumber;

        public int speed { get; set; }
        struct Specs
        {
            int price;
            int fuelConsume;
            int trainNumber;
        }
        enum Type
        {
            longDistance = 0,
            shortDistance = 1,
            highSpeed = 2,
            interCity = 3
        }
        public Train()
        {
            Random rand = new Random();
            this.speed = rand.Next(100, 500);
        }
        public override void ToString1()
        {
            Console.WriteLine($"Это поезд {this}. Он может использовать Move, чтобы ехать по рельсам..");
        }
        public override void Move()
        {
            Console.WriteLine("Поезд движется по рельсам.");
        }
       
    }
}
