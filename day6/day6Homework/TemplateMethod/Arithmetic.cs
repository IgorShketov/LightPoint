using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public abstract class Arithmetic
    {
        public abstract double Op1(double val1, double val2);
        public abstract double Op2(double val1, double val2);
        public abstract double Op3(double val);
        public double TemplateOp(double val1, double val2)
        {
            double res1 = Op1(val1, val1);
            double res2 = Op1(val2, val2);
            double res3 = Op2(res1, res2);

            return Op3(res3);
        }
    }
}
