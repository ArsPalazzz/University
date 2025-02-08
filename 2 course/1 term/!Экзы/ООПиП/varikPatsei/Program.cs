using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace exam
{
    internal interface IFigure
    {
        public virtual void Print() { }

    }
    [Serializable]
    internal class Rectangle : IFigure
    {
        [NonSerialized]
        private int x;
        [NonSerialized]
        private int y;
        private double h;
        private double l;
        private string color;

        public int X { get; set; }
        public int Y { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public string Color { get; set; }

        public Rectangle() { 
        
        }

        public Rectangle(int x, int y, double h)
        {
            this.X = x;
            this.Y = y;
            this.H = h;
        }

        public Rectangle(int x, int y, double h, double l, string color) : this(x, y, h)
        {
            this.L = l;
            this.Color = color;
        }

        public void Print()
        {
            Console.WriteLine($"x = {X}\ny = {Y}\nh = {H}\nl = {L}\ncolor = {Color}\n");
        }

        public override string ToString()
        {
            return $"x = {X}\ny = {Y}\nh = {H}\nl = {L}\ncolor = {Color}\n";
        }

        public static Rectangle operator +(Rectangle r1, Rectangle r2)
        {
            return new Rectangle(r1.X + r2.X, r1.Y + r2.Y, 0);
        }

        public double Square()
        {
            return this.H * this.L;
        }


    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("zad1");
            Rectangle rect1 = new Rectangle(10,10,7.4,5.4, "blue");
            Console.WriteLine("print");
            rect1.Print();

            Console.WriteLine("zad2");
            Console.WriteLine("toString");
            Console.WriteLine(rect1.ToString());
            Rectangle rect2 = new Rectangle(20, 20, 15.1, 14.9, "red");
            rect2.Print();
            Rectangle rect3 = rect1 + rect2;
            rect3.Print();
            double square1 = rect1.Square();
            Console.WriteLine($"Ploschad rect1 = {square1}\n");

            Console.WriteLine("zad3");
            List<Rectangle> rectList = new List<Rectangle>();
            rectList.Add(new Rectangle(1, 1, 1, 1, "red"));
            rectList.Add(new Rectangle(2, 2, 2, 2, "orange"));
            rectList.Add(new Rectangle(3, 3, 3, 3, "yellow"));
            rectList.Add(new Rectangle(4, 4, 4, 4, "green"));
            rectList.Add(new Rectangle(5, 5, 5, 5, "blue"));
            rectList.Add(new Rectangle(6, 6, 6, 6, "purple"));
            Rectangle rectPlus = rectList[0] + rectList[1];
            Console.WriteLine($"rectPlus = {rectPlus}");
            foreach (var x in rectList)
            {
                x.Print();
            }

            Console.WriteLine("zad4");
            //var ordered = rectList.OrderBy(t => t.X).ThenBy(t => t.Y).ThenBy(t => t.Square());
            //Console.WriteLine($"sort by X: {ordered}");
            IEnumerable<Rectangle> sortedX = rectList.OrderBy(n => n.X);
            Console.WriteLine($"sort by X: {sortedX}");
            IEnumerable<Rectangle> sortedY = rectList.OrderBy(n => n.Y);
            Console.WriteLine($"sort by Y: {sortedY}");
            IEnumerable<Rectangle> sortedSquare = rectList.OrderBy(n => n.Square());
            Console.WriteLine($"sort by Y: {sortedSquare}");
            var firstObj = rectList.First();
            Console.WriteLine($"first object: {firstObj}");
            var lastObj = rectList.Last();
            Console.WriteLine($"last object: {lastObj}");

            Console.WriteLine("zad5");
            var jsonListFormatter = new DataContractJsonSerializer(typeof(List<Rectangle>));

            using (var file = new FileStream("JsonList.json", FileMode.OpenOrCreate))
            {
                jsonListFormatter.WriteObject(file, rectList);
            }

            using (var file = new FileStream("JsonList.json", FileMode.OpenOrCreate))
            {
                List <Rectangle> newList = jsonListFormatter.ReadObject(file) as List<Rectangle>;
                if (newList != null)
                {
          
                    foreach (Rectangle rect in newList)
                    {
                        rect.Print();
                       
                    }
                }
            }
        }
    }
}

