using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba4;

namespace laba4
{
        internal class Car : Transport
        {

            IEngine engine2;
            public Car() : base()
            {
                this.engine2 = new IEngine();
            }
            public override void ToString()
            {
                Console.WriteLine($"Это машина {this}. Она может использовать Move, чтобы ехать..");
            }
            public override void Move()
            {
                Console.WriteLine("Автомобиль движется по дороге.");
            }

        }
}
