using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab15
{
    class Product
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public Product(int price, string name)
        {
            Name = name;
            Price = price;
        }
    }
}
