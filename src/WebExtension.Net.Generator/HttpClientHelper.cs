using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebExtension.Net.Generator
{
    public class HttpClientHelper
    {
        public HttpClientHelper()
        {

        }
        private HttpClient httpClient = new();

        public Task<JsonElement> GetAsJsonAsync(string url)
        {
            return httpClient.GetFromJsonAsync<JsonElement>(url);
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
