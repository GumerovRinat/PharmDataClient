using Newtonsoft.Json;
using PharmDataClient.Abstractions;
using System.Net.Http.Headers;
using System.Text;

namespace PharmDataClient
{
    public class RestClient : IRestClient, IDisposable
    {
        private readonly HttpClient _client;
        private const string SERVICE_URL = "http://f3bus.test.pharmadata.ru/";

        public RestClient(string baseAddress = SERVICE_URL)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAddress);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<T>(string requestUri, string token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            AddAuthorizationHeader(request, token);
            return await SendRequestAsync<T>(request);
        }

        /// <inheritdoc />
        public async Task<T> PostAsync<T>(string requestUri, object content, string token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            AddAuthorizationHeader(request, token);
            AddContent(request, content);
            return await SendRequestAsync<T>(request);
        }

        /// <inheritdoc />
        public async Task PutAsync(string requestUri, object content, string token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, requestUri);
            AddAuthorizationHeader(request, token);
            await SendRequestAsync(request);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(string requestUri, string token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            AddAuthorizationHeader(request, token);
            await SendRequestAsync(request);
        }

        private async Task SendRequestAsync(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        private async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        private void AddAuthorizationHeader(HttpRequestMessage request, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        private void AddContent(HttpRequestMessage request, object content)
        {
            if (content != null)
            {
                var json = JsonConvert.SerializeObject(content);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
