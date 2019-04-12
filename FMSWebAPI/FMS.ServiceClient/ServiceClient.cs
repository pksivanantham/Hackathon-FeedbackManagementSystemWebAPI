using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FMS.ServiceClient
{
    public class ServiceClient
    {
        readonly HttpClient httpClient = new HttpClient();

        private string _url = string.Empty;
        public ServiceClient(string url)
        {
            this._url = url;
            httpClient.BaseAddress = new Uri(url);


        }
        private async Task<T> GetRequest<T>(string url)
        {
            //httpClient.DefaultRequestHeaders.Accept.Clear();

            var response = await httpClient.GetAsync(url).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            T result = default(T);

            await response.Content.ReadAsStringAsync().ContinueWith((x) => {

                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);

            });

            return result;
        }
        private async Task<T> PostRequest<T>(string url, object data)
        {            

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);

            MediaTypeFormatter[] mediaTypeFormatter = new MediaTypeFormatter[] { new JsonMediaTypeFormatter() };

            httpRequestMessage.Content = CreateHttpContent(data);
            //var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            //content.Headers.ContentType =new MediaTypeHeaderValue("application/json");
           var response = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);

           response.EnsureSuccessStatusCode();

            T result = default(T);

            await response.Content.ReadAsStringAsync().ContinueWith((x) => {

                if (x.IsFaulted)
                    throw x.Exception;

                result = JsonConvert.DeserializeObject<T>(x.Result);

            });                
           
            return result;
        }
        private static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }
        private static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public async Task<int> SaveFileInformation(FileProcessRequest data)
        {

           return await PostRequest<int>("api/FileProcess/SaveFileInformation", data);
            
        }

        public async Task<string[]> SaveFileInformation()
        {

            return await PostRequest<string[]>("api/FileProcess/TEST", "");

        }




    }
}
