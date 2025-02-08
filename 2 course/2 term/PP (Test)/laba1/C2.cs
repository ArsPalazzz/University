using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public delegate void LoginDelegate(string message);
    
    internal class C2 : I1
    {
        private const string university = "BSTU";
        public const int group = 1;
        protected const int course = 2;
        private string name = "undefined";
        public string email = "undefined";
        protected string password = null;

        public event LoginDelegate? Notify;


        C2[] arr;

        private string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string NameI1
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

        public C2 this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        //конструктор по умолчанию
        public C2()
        {
            Console.WriteLine($"Default constructor\nName: {this.name}\nEmail: {this.email}\nPassword: {this.password}\n");
        }

        //конструктор с параметрами
        public C2(string n, string e, string pass)
        {
            this.name = n;
            this.email = e;
            this.password = pass;
            Console.WriteLine($"Constructor with parameters\nName: {this.name}\nEmail: {this.email}\nPassword: {this.password}\n");
        }


        //конструктор копирования
        public C2(C2 instance)
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

        public void NotifyMethod(string mes)
        {
            Console.WriteLine(mes);
        }

        public void FirstNotify(string mes)
        {
            Notify?.Invoke($"First Notify. Your message: {mes}");
        }

        public void SecondNotify(string mes)
        {
            Notify?.Invoke($"Second Notify. Your message: {mes}");
        }

        public void PublicMethodI1()
        {
            Console.WriteLine("It's public method I1");
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
