using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class C1
    {
        private const string university = "BSTU";
        public const int group = 1;
        protected const int course = 2;
        private string name = "undefined";
        public string email = "undefined";
        protected string password = null;

        private string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        protected string Password
        {
            get { return password; }
            set { password = value; }
        }

        //конструктор по умолчанию
        public C1()
        {
            Console.WriteLine($"Default constructor\nName: {this.name}\nEmail: {this.email}\nPassword: {this.password}\n");
        }

        //конструктор с параметрами
        public C1(string n, string e, string pass)
        {
            this.name = n;
            this.email = e;
            this.password = pass;
            Console.WriteLine($"Constructor with parameters\nName: {this.name}\nEmail: {this.email}\nPassword: {this.password}\n");
        }


        //конструктор копирования
        public C1(C1 instance)
        {
            name = instance.name;
            email = instance.email;
            password = instance.password;
            Console.WriteLine($"Copy Constructor\nName: {name}\nEmail: {email}\nPassword: {password}\n");
        }


        private void PrivateMethod()
        {
            Console.WriteLine("It's private method");
        }

        public void PublicMethod()
        {
            Console.WriteLine("It's public method");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("It's protected method");
        }

        public void State()
        {
            Console.WriteLine($"Name: {this.name}\nEmail: {this.email}\nPassword: {this.password}\nUniversity: {university}\nGroup: {group}\nCourse: {course}\n");
        }
    }
}
