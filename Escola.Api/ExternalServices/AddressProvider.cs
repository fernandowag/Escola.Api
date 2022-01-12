using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Escola.Api.ExternalServices
{
    public class AddressProvider
    {
        private HttpClient _httpClient;

        public AddressProvider()
        {
            _httpClient = new HttpClient();
        }

        public async Task<object> GetAdress(int cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request);
            var objectResponse = response.Content.ReadAsStringAsync().Result; 
            object address = JsonSerializer.Deserialize<object>(objectResponse);

            return address;

        }
    }
}
