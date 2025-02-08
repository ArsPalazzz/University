using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace lab13
{
    [DataContract]
    public class Square : GeometricShape, IControl    // родственный класс
    {
        public string Color { get; set; }
        public int SideLength { get; set; }
        Rectangle rectangle;   
        public Square(int square, int perimeter, string color) : base(square, perimeter)    // base() здесь - родственный класс. Обозначает, что параметры int square и int perimeter наследуются из базового класса
        {
            Color = color;
        }
        public Square() // композиция класса
        {
            rectangle = new Rectangle(12, 12, 12);
        }

        void IControl.input()        // переопределение методов интерфейса
        {
            Console.WriteLine("Введите длину стороны квадрата: ");
            SideLength = Convert.ToInt32(Console.ReadLine());
        }
        void IControl.resize()
        {
            Console.WriteLine("Введите новое значение цвета фигуры: ");
            Color = Console.ReadLine();
        }
        void IControl.show()
        {
            SquareValue = SideLength * SideLength;
            Perimeter = SideLength * 4;
            Console.WriteLine("Площадь квадрата: " + SquareValue + "px^2, его периметр: " + Perimeter + "px, " +
                "цвет: " + Color + ", новая длина стороны: " + SideLength);
        }
        public override bool Equals(object obj)
        {
            if ((string)obj == "green")
                return true;
            else return false;
        }
        public sealed override int GetHashCode()
        {
            Random rnd = new Random();
            int rand = rnd.Next(1, 131);
            return rand;
        }
        public override string ToString()       // переопределние метода ToString()
        {
            return "Площадь квадрата:" + SquareValue + ". Периметр: " + Perimeter;
        }
    }
}
