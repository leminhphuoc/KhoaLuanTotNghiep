using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace FonNature.Services
{
    public class HttpClientService : IHttpClientService
    {
        private void PrepareHeaders(HttpWebRequest req)
        {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            req.ContentType = "application/json";
            //req.Headers.Add(DefaultHeaders.SecretKey, _options.SecretKey);
            //req.Headers.Add(DefaultHeaders.LoyaltyProgram, _options.LoyaltyProgram);
        }

        public T Post<T>(string url, object body)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            PrepareHeaders(req);
            var stream = req.GetRequestStream();
            var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(body));
            stream.Write(bytes, 0, bytes.Length);

            return HandleResponse<T>(req);
        }

        public T Get<T>(string url, object body = null)
        {
            HttpWebRequest req;
            if (body == null)
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "GET";
                PrepareHeaders(req);
                return HandleResponse<T>(req);
            }

            req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            PrepareHeaders(req);

            return HandleResponse<T>(req);
        }

        public T Put<T>(string url, object body)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "PUT";
            PrepareHeaders(req);
            var stream = req.GetRequestStream();
            var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(body));
            stream.Write(bytes, 0, bytes.Length);

            return HandleResponse<T>(req);
        }

        public T HandleResponse<T>(HttpWebRequest req)
        {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            try
            {
                using (var res = (HttpWebResponse)req.GetResponse())
                {
                    using (var responseStream = res.GetResponseStream())
                    {
                        using (var myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            var responseJSON = myStreamReader.ReadToEnd();
                            var data = JsonConvert.DeserializeObject<T>(responseJSON);

                            return data;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return default(T);
            }
            catch (JsonSerializationException ex)
            {
                return default(T);
            }
        }
    }
}