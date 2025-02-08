using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace lab13
{
    [Serializable]
    public abstract class GeometricShape : IControl  // класс использует структуру интерфейса для его реализации
    {
        public int SquareValue { get; set; }
        public int Perimeter { get; set; }
        public int NumberOfValuableVariables { get; set; }
        public GeometricShape (int square, int perimeter)   // конструктор
        {
            SquareValue = square;
            Perimeter = perimeter;
        }
        public GeometricShape()
        {

        }
        void IControl.input()     // переопределение первого метода интерфейса
        {
            Console.WriteLine("Введите кол-во множителей в формуле площади фигуры: ");
            NumberOfValuableVariables = Convert.ToInt32(Console.ReadLine());
        }
        void IControl.resize()    // второго
        {
            Console.WriteLine("Введите новое значение периметра: ");
            Perimeter = Convert.ToInt32(Console.ReadLine());
        }
        void IControl.show()      // третьего
        {
            Console.WriteLine("Площадь фигуры: " + SquareValue + "px^2, а ее периметр: " + Perimeter + "px");
        }
    }
}
