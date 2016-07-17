using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class RightTriangle : Arithmetic
    {
        public override double Op1(double val1, double val2)
        {
            return val1 * val2;
        }

        public override double Op2(double val1, double val2)
        {
            return val1 + val2;
        }

        public override double Op3(double val)
        {
            return Math.Sqrt(val);
        }
    }
}
