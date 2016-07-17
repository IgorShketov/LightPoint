using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class HandlerC : Handler
    {
        private Handler _successor;

        public override void Handle(int request)
        {
            if (request > 2)
            {
                Console.WriteLine("Handler {0} handled request # {1} by default", this.GetType().Name, request);
            }
        }
    }
}
