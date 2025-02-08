using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laba5;

namespace laba5
{
        internal abstract class Transport : ITransportMove
        {
            public int speed { get; set; }
      
        public int cost { get; set; }
        
      
        public abstract void Move();
        public abstract void ToString1();

        public struct Specs
            {              
                public int fuelConsume;
        }

        public Transport()
            {
                Random rand = new Random();
                Specs specs = new Specs();
                this.speed = rand.Next(100, 500);
                specs.fuelConsume = 10; 
                int cost = 500;
                Controller.costCount(cost);
            
            } 
        }

}
