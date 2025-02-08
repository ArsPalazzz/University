using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    internal class Express : Train
    {
        int expressNumber;

        public Express() : base()
        {

        }

        public void ExpressOrNot()
        {
            Console.WriteLine("Поезд является Экспрессом");
        }
    }
}
