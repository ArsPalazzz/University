using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba123
{
    [Serializable]
    public class Rectangle : GeometricShape, IControl     // родственный класс
    {
        [NonSerialized]
        public readonly string strForNonSerialization = "strStr";
        public int Border { get; set; }
        public int Square { get; set; }
        public int Perimeter { get; set; }
        public int Width { get; set; }
        public int RectLenght { get; set; }
        public Rectangle(int square, int perimeter, int border) : base(square, perimeter)
        {
            Border = border;
        }
        public Rectangle()
        {

        }

        void IControl.input()
        {
            Console.WriteLine("\nВведите ширину прямоугольника: ");
            Width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину прямоугольника: ");
            RectLenght = Convert.ToInt32(Console.ReadLine());
        }
        void IControl.resize()
        {
            Console.WriteLine("Введите новое значение ширины обводки: ");
            Border = Convert.ToInt32(Console.ReadLine());
        }
        void IControl.show()
        {
            SquareValue = Width * RectLenght;
            Perimeter = (Width + RectLenght) * 2;
            Console.WriteLine("Площадь прямоугольника: " + SquareValue + "px^2, его периметр: " + Perimeter + "px, " +
                "ширина обводки: " + Border + "px, ширина стороны: " + Width + "px");
        }
        public override string ToString()
        {
            return "Площадь прямоугольника:" + SquareValue + ". Периметр: " + Perimeter;
        }
    }
}
