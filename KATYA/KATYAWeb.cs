using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace KATYA
{
    public partial class KATYAWeb
    {
        public string URL { get; set; }
        public Dictionary<string,string> PostParameters { get; set; }
        public KATYAWeb()
        {
            this.PostParameters = new Dictionary<string, string>();
        }
        public KATYAWeb(string URL)
        {
            this.URL = URL;
            this.PostParameters = new Dictionary<string, string>();
        }
        public StatusObject HTTPGet()
        {
            StatusObject SO = new StatusObject();
            try
            {
                WebRequest TargetSite = WebRequest.Create(URL);
                Stream RequestContent = TargetSite.GetResponse().GetResponseStream();
                StreamReader RequestContentReader = new StreamReader(RequestContent);
                Console.WriteLine(RequestContentReader.ReadToEnd());
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEB_HTTPGET");
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
        public StatusObject AddPostParameters(string Key, string Value)
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.PostParameters.Add(Key, Value);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEB_ADDPOSTPARAMETERS");
            }
            return SO;
        }
    }
}
