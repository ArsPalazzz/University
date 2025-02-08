using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba4;

namespace laba4
{
    internal class Printer
    {
        public void IAmPrinting(ITransportMove item)
        {
            item.ToString();
        }
    }
}
