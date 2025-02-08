using laba9;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba9
{
    public class Collection : IEnumerable
    {
        private GeometricFigure[] _figures;

        public Collection(GeometricFigure[] figureArray)
        {
            _figures = new GeometricFigure[figureArray.Length];
            for (int i = 0; i < figureArray.Length; i++)
            {
                _figures[i] = figureArray[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() //IEnumerable имеет метод, возвращающий ссылку на другой интерфейс - перечислитель
        {
            return (IEnumerator)GetEnumerator();
        }
        public FigureEnum GetEnumerator()
        {
            return new FigureEnum(_figures);
        }
        public void Delete()
        {
            _figures = Array.Empty<GeometricFigure>();
            Console.WriteLine("\n\n\t--- Коллекция удалена!");
        }
        public void Find(int length, int width)
        {
            bool findValue = false;
            foreach (GeometricFigure item in _figures)
            {
                if (item.Length == length && item.Width == width)
                {
                    Console.WriteLine("\n\n\t--- Фигура найдена!");
                    findValue = true;
                }
            }
            if (findValue == false)
            {
                Console.WriteLine("\n\n\t--- В данной коллекции не существует такой фигуры!");
            }

        }
    }
}

public class FigureEnum : IEnumerator
{
    public GeometricFigure[] _figures;
    int position = -1;

    public FigureEnum(GeometricFigure[] figures)
    {
        _figures = figures;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _figures.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }
    public GeometricFigure Current
    {
        get
        {
            try
            {
                return _figures[position];
            }
            catch (IndexOutOfRangeException)
            {

                throw new InvalidCastException();
            }
        }
    }

}
