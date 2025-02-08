using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    internal class Car : Transport, IControl
    {
        public string Color { get; set; }
        public string CarBrand { get; set; }
        public Car(bool havingWheels, bool brokenRoof, string carBrand) : base(havingWheels, brokenRoof)
        {
            CarBrand = carBrand;
        }

        void IControl.upCar()
        {
            Console.WriteLine("Сломана ли у машины крыша? : ");
            BrokenRoof = Convert.ToBoolean(Console.ReadLine());
        }

        void IControl.downCar()
        {
            Console.WriteLine("Есть ли у машины колеса(желательно рабочие)? : ");
            HavingWheels = Convert.ToBoolean(Console.ReadLine());
        }

        void IControl.middleCar()
        {
            Console.WriteLine("Сколько литров бензина у данной машины? : ");
            FuelLiters = Convert.ToInt32(Console.ReadLine());
        }

        public override bool Equals(object obj)
        {
            if ((string)obj == "green")
                return true;
            else return false;
        }
        public sealed override int GetHashCode()
        {
            Random rnd = new Random();
            int rand = rnd.Next(1, 131);
            return rand;
        }
        public override string ToString()       // переопределние метода ToString()
        {
            return "Car has a " + Color + " color and it's " + CarBrand + " brand";
        }
    }
}
