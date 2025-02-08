using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    public class CollectionType<T> : IGeneric<T> where T : class
        //T - универсальный тип
    {
        List<T> list = new List<T>();   // обобщенная коллекция

        public void Add(T item)
        {
            list.Add(item);
            Console.WriteLine("The Element is added");
        }
        public void Delete(T item)
        {
            list.Remove(item);
            Console.WriteLine("The Element is deleted");
        }
        public void Viewing()
        {
            Console.WriteLine("The elements are:");
            if (list.Count > 0)
                foreach (T item in list)
                {
                    Console.WriteLine(item);
                }
            else
                Console.WriteLine("The List is empty");
        }



        public void WriteTextFile()
        {
            string path = @"D:\Study\ООПиП(Экзамен)\laba7\Data.txt";
            foreach (var item in list)
            {
                try
                {
                    // Если равно true, то новые данные добавляются в конец файла. Если равно false, то файл перезаписываетсяя заново
                    // параметр encoding указывает на кодировку, которая будет применяться при записи
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(item);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void ReadTextFile()
        {
            string path = @"D:\Study\ООПиП(Экзамен)\laba7\Data.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }



        public int[] arrayA;
        public int[] arrayB;
        // внешний объект класса Array
        public Production myProd = new Production() { id = 0, orgName = "your_company" };

        public CollectionType() { myProd = null; }
        public CollectionType(int[] a, int[] b)
        {
            arrayA = a;
            arrayB = b;
        }
        public CollectionType(int[] a)
        {
            arrayA = a;
        }
        // перегрузки


        public static bool operator >(CollectionType<T> a, int check) // проверка на принадлежность элемента списку А
        {
            int flag = 0;
            for (int i = 0; i < a.arrayA.Length; i++)
            {
                if (a.arrayA[i] == check)
                    flag++;
            }
            if (flag != 0) return true;
            else return false;
        }

        public static bool operator <(CollectionType<T> a, int check)
        {
            return false;
        }

        public static bool operator *(CollectionType<T> a, CollectionType<T> b)
        {
            int counter = 0;
            for (int i = 0; i < a.arrayA.Length; i++)
            {
                for (int j = 0; j < b.arrayA.Length; j++)
                {
                    if (a.arrayA[i] == b.arrayA[j])
                    {
                        counter++;
                    }
                }
            }
            if (counter != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator +(CollectionType<T> a, int[] podMyList)
        {
            int counter = 0;
            for (int i = 0; i < a.arrayA.Length; i++)
            {
                for (int j = 0; j < podMyList.Length; j++)
                {
                    if (a.arrayA[i] == podMyList[j])
                    {
                        counter++;
                    }
                }
            }
            if (counter == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // создание вложенного класса
        public class Developer
        {
            public string surname { set; get; }
            public int id { set; get; }
            public string part { set; get; }
        }
    }
}
