using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class UIFactory
    {
        public abstract Button CreateButton();
        public abstract TextBox CreateTextBox();
    }
}
