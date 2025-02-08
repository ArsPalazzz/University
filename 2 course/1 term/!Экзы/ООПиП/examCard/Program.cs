//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace exam
//{
//    interface IAction<T>
//    {
//        void Adder(T a);
//        void Remover(int a);
//        void Clear();
//        void Show();
//    }
//    public class Student
//    {
//        private string name;
//        private int mark;
//        private string subject;
//        public string Name { 
//            get
//            {
//                return name;
//            } 
//            set
//            {
//                if (value != null)
//                {
//                    name = value;
//                }
//                else
//                {
//                    Console.WriteLine("name не может быть равен null");
//                }

//            }
//        }
//        public int Mark { 
//            get
//            {
//                return mark;
//            }
//            set
//            {
//                mark = value;
//            }
//        }
//        public string Subject {
//            get
//            {
//                return subject;
//            }
//            set
//            {
//                if (value != null)
//                {
//                    subject = value;
//                }
//                else
//                {
//                    Console.WriteLine("subject не может быть равен null");
//                }

//            }
//        }

//        public Student()
//        {

//        }

//        public Student(string Name, int Mark, string Subject)
//        {
//            name = Name;
//            mark = Mark;
//            subject = Subject;
//        }

//        public override string ToString()
//        {
//            return $"{name} {mark} {subject}";
//        }
//    }
//    public class NullSizeCollection : System.Exception
//    {

//    }
//    public class ExamCard<T> : IAction<T> where T : new()
//    {
//        public static List<T> list = new List<T>();
//        void IAction<T>.Adder(T a)
//        {
//            list.Add(a);
//            Console.WriteLine("Данные добавлены");
//        }

//        void IAction<T>.Remover(int index)
//        {
//            if ((list.Count != 0))
//            {
//                try
//                {
//                    list.RemoveAt(index);
//                    Console.WriteLine($"Элемент по индексу {index} был удален");
//                }
//                catch(NullSizeCollection ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }

//            }
//            else
//            {
//                Console.WriteLine("NullSizeCollection");
//            }

//        }

//        void IAction<T>.Clear()
//        {
//            if (list.Count != 0)
//            {
//                list.Clear();
//                Console.WriteLine("Список очищен");
//            }
//            else
//            {
//                Console.WriteLine("NullSizeCollection");
//            }


//        }

//        void IAction<T>.Show()
//        {
//            Console.WriteLine("Вся коллекция:");
//            foreach (T a in list)
//            {
//                Console.WriteLine(a);
//            }
//        }
//    }

//    public static class extClass {
//        public static void rand(this Student x)
//        {
//            Random random = new Random();
//            x.Mark += random.Next(3);
//        }
//    }

//    class Program
//    {
//        public static void Main(string[] args)
//        {
//            Console.WriteLine("Zadanie3");
//            ExamCard<Student> studentExamCard = new ExamCard<Student>();
//            Student stud1 = new Student("first", 10, "OOP");
//            Student stud2 = new Student("second", 5, "OOP");
//            Student stud3 = new Student("third", 3, "OOP");
//            Student stud4 = new Student("fourth", 4, "OOP");
//            Student stud5 = new Student("fifth", 8, "OOP");

//            ((IAction<Student>)studentExamCard).Adder(stud1);
//            ((IAction<Student>)studentExamCard).Adder(stud2);
//            ((IAction<Student>)studentExamCard).Adder(stud3);
//            ((IAction<Student>)studentExamCard).Adder(stud4);
//            ((IAction<Student>)studentExamCard).Adder(stud5);
//            ((IAction<Student>)studentExamCard).Show();
//            ((IAction<Student>)studentExamCard).Remover(4);
//            ((IAction<Student>)studentExamCard).Show();
//            ((IAction<Student>)studentExamCard).Remover(3);
//            ((IAction<Student>)studentExamCard).Remover(2);
//            ((IAction<Student>)studentExamCard).Remover(1);
//            ((IAction<Student>)studentExamCard).Remover(0);
//            ((IAction<Student>)studentExamCard).Remover(0);

//            Console.WriteLine("Zadanie4");
//            //IEnumerable<Student> linq1 = ExamCard<Student>.list.Where(p => p.Mark >= 4).Select(p => p);
//            //foreach (Student linq in linq1)
//            //{
//            //    Console.WriteLine(linq);
//            //}
//            //var linq2 = ExamCard<Student>.list.Select(p => p.Mark);
//            //Console.WriteLine(linq2.Average());
//            var linq1 = from s in ExamCard<Student>.list
//                        where s.Mark >= 4
//                        select s;
//            Console.WriteLine(linq1.Count());
//            var linq2 = from s in ExamCard<Student>.list
//                        select s.Mark;
//            //Console.WriteLine(linq2.Average());

//            Console.WriteLine("Zadanie5");
//            stud1.rand();
//            Console.WriteLine(stud1);
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examCard
{
    class Students
    {
        public int mark;
        public string name;
        public string subject;
        public Students(string Name, int Mark, string Subject)
        {
            this.name = Name;
            this.mark = Mark;
            this.subject = Subject;
        }
        public Students()
        {

        }
        public override string ToString()
        {
            return mark + " " + name + " " + subject;
        }
    }

    interface IAction<T>
    {
        void Add(T a);
        void Del(T a);
        void Clean();
        void Show();

    }
    class ExamCard<T> : IAction<T> where T : new()
    {

        public static List<T> list = new List<T>();

        public void Add(T a)
        {
            list.Add(a);

        }
        public void Del(T a)
        {

            try
            {
                if (list.Count == 0)
                {
                    throw new NullSizeCollection("Коллекция пустая");
                }
                else list.Remove(a);
            }
            catch (NullSizeCollection ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Clean()
        {
            try
            {
                if (list.Count == 0)
                {
                    throw new NullSizeCollection("Коллекция пустая");
                }
                else list.Clear();
            }
            catch (NullSizeCollection ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Show()
        {
            Console.WriteLine("Вся коллекция: ");
            foreach (var l in list)
                Console.WriteLine(l);
        }
    }
    class NullSizeCollection : Exception
    {
        private string message;
        public override string Message
        {
            get
            {
                return message;
            }
        }
        public NullSizeCollection(string mess)
        {

            message = mess;
        }
    }



    static class Met
    {
        public static void qwe(this Students st)
        {
            Random random = new Random();
            st.mark += random.Next(1, 3);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Students st1 = new Students("qwe", 6, "rer");
            Students st2 = new Students("qwe", 7, "rer");
            Students st3 = new Students("qwe", 5, "rer");
            Students st4 = new Students("qwe", 3, "rer");
            ExamCard<Students> st = new ExamCard<Students>();
            ((IAction<Students>)st).Add(st1);
            ((IAction<Students>)st).Add(st2);
            ((IAction<Students>)st).Add(st3);
            ((IAction<Students>)st).Add(st4);
            ((IAction<Students>)st).Show();
            ((IAction<Students>)st).Del(st3);


            var linq1 = from s in ExamCard<Students>.list
                        where s.mark >= 4
                        select s;
            Console.WriteLine(linq1.Count());
            var linq2 = from s in ExamCard<Students>.list
                        select s.mark;
            Console.WriteLine(linq2.Average());

            st1.qwe();
            Console.WriteLine(st1);

        }

    }
}

