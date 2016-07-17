using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class EnglishSpeaker : Speaker
    {
        public override void SayHi()
        {
            Console.WriteLine("Good morning!");
        }
    }
}
