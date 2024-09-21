﻿using imobiliariaCivitas_shared.Model;
using System.Text.Json;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Components;
namespace imobiliariaCivitas_wasm.Services
{
    public class ImobiliariaCivitasServices
    {
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
            var tokenJson = await _localStorage.GetItemAsync<string>("authToken");
            var tokenObj = JsonSerializer.Deserialize<Dictionary<string, string>>(tokenJson);
            var token = tokenObj["token"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Token JWT não encontrado");

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7142/Imovel/GetImovel");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Console.WriteLine(request);

            HttpResponseMessage response = await _client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();

            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigation.NavigateTo("/");
                return new List<tb_imovel>();
            }
            else if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}");
            return JsonSerializer.Deserialize<List<tb_imovel>>(content);
        }
    }
}
