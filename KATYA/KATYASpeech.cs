using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
namespace KATYA
{
    public partial class KATYASpeech
    {
        public KATYASpeech()
        {

        }
        public StatusObject Speak(string Dialog)
        {
            StatusObject SO = new StatusObject();
            try
            {
                SpeechSynthesizer Synthesizer = new SpeechSynthesizer();
                Synthesizer.Volume = 100;
                Synthesizer.Rate = -2;
                Synthesizer.Speak(Dialog);

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject Listen()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject ProcessInstruction()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject RecordToTextFile()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject RecordInstruction()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
    }
}
