using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.MicroService
{
    public class CallMicroService : ICallMicroService
    {
        public string BaseUrl { get; set; }
        private readonly HttpClient _httpClient;

        public CallMicroService()
        {
            _httpClient = new System.Net.Http.HttpClient();
        }


        public async Task<HttpResponseMessage> SendPost<T>(string controller, string action, T data, string authToken)
        {
            try
            {
                string url = string.Format("{0}{1}/{2}", BaseUrl, controller, action);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
                /*   StringContent json = new(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                   HttpResponseMessage response = await _httpClient.PostAsync(url, json);
                   return response;*/


                StringContent content = new(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                // Poslat POST požadavek
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                // Zpracovat odpověď
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response: {responseContent}");
                }
                else
                {
                    // Získání stavového kódu
                    int statusCode = (int)response.StatusCode;
                    Console.WriteLine($"Error: Status Code {statusCode}");

                    // Získání zprávy z obsahu odpovědi (pokud je dostupná)
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error Content: {responseContent}");
                }
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
