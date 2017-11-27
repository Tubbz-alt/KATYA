using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mime;
using System.IO;
using System.Net.Mail;

namespace KATYA
{
    public partial class KATYAWebRequest
    {
        private string URL { get; set; }
        private Dictionary<string,string> RequestParameters { get; set; }
        private Dictionary<string,object> RequestObjects { get; set; }
        public KATYAWebRequest()
        {
            this.RequestParameters = new Dictionary<string, string>();
        }
        public KATYAWebRequest(string URL)
        {
            this.URL = URL;
            this.RequestParameters = new Dictionary<string, string>();
        }
        public StatusObject Get()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_GET");
            }
            return SO;
        }
        public async Task<StatusObject> GetAsync()
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
        public StatusObject BulkGet()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_BULKGET");
            }
            return SO;
        }
        public async Task<StatusObject> BulkGetAsync()
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
        public StatusObject Post()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_POST");
            }
            return SO;
        }
        public async Task<StatusObject> PostAsync()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject BulkPost()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_BULKPOST");
            }
            return SO;
        }
        public async Task<StatusObject> BulkPostAsync()
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject AddRequestParameters(string Key, string Value)
        {
            StatusObject SO = new StatusObject();
            try
            {
                RequestParameters.Add(Key, Value);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_ADDREQUESTPARAMETERS");
            }
            return SO;
        }
        public StatusObject AddRequestObjects(string Key, string Value)
        {
            StatusObject SO = new StatusObject();
            return SO;
        }
        public StatusObject DownloadHeaderFiles(string URL)
        {
            StatusObject SO = new StatusObject();
            try
            {
                WebClient Client = new WebClient();
                Client.OpenRead(URL);
                string TargetContentDisposition = Client.ResponseHeaders["content-disposition"];
                string DownloadedFileName = new ContentDisposition(TargetContentDisposition).FileName;
                ContentDisposition DownloadedFile = new ContentDisposition(TargetContentDisposition);
                
                Console.WriteLine("{0} {1}", DownloadedFileName, DownloadedFile.Size, DownloadedFile.GetType());
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_DOWNLOADFILE");
            }
            return SO;
        }
        public async Task<StatusObject> DownloadHeaderFilesAsync()
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUEST_DOWNLOADFILEASYNC");
            }
            return SO;
        }
    }
}
