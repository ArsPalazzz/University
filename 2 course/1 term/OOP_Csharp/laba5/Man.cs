using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    class Man : Transport, ITransportMove
    {
        public override void Move()
        {
            Console.WriteLine("This is result of Abstract Class Method Move");
        }

        void ITransportMove.Move()
        {
            Console.WriteLine("This is result of Interface Method Move");
        }

        public override void ToString1()
        {
            Console.WriteLine("This is result of Abstract Class Method ToString");
        }

        void ITransportMove.ToString1()
        {
            Console.WriteLine("This is result of Interface Method ToString");
        }
    }
}
