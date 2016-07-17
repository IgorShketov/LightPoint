using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class WindowsUIFactory : UIFactory
    {
        public override Button CreateButton()
        {
            return new WindowsButton();
        }

        public override TextBox CreateTextBox()
        {
            return new WindowsTextBox();
        }
    }
}
