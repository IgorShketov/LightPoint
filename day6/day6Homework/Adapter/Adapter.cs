using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Adapter : Target
    {
        private Adaptee adaptee;

        public Adapter()
        {
            adaptee = new Adaptee();
        }

        public override void WriteName(string fullName)
        {
            string[] name = fullName.Split(' ');
            adaptee.WriteName(name[0], name[1]);
        }
    }
}
