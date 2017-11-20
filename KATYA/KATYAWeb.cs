﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
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
        public string GetURLEncodedString()
        {
            string URLEncodedString = "";
            try
            {
                URLEncodedString = String.Join("&", PostParameters.Select(x => String.Format("{0}={1}", x.Key, x.Value)));
            }
            catch(Exception e)
            {
                URLEncodedString = "";
            }
            return URLEncodedString;
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
        /// <summary>
        /// Function that posts using a HttpClient
        /// </summary>
        /// <returns></returns>
        public async Task<StatusObject> HTTPPostAsync()
        {
            StatusObject SO = new StatusObject();
            try
            {
                HttpClient Client = new HttpClient();
                FormUrlEncodedContent PostParameters = new FormUrlEncodedContent(this.PostParameters);
                var Response = await Client.PostAsync(URL, PostParameters);
                var ResponseContent = await Response.Content.ReadAsStringAsync();
                Client.Dispose();
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEB_HTTPPOSTASYNC");
            }
            return SO;
        }
        /// <summary>
        /// A function that posts the traditional way
        /// </summary>
        /// <returns></returns>
        public StatusObject HTTPPost()
        {
            StatusObject SO = new StatusObject();
            try
            {
                WebRequest Request = WebRequest.Create(URL);
                string PostData = GetURLEncodedString();
                byte[] PostDataArray = Encoding.ASCII.GetBytes(PostData);
                Request.Method = "POST";
                Request.ContentType = "application/x-www-form-urlencoded";
                Request.ContentLength = PostDataArray.Length;
                Stream RequestStream = Request.GetRequestStream();
                RequestStream.Write(PostDataArray, 0, PostDataArray.Length);
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                string ResponseString = new StreamReader(Response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(ResponseString);
                Console.WriteLine(String.Join(";", Response.Headers.AllKeys));
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEB_HTTPPOST");
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
