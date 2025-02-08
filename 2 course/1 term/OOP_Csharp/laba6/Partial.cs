using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    internal partial class Program
    {
        public class Printer
        {
            public void IAmPrinting(ITransportMove item)
            {
                item.ToString();
            }
        }
    }
}
