using Core.Base.Command;
using Integration.HttpClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace SetupService.GetAllEndpoints.Command
{
    public class GetAllEndpointsCommand : BaseCommand, IGetAllEndpointsCommand
    {
        private readonly IHttpClientIntegration _httpClientIntegration;
        private readonly IConfiguration _configuration;

        public GetAllEndpointsCommand(IHttpClientIntegration httpClientIntegration, IConfiguration configuration)
        {
            _httpClientIntegration = httpClientIntegration;
            _configuration = configuration;
        }
        public async Task<List<string>> Execute()
        {
            List<string> endpoints = [];
            List<string> swaggers = _configuration.GetSection("swaggersJson").Get<List<string>>();
            foreach (string swagger in swaggers)
            {
                HttpResponseMessage response = await _httpClientIntegration.Get(swagger);
                JObject swaggerDoc = JObject.Parse(await response.Content.ReadAsStringAsync());
                JToken? paths = swaggerDoc.SelectToken("paths");
                JObject jsonObject = JObject.Parse(paths.ToString());
                foreach (JProperty property in jsonObject.Properties())
                {
                    string key = property.Name;
                    endpoints.Add(key);
                }
            }
            return await Task.FromResult(endpoints);
        }
    }
}
