using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03BLib
{
    internal class L3A : IBonus
    {
        public L3A(float cost1Hour, float a, float b)
        {
            this.a = a;
            this.b = b;
            this.Cost1Hour = cost1Hour;
        }
        float a = 0.0f;
        float b = 0.0f;
        public float Cost1Hour { get; set; }

        public float Calc(float numberHours)
        {
            return (float)((numberHours + a) * (Cost1Hour + b));
        }
    }

    internal class L3B : IBonus
    {
        public L3B(float cost1Hour, float x, float a, float b)
        {
            this.a = a;
            this.b = b;
            this.Cost1Hour = cost1Hour;
            this.x = x;
        }
        float a = 0.0f;
        float b = 0.0f;
        public float x { get; set; } = 1;
        public float Cost1Hour { get; set; }

        public float Calc(float numberHours)
        {
            return (float)((numberHours + a) * (Cost1Hour + b) * x);
        }
    }

    internal class L3C : IBonus
    {
        public L3C(float cost1Hour, float x, float y, float a, float b)
        {
            this.a = a;
            this.b = b;
            this.Cost1Hour = cost1Hour;
            this.x = x;
            this.y = y;
        }
        float a = 0.0f;
        float b = 0.0f;
        public float x { get; set; } = 1;
        public float y { get; set; } = 0;
        public float Cost1Hour { get; set; }

        public float Calc(float numberHours)
        {
            return (float)((numberHours + a) * (Cost1Hour + b) * x + y);
        }
    }
}