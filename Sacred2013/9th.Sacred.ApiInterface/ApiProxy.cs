using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace _9th.Sacred.ApiInterface
{
    public class ApiProxy
    {
        public string APIURL { get; set; }

        public ApiProxy(string inAPIURL)
        {
            APIURL = inAPIURL;
        }

        protected string GetUrl(ApiRequest request)
        {
            var apiCallUrl = new UriBuilder(APIURL);
            apiCallUrl.Path += "api/" + request.ApiResource;

            var finalParameters = new Dictionary<string, string>();

            if (request.Parameters != null)
            {
                foreach (var parameter in request.Parameters)
                {
                    finalParameters.Add(parameter.Key, parameter.Value.ToString());
                }
            }

            apiCallUrl.Query = string.Join(
                "&",
                (from parameter in finalParameters select (parameter.Key + "=" + HttpUtility.UrlEncode(parameter.Value))).ToArray()
            );

            return apiCallUrl.ToString();
        }

        public string GetResponseString(ApiRequest request)
        {
            string retval;
            string url = GetUrl(request);

            HttpWebRequest httprequest = WebRequest.Create(url) as HttpWebRequest;

            using (HttpWebResponse response = httprequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                retval = reader.ReadToEnd();
            }

            return retval;
        }

        public T GetResponse<T>(ApiRequest request)
        {
            string response = GetResponseString(request);
            T retval = JsonConvert.DeserializeObject<T>(response);
            return retval;
        }

        public string PostRequestString(ApiRequest request)
        {
            string retval;
            string url = GetUrl(request);

            var httprequest = WebRequest.Create(url) as HttpWebRequest;
            httprequest.Method = "POST";
            httprequest.ServicePoint.Expect100Continue = false; //IMPORTANT

            AddContentToHttpRequest(httprequest, request.Content);

            using (HttpWebResponse response = httprequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                retval = reader.ReadToEnd();
            }

            return retval;
        }

        public T PostRequest<T>(ApiRequest request)
        {
            string response = PostRequestString(request);
            T retval = JsonConvert.DeserializeObject<T>(response);
            return retval;
        }

        protected void AddContentToHttpRequest(HttpWebRequest request, object content)
        {
            if (content != null)
            {
                Stream requestStream = request.GetRequestStream();

                var encoding = new UTF8Encoding();

                request.ContentType = "application/json";
                request.Headers.Add("Content-Encoding", encoding.HeaderName);

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.DefaultValueHandling = DefaultValueHandling.Ignore;

                string sobj = JsonConvert.SerializeObject(content, settings);

                var bytes = encoding.GetBytes(sobj);
                requestStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
