using CoinCapDesktop.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace CoinCapDesktop.Services
{
    class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _httpClient;
        private const string _apiKey = "";

        public string BaseUrl => "http://api.coincap.io/v2";


        public CoinCapService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "deflate");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");

        }
        public async Task<T> GetData<T>(params string[] parameters)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, string.Join("/", parameters));

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
