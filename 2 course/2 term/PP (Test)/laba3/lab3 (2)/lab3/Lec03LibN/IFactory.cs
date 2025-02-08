using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLib
{
    public interface IFactory // типы вознаграждения
    {
        IBonus GetA(float cost1Hour); //Тип А стоим 1часа
        IBonus GetB(float cost1Hour, float x); //тип вознагр В ст 1 часа и повыш коэф
        IBonus GetC(float cost1Hour, float x, float y); // тип С стоим 1 часа + повыш коэф + величина снижения/повышения
    }
}