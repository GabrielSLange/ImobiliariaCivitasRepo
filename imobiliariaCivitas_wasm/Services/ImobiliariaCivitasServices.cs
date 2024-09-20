using imobiliariaCivitas_shared.Model;
using System.Text.Json;

namespace imobiliariaCivitas_wasm.Services
{
    public class ImobiliariaCivitasServices
    {
        public readonly HttpClient _client;
        public ImobiliariaCivitasServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<tb_imovel>?> ObterImoveis()
        {
            HttpResponseMessage response = await _client.GetAsync("https://localhost:7142/Imovel");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}");
            return JsonSerializer.Deserialize<List<tb_imovel>>(content);
        }
    }
}
