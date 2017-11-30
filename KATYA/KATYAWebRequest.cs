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
using System.Net.Mail;
using System.Collections.Specialized;

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
                WebClient Client = new WebClient();
                Stream WebResponse = Client.OpenRead(this.URL);
                StreamReader WebResponseReader = new StreamReader(WebResponse);
                StreamWriter WebResponseWriter = new StreamWriter(@"hehehe.txt");
                string WebResponseText = WebResponseReader.ReadToEnd();
                WebResponseWriter.Write(WebResponseText);
                WebResponseWriter.Close();
                Console.WriteLine(WebResponseText);
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
        public string GetURLEncodedString()
        {
            string URLEncodedString = "";
            try
            {
                URLEncodedString = String.Join("&", RequestParameters.Select(x => String.Format("{0}={1}", x.Key, x.Value)));
            }
            catch(Exception e)
            {
                URLEncodedString = "";
            }
            return URLEncodedString;
        }
        public StatusObject Post()
        {
            StatusObject SO = new StatusObject();
            try
            {
                WebRequest TargetSite = WebRequest.Create(this.URL);
                string PostData = GetURLEncodedString();
                byte[] PostDataBytes = Encoding.ASCII.GetBytes(PostData);
                TargetSite.Method = "POST";
                TargetSite.ContentType = "application/x-www-form-urlencoded";
                TargetSite.ContentLength = PostDataBytes.Length;
                TargetSite.GetRequestStream().Write(PostDataBytes, 0, PostDataBytes.Length);
                WebResponse TargetSiteResponse = TargetSite.GetResponse();
                Stream TargetSiteResponseStream = TargetSiteResponse.GetResponseStream();
                StreamReader TargetSiteResponseStreamReader = new StreamReader(TargetSiteResponseStream);
                Console.WriteLine(TargetSiteResponseStreamReader.ReadToEnd());
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
        public StatusObject DownloadHeaderFiles()
        {
            StatusObject SO = new StatusObject();
            try
            {
                WebClient Client = new WebClient();
                Client.OpenRead(this.URL);
                string TargetContentDisposition = Client.ResponseHeaders["content-disposition"];
                string DownloadedFileName = new ContentDisposition(TargetContentDisposition).FileName;
                Console.WriteLine(Path.GetExtension(DownloadedFileName));
                ContentDisposition DownloadedFile = new ContentDisposition(TargetContentDisposition);
                File.WriteAllBytes(@"d:\test.exe", Client.DownloadData(this.URL));
                StringDictionary DownloadedFileParameters = DownloadedFile.Parameters;
                foreach(string Key in DownloadedFile.Parameters.Keys)
                {
                    Console.WriteLine(Key);
                }
                Console.WriteLine("{0} {1}", DownloadedFileName, DownloadedFile.Size);
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
