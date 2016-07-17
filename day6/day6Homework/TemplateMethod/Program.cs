using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            RightTriangle rt = new RightTriangle();

            Console.Write(rt.TemplateOp(3, 4));

            Console.ReadKey();
        }
    }
}
