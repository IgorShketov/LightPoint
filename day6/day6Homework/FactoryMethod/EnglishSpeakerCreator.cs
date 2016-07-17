using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class EnglishSpeakerCreator : Creator
    {
        public override Speaker CreateSpeaker()
        {
            return new EnglishSpeaker();
        }
    }
}
