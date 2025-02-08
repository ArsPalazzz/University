using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    
        internal class Vagon : Train
        {

        public Vagon() : base()
            {

            }
        public override void ToString1()
            {
                Console.WriteLine($"Это машина {this}. Она может использовать Move, чтобы ехать..");
            }
        }
}
