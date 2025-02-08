using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    internal class Production
    {
        public int id;
        public string org;

        public Production(int id, string org)
        {
            this.id = id;
            this.org = org;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Org
        {
            get { return org; }
            set { org = value; }
        }

        public void getInfo()
        {
            Console.WriteLine($"\nID: {Id}\nОрганизация: {Org}\n");
        }
    }
}
