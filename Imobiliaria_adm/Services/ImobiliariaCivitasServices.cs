using imobiliariaCivitas_shared.Model;
using System.Text.Json;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Components;
using System.Text;
using imobiliariaCivitas_shared.DTOs;

namespace Imobiliaria_adm.Services
{
    public class ImobiliariaCivitasServices
    {

        string Url = "https://lange-dev.duckdns.org";
        public readonly HttpClient _client;
        public readonly ILocalStorageService _localStorage;
        public readonly NavigationManager _navigation;
        public ImobiliariaCivitasServices(HttpClient client, ILocalStorageService localStorage, NavigationManager navigation)
        {
            _client = client;
            _localStorage = localStorage;
            _navigation = navigation;
        }

        public async Task<List<tb_imovel>?> ObterImoveis()
        {

            string token = await ObterToken();

            var request = new HttpRequestMessage(HttpMethod.Get, $"{Url}/Imovel/GetImovel");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigation.NavigateTo("/");
                return new List<tb_imovel>();
            }
            else if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}");
            return JsonSerializer.Deserialize<List<tb_imovel>>(content);
        }

        #region Imagens
        public async Task<List<tb_imagem>?> ObterImagensImovel(int cdImovel)
        {
            string token = await ObterToken();

            var request = new HttpRequestMessage(HttpMethod.Get, $"{Url}/Imagem/ObterImagensPorImovel?cdImovel={cdImovel}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigation.NavigateTo("/");
                return new List<tb_imagem>();
            }
            else if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}");
            return JsonSerializer.Deserialize<List<tb_imagem>>(content);
        }

        public async Task AtualizarImagens(List<string>? imagens, List<string>? imagensExcluidas, int cd_imovel)
        {
            string token = await ObterToken();

            foreach (string stringImagem in imagens)
            {
                ImagemDTO imagem = new()
                {
                    cd_imovel = cd_imovel,
                    imagem = stringImagem
                };

                string jsonImagem = JsonSerializer.Serialize(imagem);

                var content = new StringContent(jsonImagem, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{Url}/Imagem/SalvarImagem");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Content = content;

                HttpResponseMessage response = await _client.SendAsync(request);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigation.NavigateTo("/");
                }
                else if (!response.IsSuccessStatusCode)
                    throw new Exception($"{response.StatusCode}");
            }

        }

        #endregion

        public async Task<string> CriarImovel(tb_imovel imovel)
        {
            string token = await ObterToken();

            string jsonImovel = JsonSerializer.Serialize(imovel);

            var content = new StringContent(jsonImovel, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{Url}/Imovel/CriarImovel");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = content;

            HttpResponseMessage response = await _client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigation.NavigateTo("/");
            }
            else if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}");

            return responseContent;
        }

        #region Token
        public async Task<string> ObterToken()
        {
            var tokenJson = await _localStorage.GetItemAsync<string>("authToken");
            var tokenObj = JsonSerializer.Deserialize<Dictionary<string, string>>(tokenJson);
            var token = tokenObj["token"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Token JWT não encontrado");

            return token;
        }
        #endregion
    }
}
