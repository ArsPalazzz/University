using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
namespace exam
{
    interface INumber
    {
        int Number { get; set; }
    }
    [Serializable]
    public class Bill : INumber
    {
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if ((value == 5) || (value == 10) || (value == 20) || (value == 50) || (value == 100))
                {
                    number = value;
                }
                else
                {
                    Console.WriteLine("Деньги не приняты");
                }
            }
        }

        public Bill (int numb)
        {
            number = numb;
        }
    }
    [Serializable]
    public class Wallet<T> where T : Bill
    {
        List<Bill> list = new List<Bill>();
        public void Adder(Bill value)
        {
            if (value.Number > 200)
            {
                throw new Exception("TooMuchMoney");
            }
            else
            {
                list.Add(value);
                Console.WriteLine("Валюта добавлена");
                Console.WriteLine("Весь кошелек:");
                foreach(Bill money in list)
                {
                    Console.Write($"{money.Number}  ");
                }
            }
           
        }
        public void Remover()
        {
            if (list.Count == 0)
            {
                throw new Exception("NoBillinWallet");
            }
            else
            {
                IEnumerable<Bill> allTheBills = from b in list
                                                orderby b.Number
                                                select b;
                list.Remove(allTheBills.First());
                Console.WriteLine("Валюта удалена");
                Console.WriteLine("Весь кошелек:");
                foreach (Bill money in list)
                {
                    Console.WriteLine(money.Number);
                }
            }
           
        }

        public void Count()
        {

            var count = from i in list group i by i.Number;
            foreach (var i in count)
            {
                Console.WriteLine($"{i.Key} {i.Count()}");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Wallet<Bill> wallet = new Wallet<Bill>();
            Bill bill5 = new Bill(5);
            Bill bill10 = new Bill(10);
            Bill bill20 = new Bill(20);
            Bill bill50 = new Bill(50);
            Bill bill100 = new Bill(100);
            for (int i = 0; i < 5; ++i)
            {
                wallet.Adder(bill5);
            }
            for (int i = 0; i < 5; ++i)
            {
                wallet.Adder(bill10);
            }
            for (int i = 0; i < 5; ++i)
            {
                wallet.Adder(bill20);
            }
            for (int i = 0; i < 5; ++i)
            {
                wallet.Adder(bill50);
            }
            for (int i = 0; i < 5; ++i)
            {
                wallet.Adder(bill100);
            }
            wallet.Count();

            var jsonObj = new DataContractJsonSerializer(typeof(Wallet<Bill>));
            using (var file = new FileStream("bill.json", FileMode.OpenOrCreate))
            {
                jsonObj.WriteObject(file, wallet);
            }
            using (var file = new FileStream("bill.json", FileMode.OpenOrCreate))
            {
                Wallet<Bill> newBill = (Wallet<Bill>)jsonObj.ReadObject(file);
            }

        }
    }
}
