using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    
        internal class Vagon : Train
        {
            public override void ToString()
            {
                Console.WriteLine($"Это машина {this}. Она может использовать Move, чтобы ехать..");
            }
        }
}
