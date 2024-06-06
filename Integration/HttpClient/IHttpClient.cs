using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Integration.HttpClient
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendPostAsync(string url, string userAccessToken, Dictionary<string, string> data);
        Task<HttpResponseMessage> ExternalGetAsync(string url);
    }
}
