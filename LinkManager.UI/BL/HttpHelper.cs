using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace LinkManager.UI.BL
{
    public class HttpHelper
    {
        public static async Task<T> Get<T>(string url)
        {
            using (var httpHandler = new HttpClientHandler())
            {
                httpHandler.Credentials = new NetworkCredential("somelogin", "somepassword");
                using (var httpClient = new HttpClient(httpHandler))
                {
                    var response = await httpClient.GetAsync(url);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Some error: " + responseContent);
                    }

                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
            }
        }

        public static async Task<T> Post<T, U>(string url, U body)
        {
            using (var httpClient = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(body);
                var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));

                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Some error: " + responseContent);
                }

                return JsonConvert.DeserializeObject<T>(responseContent);
            }
        }
    }
}