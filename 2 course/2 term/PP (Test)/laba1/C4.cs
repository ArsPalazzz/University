using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class C4 : C3
    {
        //public const string university = "BSTU";
        public const int course = 3;
        //public int group = 1;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public C4(string name, string email, string pass, int age): base(name, email, pass)
        {
            Age = age;
        }
        public override void Print()
        {
            Console.WriteLine($"Constructor with parameters (C4)\nAge: {Age}");
            Console.WriteLine($"University: {university}\nCourse: {course}\nGroup: {group}");
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
