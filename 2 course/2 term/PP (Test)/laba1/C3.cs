using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class C3
    {
        protected const string university = "BSTU";
        private const int course = 2;
        protected int group = 1;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public C3(string name, string email, string pass)
        {
            Name = name;
            Email = email;
            Password = pass;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Constructor with parameters (C3)\nName: {Name}\nEmail: {Email}\nPassword: {Password}\n");
        }
    }
}
