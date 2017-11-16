using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATYA
{
    public partial class KATYAWeb
    {
        public string URL { get; set; }
        public KATYAWeb()
        {

        }
        public KATYAWeb(string URL)
        {
            this.URL = URL;
        }
        public StatusObject HTTPGet()
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
        public StatusObject HTTPPost()
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
