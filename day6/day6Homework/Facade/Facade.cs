using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Facade
    {
        private HelloSpeaker helloSpeaker;
        private TimesSpeaker timeSpeaker;

        public Facade()
        {
            helloSpeaker = new HelloSpeaker();
            timeSpeaker = new TimesSpeaker();
        }

        public void sayGoodMorning()
        {
            helloSpeaker.SayEnglishGood();
            timeSpeaker.SayMorning();
        }

        public void sayGutenTag()
        {
            helloSpeaker.SayGermanGut();
            timeSpeaker.SayTag();
        }
    }
}
