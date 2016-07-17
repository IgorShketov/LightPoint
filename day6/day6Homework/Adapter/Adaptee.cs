using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Adaptee
    {
        public void WriteName(string firstName, string secondName)
        {
            Console.WriteLine("Name: {0} {1}", firstName, secondName);
        }
    }
}
