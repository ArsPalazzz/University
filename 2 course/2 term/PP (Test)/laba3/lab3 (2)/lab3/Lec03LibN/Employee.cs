using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLib
{
    public class Employee //сотрудник получающий вознаграждение
    {
        public IBonus Bonus { get; private set; } //вычисл вознагражд
                //промежуточная абстракция
        public Employee(IBonus bonus ) //Dependency Inversion Principle Принцип инверсии зависимостей
        {       
            this.Bonus = bonus;
        }
        public float CalcBonus(float numberHours) //вычисл вознагражд
        {
            return Bonus.Calc(numberHours); //вызов внедренного алгоритма
        }
       
    }
}