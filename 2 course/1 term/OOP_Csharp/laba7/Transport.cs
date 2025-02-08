using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    public abstract class Transport : IControl
    {
        public bool HavingWheels { get; set; }
        public bool BrokenRoof { get; set; }
        public int FuelLiters { get; set; }

        public Transport(bool havingWheels, bool brokenRoof)
        {
            HavingWheels = havingWheels;
            BrokenRoof = brokenRoof;
        }

        public Transport()
        {

        }

        void IControl.upCar()
        {
            Console.WriteLine("Сломана ли у транспорта крыша? : ");
            BrokenRoof = Convert.ToBoolean(Console.ReadLine());
        }

        void IControl.downCar()
        {
            Console.WriteLine("Есть ли у транспорта колеса(желательно рабочие)? : ");
            HavingWheels = Convert.ToBoolean(Console.ReadLine());
        }

        void IControl.middleCar()
        {
            Console.WriteLine("Сколько литров бензина у данного транспорта? : ");
            FuelLiters = Convert.ToInt32(Console.ReadLine());
        }

    }
}
