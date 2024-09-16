using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Base.MicroService
{
    public interface ICallMicroService
    {
        string BaseUrl { get; set; }
        Task<HttpResponseMessage> SendPost<T>(string controller, string action, T data, string authToken);
    }
}