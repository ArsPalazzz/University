using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    internal static class StatisticOperation
    {

        public static int Summa(MyList a)                                      // сумма элементов
        {
            int sum = 0;
            for (int i = 0; i < a.listA.Length; i++)
            {
                sum = sum + a.listA[i];
            }
            return sum;
        }
        public static int MaxMinDif(MyList a)                                  //поиск разницы между максимальным и минимальным эл-ми списка
        {
            int dif = 0;
            int max = a.listA[0];
            int min = a.listA[0];
            for (int i = 0; i < a.listA.Length; i++)
            {
                if (a.listA[i] > max)
                {
                    max = a.listA[i];
                }
            }
            for (int i = 0; i < a.listA.Length; i++)
            {
                if (a.listA[i] < min)
                {
                    min = a.listA[i];
                }
            }
            dif = max - min;
            return dif;
        }
        public static int Counter(this MyList a)                                      // подсчёт элементов
        {
            int count = 0;
            for (int i = 0; i < a.listA.Length; i++)
            {
                count++;
            }
            return count;
        }

        public static char[] FindNum(this string str) //поиск первого числа в строке
        {
            // Получаем индекс первой цифры в строке
            int firstIndex = str.IndexOf(str.Where(x => Char.IsDigit(x)).First());
            //where - выбор элементов из некоторого набора по условию
            //Char.isDigit(char) - используется, чтобы проверить, соответствует ли указанный символ Unicode
            //десятичной цифре или нет. Если он совпадает, то возвращает True, в противном случае возвращает False.
            //First() - возвращает первый элемент последовательности

            int counter = 1;
            int value;

            // Считаем количество индексов до первого неудачного TryParse
            for (int i = firstIndex + 1; i < str.LastIndexOf(str.Last()); i++)
            {
                if (int.TryParse(str[i].ToString(), out value))
                {
                    counter++;
                }
                else break;
            }

            // Массив для числа
            char[] result = new char[counter];

            // Закидываем первое чило посимвольно в строку
            for (int i = 0; i < counter; i++)
            {
                result[i] = str[firstIndex + i];
            }

            return result;
        }

        public static int[] DelPlus(MyList a)                                      // обнуление положительных
        {
            int size = a.listA.Length;
            int[] newArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                if (a.listA[i] > 0)
                {
                    a.listA[i] = 0;
                    newArray[i] = a.listA[i];
                }
                else
                {
                    newArray[i] = a.listA[i];
                }

            }
            return newArray;
        }

    }
}
