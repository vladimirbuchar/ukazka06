using Core.Extension;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.HttpClient
{
    public class HttpClientIntegration : IHttpClientIntegration
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public HttpClientIntegration()
        {
            _httpClient = new System.Net.Http.HttpClient();
        }

        public async Task<HttpResponseMessage> SendPostAsync(string url, string userAccessToken, Dictionary<string, string> data)
        {
            data ??= [];
            if (!userAccessToken.IsNullOrEmptyWithTrim())
            {
                data.Add("UserAccessToken", userAccessToken);
            }
            HttpResponseMessage response = await _httpClient.PostAsync(
                url,
                new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
            );
            return response;
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            return response;
        }
    }
}
