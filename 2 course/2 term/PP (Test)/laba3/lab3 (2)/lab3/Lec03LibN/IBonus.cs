using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLib
{
    public interface IBonus //вознаграждение
    {
        float Cost1Hour { get; set; } //стоимость 1 часа
        float Calc(float numberHours);//вычисление вознаграждения(кол во отработанных часов)
    }
}