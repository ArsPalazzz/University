namespace dada
{
    class Program
    {
        public class Point
        {
            public int x = 10;
            public int y = 20;
            public int Sum() { return x + y; }
            public String ToString()
            { return "Point " + x + " " + y; }
        }
        public class ColorPoint : Point
        {
            public new int x = -78;
            new public String ToString()
            { return "ColorPoint " + x + base.ToString(); }
            new public int Sum()
            { return base.x + base.y + x; }
        }


        private static void Main(string[] args)
        {
            ColorPoint ca100 = new ColorPoint();
            Console.WriteLine(ca100.Sum());//30
                                           // вызов методов по типу ссылки
        }


    }

}
