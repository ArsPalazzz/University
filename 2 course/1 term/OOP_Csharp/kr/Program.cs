using System;

namespace kr2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SuperList<int> list = new SuperList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            

            list.Show();
            //Numbers[] numbers = new Numbers[3]
            //{
            //    new Numbers(5),
            //    new Numbers(6),
            //    new Numbers(7),
            //};
            //SuperList<Numbers> numbersList = new SuperList<Numbers>(numbers);
            //foreach (var g in numbersList)
            //{
            //    Console.WriteLine("Число: " + g.Numb);
            //}
            //numbersList.Find(5);
            //foreach (Numbers g in numbersList)
            //{
            //    Console.WriteLine("Число: " + g.Numb);
            //}
        }
    }
}
