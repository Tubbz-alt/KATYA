using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public partial class KATYAFile
    {
        public StatusObject ReadAllText()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_READALLTEXT");
            }
            return SO;
        }
        public StatusObject ReadTextByLine()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_READTEXTBYLINE");
            }
            return SO;
        }
        public StatusObject ProcessTextByLine()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_PROCESSTEXTBYLINE");
            }
            return SO;
        }

        public StatusObject WriteToTextFile()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject ProcessAllText()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "FILE_PROCESSALLTEXT");
            }
            return SO;
        }
    }
}
