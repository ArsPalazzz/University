using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
     public class MyList
    {

        Production production = new Production(08374727, "ORG1"); //вложенный объект

        public int[] listA;
        public int[] listB;
        public MyList(int[] a, int[] b)
        {
            listA = a;
            listB = b;
        }
        public MyList(int[] a)
        {
            listA = a;
        }

        // перегрузки

        public static bool operator >(MyList a, int check) // проверка на принадлежность элемента списку А
        {
            int flag = 0;
            for (int i = 0; i < a.listA.Length; i++)
            {
                if (a.listA[i] == check)
                    flag++;
            }
            if (flag != 0) return true;
            else return false;
        }

        public static bool operator <(MyList a, int check)
        {
            return false;
        }

        public static bool operator *(MyList a, MyList b)
        {
            int counter = 0;
            for (int i = 0; i < a.listA.Length; i++)
            {
                for (int j = 0; j < b.listA.Length; j++)
                {
                    if (a.listA[i] == b.listA[j])
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
        /*
         public static int[] operator *(MyList a, MyList b) 
         {
             int size = 0;
             int[] rez = new int[size];
             for (int i = 0; i < a.mnojestvoA.Length; i++)
             {
                 for(int j = 0; j < b.mnojestvoA.Length; j++)
                 {
                     if (a.mnojestvoA[i] == b.mnojestvoA[j])
                     {
                         rez[size] = a.mnojestvoA[i];
                         size++;
                     }
                 }
             }

             return rez;
         }*/

        public static bool operator +(MyList a, int[] podMyList)
        {
            int counter = 0;
            for (int i = 0; i < a.listA.Length; i++)
            {
                for (int j = 0; j < podMyList.Length; j++)
                {
                    if (a.listA[i] == podMyList[j])
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



        internal class Developer                                                          //вложенный класс Developer
        {
            private string name;
            private string surname;
            private string patronymic;
            private int id;
            private string department;
            public Developer(string name, string surname, string patronymic, int id, string department)
            {
                this.name = name;
                this.surname = surname;
                this.patronymic = patronymic;
                this.id = id;
                this.department = department;
            }
            public void getInf()
            {
                Console.WriteLine($"\nName: {name}\nSurname: {surname}\nPatronic: {patronymic}\nId: {id}\nDepartment: {department}\n");
            }
        }
    }

    
}
