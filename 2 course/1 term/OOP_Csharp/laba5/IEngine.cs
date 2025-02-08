using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    internal sealed class IEngine
    {
        enum Specs
        {
            disabled = 0,
            enabled = 1
        }
        struct Stats
        {
            int status;
            int waste;
            int hp;
        }
        public void Work()
        {
            Console.WriteLine("Двигатель работает");
        }
    }
}
