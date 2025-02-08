using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using laba6;

namespace laba6
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

        public int BrokenRoof { get; set; }


        public void Сar()
            {
                Random rand = new Random();
                this.fuelConsume = rand.Next(3, 10);
                this.speed = rand.Next(3, 10);
            }

            public Car(int fuelCons)
            {
                //if(fuelCons == 0)
                //{
                //    throw new CarMoveException("В автомобиле нет топлива");
                //}
                
                this.fuelConsume = fuelCons;
                Debug.Assert(this.fuelConsume != 0, "FuelCons can't be 0");
            //Проверяет условие. Если условие имеет значение false, выдается указанное сообщение и отображается окно сообщения со стеком вызовов.
            }
            
            public Car(int fuelCons, int brokenRoof)
            {
                if (fuelCons == 0)
                {
                    throw new CarMoveException("В автомобиле нет топлива");
                }

                if (brokenRoof == 0)
                {
                    throw new CarMultiplierExceptions("Крыша сломана");
                }
            this.fuelConsume = fuelCons;
            this.BrokenRoof = brokenRoof;
                Debug.Assert(this.fuelConsume != 0, "FuelCons can't be 0");
                //Проверяет условие. Если условие имеет значение false, выдается указанное сообщение и отображается окно сообщения со стеком вызовов.
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
