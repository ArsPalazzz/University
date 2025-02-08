using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    internal class Controller
    {
        static int prices = 0;
        public static void Adder(ref Transport a, ref Container container)
        {
            container.Add(a);
        }
        public static void Adder(ref Car a, ref Container container)
        {
            container.Add(a);
        }
        public static void Adder(ref Train a, ref Container container)
        {
            container.Add(a);
        }


        public static void findbySpeed(int speed1, int speed2, ref Container container)
        {
            foreach (Transport c in container.AllObjects)
            {
                if (c.speed > speed1 && c.speed < speed2)
                {
                    Console.WriteLine($"Найдено транспортное средство {c} со скоростью в диапазоне от {speed1} до {speed2}");
                }
            }


        }

        public static void costCount(int price)
        {
            prices += price;
        }
        public static void CW()
        {
            Console.WriteLine("Стоимость всего транспорта агенства: " + prices);
        }
        public static void sort(ref Car[] cars)
        {
            Console.WriteLine("Автомобили по расходу топлива: \n\n");
            for (int i = 0; i < cars.Length; i++)
            {
                for (int j = 0; j < cars.Length; j++)
                {
                    if (cars[i].fuelConsume > cars[j].fuelConsume)
                    {
                        int temp = cars[i].fuelConsume;
                        cars[i].fuelConsume = cars[j].fuelConsume;
                        cars[j].fuelConsume = temp;
                    }
                }
            }
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine($"[{i}]\t-\t{cars[i].fuelConsume}");
            }
        }
    }
}
