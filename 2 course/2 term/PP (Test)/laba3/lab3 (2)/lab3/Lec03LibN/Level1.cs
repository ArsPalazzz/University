using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLib
{
    internal class L1A : IBonus
    {
        public L1A() { }
        public L1A(float cost1Hour)
        {
            this.Cost1Hour = cost1Hour;
        }
        public float Cost1Hour { get; set; } = 0;

        public float Calc(float numberHours)
        {
            return (float)(numberHours * Cost1Hour);
        }
    }

    internal class L1B : IBonus
    {
        public L1B() { }
        public L1B(float cost1Hour, float x)
        {
            this.Cost1Hour = cost1Hour;
            this.X = x;
        }
        public float X { get; set; } = 0;
        public float Cost1Hour { get; set; } = 0;

        public float Calc(float numberHours)
        {
            return (float)(numberHours * Cost1Hour * X);
        }
    }

    internal class L1C : IBonus
    {
        public L1C(float cost1Hour, float x, float y)
        {
            this.Cost1Hour = cost1Hour;
            this.X = x;
            this.Y = y;
        }
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float Cost1Hour { get; set; } = 0;

        public float Calc(float numberHours)
        {
            return (float)(numberHours * Cost1Hour * X + Y);
        }
    }
}