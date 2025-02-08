using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    internal class Container
    {
     
        public List<Transport> AllObjects { get; private set; }   
        private readonly int maxCargoQuantity;     
        private readonly int maxCost;     
        private int CurrentCost { get; set; }    
        private int CurrentCargoQuantity { get; set; }


        public Container()
        {
            maxCargoQuantity = CurrentCargoQuantity = 100000;
            maxCost = 10;
            CurrentCost = 0;
            AllObjects = new List<Transport>();
            PrintInfo();
        }

        public Container(int cargoQ)
        {
            maxCargoQuantity = CurrentCargoQuantity = cargoQ;
            maxCost = 10;
            CurrentCost = 0;
            AllObjects = new List<Transport>();
            PrintInfo();
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Transport Info: Max Cargo Quantity: {maxCargoQuantity}, current Cargo Quantity: {CurrentCargoQuantity}, current cost: {CurrentCost}");
            Console.WriteLine("Transport List");
            foreach (var i in AllObjects) { Console.WriteLine(i.ToString()); }
        }

        public void Add(Transport item)
        {
            AllObjects.Add(item);
            CurrentCargoQuantity -= item.cost;
            CurrentCost++;
        }

        public void Delete(Transport item)
        {
            AllObjects.Remove(item);
            CurrentCargoQuantity += item.cost;
            CurrentCost--;
        }
    }
}
