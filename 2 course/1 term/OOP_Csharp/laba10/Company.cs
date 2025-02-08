using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    internal class Company
    {
        public string name { get; set; }
        public string language { get; set; }
        public Company(string name, string language)
        {
            this.name = name;
            this.language = language;
        }
    }
}
