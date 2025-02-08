using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLib
{
    internal class L2A : IBonus
    {
        public L2A(float cost1Hour, float a)
        {
            this.Cost1Hour = cost1Hour;
            this.a = a;
        }
        public float a = 0.0f;
        public float Cost1Hour { get; set; } = 0;

        public float Calc(float numberHours)
        {
            return (float)((numberHours + a) * Cost1Hour);
        }
    }

    internal class L2B : IBonus
    {
        public L2B(float cost1Hour, float x, float a)
        {
            this.Cost1Hour = cost1Hour;
            this.a = a;
            this.X = x;
        }
        public float a = 0.0f;
        public float X { get; set; } = 1;
        public float Cost1Hour { get; set; } = 0;

        public float Calc(float numberHours)
        {
            return (float)((numberHours + a) * Cost1Hour * X);
        }
    }

    public class L2C : IBonus
    {
        public L2C(float cost1Hour, float x, float y, float a)
        {
            this.Cost1Hour = cost1Hour;
            this.a = a;
            this.X = x;
            this.Y = y;
        }
        public float a = 0.0f;
        public float X { get; set; } = 1;
        public float Y { get; set; } = 0;
        public float Cost1Hour { get; set; } = 0;

        public float Calc(float numberHours)
        {
            return (float)((numberHours + a) * Cost1Hour * X + Y);
        }
    }
}