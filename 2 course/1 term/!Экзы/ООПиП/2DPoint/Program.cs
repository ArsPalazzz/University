using System;
using System.Reflection;


namespace exam
{
    public class TwoDPoint
    {
        delegate void ChangeDelegate(string message);
        event ChangeDelegate Change;
        public int x;
        public int y;
        public int X { 
            get { 
                return x; 
            } 
            set {
                Change?.Invoke($"Знак изменен");   // 2.Вызов события 
                x = -value;
            } 
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                Change?.Invoke($"Знак изменен");   // 2.Вызов события 
                y = -value;
            }
        }

        public TwoDPoint()
        {

        }

        public TwoDPoint(int x, int y)
        {
            Change?.Invoke($"Знак изменен");   // 2.Вызов события 
            this.x = -x;
            Change?.Invoke($"Знак изменен");   // 2.Вызов события 
            this.y = -y;
        }

        public override string ToString()
        {
            return $"x = {this.x}  y = {this.y}";
        }
    }

    public class TwoDPath
    {
        List<TwoDPoint> points = new List<TwoDPoint>();

        public void Adder(TwoDPoint value)
        {
            points.Add(value);
        }
        public void Remover(TwoDPoint value)
        {
            if (points.Count == 0)
            {
                throw new DeleteException();
            }
            else
            {
                points.Remove(value);
            }
           
        }
        public void ClearPoints()
        {
            points.Clear();
        }

        public void Show()
        {
            foreach (var point in points)
            {
                Console.WriteLine(point);
            }
        }

        //public static bool operator ==(TwoDPoint obj1, TwoDPoint obj2)
        //{
        //    if (obj1.X == obj2.X && obj1.Y == obj2.Y)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }


        //}

        public override bool Equals(object? obj)
        {
            if (obj is TwoDPath path) return true;
            return false;
        }

        public (int,int,int,int) CountPoints()
        {
            int firstPart = 0;
            int secondPart = 0;
            int thirdPart = 0;
            int fourthPart = 0;

            foreach (var point in points)
            {
                if (point.x > 0 && point.y > 0)
                {
                    ++firstPart;
                }
                if (point.x < 0 && point.y > 0)
                {
                    ++secondPart;
                }
                if (point.x < 0 && point.y < 0)
                {
                    ++thirdPart;
                }
                if (point.x > 0 && point.y < 0)
                {
                    ++fourthPart;
                }
            }

            Console.WriteLine($"Первая четверть: {firstPart}");
            Console.WriteLine($"Вторая четверть: {secondPart}");
            Console.WriteLine($"Третья четверть: {thirdPart}");
            Console.WriteLine($"Четвертая четверть: {fourthPart}");

            return (firstPart, secondPart, thirdPart, fourthPart);
        }


        //public static TwoDPath operator !=(TwoDPath obj1, TwoDPath obj2)
        //{

        //}
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TwoDPath path = new TwoDPath();
            TwoDPath path2 = new TwoDPath();

            TwoDPoint point1 = new TwoDPoint(10,15);
            TwoDPoint point2 = new TwoDPoint(90, 17);
            TwoDPoint point3 = new TwoDPoint(70, 2);
            TwoDPoint point4 = new TwoDPoint(46, 65);
            TwoDPoint point5 = new TwoDPoint(12, 34);

            path.Adder(point1);
            path.Adder(point2);
            path.Adder(point3);
            path.Adder(point4);
            path.Adder(point5);

            path.Show();

            path.Remover(point2);
            path.Show();

            bool eq = path.Equals(path2 as TwoDPath);
            Console.WriteLine(eq);

            var tuple = path.CountPoints();
            Console.WriteLine(tuple);

            path.Remover(point1);
            path.Remover(point2);
            path.Remover(point3);
            path.Remover(point4);

            path.Show();

            Type type = typeof(TwoDPoint);
            foreach (var con in type.GetConstructors())
            {
                Console.WriteLine($"Constructor = {con.Name}");
            }
        
            foreach(var fi in type.GetFields())
            {
                Console.WriteLine($"Field = {fi.Name}");
            }
           




        }
    }

    public class DeleteException : Exception
    {
        public DeleteException() : base("Delete Exception") { }
    }
}
