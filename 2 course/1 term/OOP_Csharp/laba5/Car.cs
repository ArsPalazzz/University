using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba5;

namespace laba5
{
        internal class Car : Transport
        {

            IEngine engine2;
            public int fuelConsume;
            public struct Specs
            {
                public int speed;
                public int price;
            }

            enum Type
            {
                oil = 0,
                electro = 1
            }
            public int speed { get; set; }
            public void Сar()
            {
                Random rand = new Random();
                this.fuelConsume = rand.Next(3, 10);
                this.speed = rand.Next(3, 10);
            }
            public override void ToString1()
            {
                Console.WriteLine($"Это машина {this}. Она может использовать Move, чтобы ехать..");
            }
            public override void Move()
            {
                Console.WriteLine("Автомобиль движется по дороге.");
            }

        }
}
