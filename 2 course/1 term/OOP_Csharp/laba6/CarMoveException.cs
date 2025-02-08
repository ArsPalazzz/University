using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class CarMoveException : TransportExceptions
    {
        public CarMoveException(string message) : base(message)
        {
            
        }
        
    }
}
