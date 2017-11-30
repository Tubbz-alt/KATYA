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
        private Dictionary<string,string> UrlEncodedStringEscapeCharacters { get; set; }
        public KATYAWebRequest()
        {
            this.RequestParameters = new Dictionary<string, string>();
            this.UrlEncodedStringEscapeCharacters = new Dictionary<string, string>();
        }
        public KATYAWebRequest(string URL)
        {
            this.URL = URL;
            this.RequestParameters = new Dictionary<string, string>();
            this.UrlEncodedStringEscapeCharacters = new Dictionary<string, string>();
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
                URLEncodedString = new FormUrlEncodedContent(this.RequestParameters).ReadAsStringAsync().Result;
            }
            catch(Exception e)
            {
                URLEncodedString = "";
            }
            return URLEncodedString;
        }
        public StatusObject Post(bool AllowAutoRedirect)
        {
            StatusObject SO = new StatusObject();
            try
            {
                HttpWebRequest TargetSiteHttp = (HttpWebRequest)WebRequest.Create(this.URL);
                TargetSiteHttp.AllowAutoRedirect = AllowAutoRedirect;
                TargetSiteHttp.UserAgent = "helloasd";
                string PostData = GetURLEncodedString();
                byte[] PostDataBytes = Encoding.ASCII.GetBytes(PostData);
                TargetSiteHttp.Method = "POST";
                TargetSiteHttp.ContentType = "application/x-www-form-urlencoded";
                TargetSiteHttp.ContentLength = PostDataBytes.Length;
                TargetSiteHttp.GetRequestStream().Write(PostDataBytes, 0, PostDataBytes.Length);
                HttpWebResponse TargetSiteResponse = (HttpWebResponse)TargetSiteHttp.GetResponse();
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
            try
            {
                HttpClient Client = new HttpClient();
                FormUrlEncodedContent PostContent = new FormUrlEncodedContent(this.RequestParameters);
                var Response = await Client.PostAsync(this.URL, PostContent);
                Console.WriteLine(Response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

            }
            return SO;
        }
        public StatusObject AddRequestParameters(string Key, string Value)
        {
            StatusObject SO = new StatusObject();
            try
            {
                RequestParameters.Add(Key.Trim(), Value.Trim());
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
