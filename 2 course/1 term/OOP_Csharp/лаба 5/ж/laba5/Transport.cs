using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba5;

namespace laba5
{
    internal abstract class Transport : ITransportMove
    {
        public abstract void Move();
        public abstract void ToString();

        public Transport()
        {
            Console.WriteLine("Абстрактный класс Transport");
        }
    }

}
