using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal interface I1
    {
        public string NameI1 { get; set; }
        public void PublicMethodI1();
        public event LoginDelegate? Notify;

        C2 this[int index]
        {
            get;
            set;
        }
    }
}
