using System;

namespace exam
{
    public enum State { check, uncheck}
    public class Button
    {
        private string caption;
        private StartPoint startPoint;
        private double width;
        private double height;

        public string Caption { get { return caption; } set { caption = value; } }
        public StartPoint StartPoint { get { return startPoint; } set { startPoint = value;} }
        public double Width { get { return width; } set { width = value; } }
        public double Height { get { return height; } set { height = value; } }

        public override string ToString()
        {
            return $"{caption} {startPoint} {width} {height}";
        }

        public override bool Equals(Button obj)
        {
            if (obj.caption ==  butt.caption){

            }
        }
    }

    public class CheckButton : Button
    {
        private State state;
    }
    public class Program
    {
        public static void Main(string[] args)
        {

        }
    }

    public class StartPoint
    {
        private double x;
        private double y;

        StartPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
    }
}
