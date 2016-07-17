using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class GermanSpeakerCreator : Creator
    {
        public override Speaker CreateSpeaker()
        {
            return new GermanSpeaker();
        }
    }
}
