using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
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

        public Train(int speed)
        {
           

            if (speed == 0)
            {
                throw new TrainSpeedExceptions("Скорость равна нулю", "hihi");
            }

            this.speed = speed;
        }

        public Train(int speed, bool wheels)
        {


            if (speed == 0)
            {
                throw new TrainSpeedExceptions("Скорость равна нулю", "hihi");
            }

            this.speed = speed;

            if (wheels == false)
            {
                throw new TrainSpeedExceptions("Колес нет", "hihi");
            }
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
