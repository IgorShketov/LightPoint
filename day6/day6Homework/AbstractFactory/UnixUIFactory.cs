using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class UnixUIFactory : UIFactory
    {
        public override Button CreateButton()
        {
            return new UnixButton();
        }

        public override TextBox CreateTextBox()
        {
            return new UnixTextBox();
        }
    }
}
