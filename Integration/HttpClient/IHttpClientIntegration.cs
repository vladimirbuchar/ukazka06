using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.HttpClient
{
    public interface IHttpClientIntegration
    {
        Task<HttpResponseMessage> SendPostAsync(string url, string userAccessToken, Dictionary<string, string> data);
        Task<HttpResponseMessage> Get(string url);
    }
}
