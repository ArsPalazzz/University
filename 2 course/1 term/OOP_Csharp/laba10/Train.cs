using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
   class Train
    {
        public string stopPoint;
        public int trainNumber;
        public DateTime startTime = new DateTime();
        public int[] places = { 0, 0, 0, 0 };


        public const int MAXTRAINNUMBER = 200;


        readonly int identity;


        public static int numberofTrains = 0;

        public Train(DateTime startTime, string stopPoint = "ОШИБОЧНЫЙ ВВОД", int trainNumber = 0)
        {
            this.stopPoint = stopPoint;
            this.trainNumber = trainNumber;
            this.startTime = startTime;
            numberofTrains++;
            Random rand = new Random();
            for (int i = 0; i < this.places.Length; i++)
            {
                this.places[i] = rand.Next(0, 100);
            }
            Console.WriteLine($"Новый поезд создан, его данные:\n Точка остановки - \t {stopPoint}\n Номер поезда - \t {trainNumber}\n Время отправки - \t {startTime}");
        }

        public void input(ref Train[] trains, int index, DateTime startTime, string stopPoint = "ОШИБОЧНЫЙ ВВОД", int trainNumber = 0)
        {
            trains[index] = new Train(startTime, stopPoint, trainNumber);
        }
        static Train()
        {
            Console.WriteLine("-\t- ПОЕЗДА -\t-");

        }


        private Train()
        {
            this.identity = trainNumber.GetHashCode();
        }


        public int platformCheck
        {
            set
            {
                if (trainNumber >= MAXTRAINNUMBER)
                {
                    Console.WriteLine($"Не желательно использовать номер больший чем {MAXTRAINNUMBER}, это может привести к путанице.");
                }
            }
            get
            {
                return 0;
            }
        }

        public void placesShow()
        {

            Console.WriteLine("-\tСПИСОК МЕСТ ПОЕЗДА\t-");
            string[] placetoString = { "Общие: ", "Купе: ", "Плацкарт: ", "Люкс: " };
            for (int i = 0; i < this.places.Length; i++)
            {
                Console.Write(placetoString[i]);
                Console.WriteLine(this.places[i]);
            }
            int sum = 0;
            for (int i = 0; i < this.places.Length; i++)
            {
                sum += this.places[i];
            }

            Console.WriteLine("Всего мест в поезде: " + sum);
        }

        public static void details()
        {
            Console.WriteLine($"Информация о классе:\n Класс Trains используется для хранения информации о поездах и их особенностях");
        }

        public static void foreacher(IEnumerable<object> outStrings)
        {
            foreach (var item in outStrings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
        }
    }
    
}
