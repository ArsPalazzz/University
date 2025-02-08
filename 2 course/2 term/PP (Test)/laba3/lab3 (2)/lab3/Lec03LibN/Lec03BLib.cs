using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLib
{
    public static partial class Lec03BLib //уровни вознагражд
    {
        // общий интерфейс, который содержит методы создания всех продуктов семейства
        static public IFactory GetL1() //1 ур-нь
        {
            return new Bonus1();
        }
        static public IFactory GetL2(float a ) //2 ур-нь (велич сниж/повыш отработ часов)
        {
            return new Bonus2(a);
        }
        static public IFactory GetL3(float a, float b )//3 ур-нь (велич сниж/повыш отработ часов, величина сниж/пов стоимости 1 часа)
        {
            return new Bonus3(a, b);
        }
    }
}
