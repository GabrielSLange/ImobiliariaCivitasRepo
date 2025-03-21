using imobiliariaCivitas_shared.Model;
using System.Text.Json;

namespace imobiliariaCivitas_pages.Services
{
    public class ApiServices
    {
        string Url = "https://lange-dev.duckdns.org/api/";

        public readonly HttpClient _client;

        public ApiServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<tb_imovel>?> ObterImoveis()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{Url}/Imovel/GetImovel");
            HttpResponseMessage response = await _client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}");
            return JsonSerializer.Deserialize<List<tb_imovel>>(content);
        }
    }
}
