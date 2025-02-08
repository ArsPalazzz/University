using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace kr2
{
    internal class SuperList<T> : List<T>, IEnumerable<T>
    {
        private int[] _numbs;
        List<T> list = new List<T>();

        public void Add(T value)
        {
            list.Add(value);
        }
        public void Show()
        {
            foreach (var item in list)
                Console.WriteLine(item);
        }
        //IEnumerator IEnumerable.GetEnumerator() //IEnumerable имеет метод, возвращающий ссылку на другой интерфейс - перечислитель
        //{
        //    return (IEnumerator)GetEnumerator();
        //}
        //public NumbEnum GetEnumerator()
        //{
        //    return new NumbEnum(_numbs);
        //}

        //public void Find(int numb)
        //{
        //    bool findValue = false;
        //    foreach (int item in _numbs)
        //    {
        //        if (item == numb)
        //        {
        //            Console.WriteLine("\n\n\t--- Число найдено!");
        //            findValue = true;
        //        }
        //    }
        //    if (findValue == false)
        //    {
        //        //throw new Exeption("\n\n\t--- В данной коллекции не существует такого числа!");
        //    }

    }
    }



//public class NumbEnum : IEnumerator
//{
//    public int[] _numbs;
//    int position = -1;

//    public NumbEnum(int[] figures)
//    {
//        _numbs = figures;
//    }

//    public bool MoveNext()
//    {
//        position++;
//        return (position < _numbs.Length);
//    }

//    public void Reset()
//    {
//        position = -1;
//    }

//    object IEnumerator.Current
//    {
//        get
//        {
//            return Current;
//        }
//    }
//    public int Current
//    {
//        get
//        {
//            try
//            {
//                return _numbs[position];
//            }
//            catch (IndexOutOfRangeException)
//            {

//                throw new InvalidCastException();
//            }
//        }
//    }

//}
