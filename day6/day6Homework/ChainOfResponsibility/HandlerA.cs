using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class HandlerA : Handler
    {
        private Handler _successor;
        public void SetSuccessor(Handler successor)
        {
            _successor = successor;
        }

        public override void Handle(int request)
        {
            if(request == 1)
            {
                Console.WriteLine("Handler {0} handled request # {1}", this.GetType().Name, request);
            }
            else
            {
                _successor.Handle(request);
            }
        }
    }
}
