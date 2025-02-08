using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class TransportExceptions : Exception
    {
        public TransportExceptions(string message) : base(message)
        {
            
        }
       
    }
}
