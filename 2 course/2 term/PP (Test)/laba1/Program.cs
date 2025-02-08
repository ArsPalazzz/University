using System;

namespace laba1
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Задание 2

            C1 instance1C1 = new C1();
            C1 instance2C1 = new C1("Arseniy", "palaz@gmail.com", "qwertyqwerty");
            C1 instance3C1 = new C1(instance2C1);

            //instance2.PrivateMethod();
            instance2C1.PublicMethod();
            //instance2.ProtectedMethod();

            instance2C1.State();
            instance2C1.Email = "ppp@gmail.com";
            instance2C1.State();


            //Задание 6

            C2 instance1C2 = new C2();
            instance1C2.Notify += instance1C2.NotifyMethod;
            instance1C2.FirstNotify("firstNotify");
            instance1C2.SecondNotify("secondNotify");

            Console.WriteLine("\nZadanie6\n");

            instance1C2.State();
            instance1C2.NameI1 = "Tanya";
            instance1C2.State();
            instance1C2.PublicMethodI1();


            C2 instance2C2 = new C2("Vlad", "vladik222", "vladiator@gmail.com");


            //9
            C3 instance1C3 = new C3("Vlad", "vladik222", "vladiator@gmail.com");
            instance1C3.Print();
            C4 instance1C4 = new C4("Tanya", "tanyatanya", "tanechka@gmail.com", 20);
            instance1C4.Print();

            Console.WriteLine($"Sum 4 and 5 is {instance1C4.Sum(4, 5)}");

        }
    }
}