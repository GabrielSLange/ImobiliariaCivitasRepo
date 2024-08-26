using Blazored.LocalStorage;
using imobiliariaCivitas_shared.DTOs;
using System.Net.Http.Json;

public class AutenticacaoService
{
    private readonly HttpClient _httpClient;
    private readonly EstadoAutenticacao _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AutenticacaoService(HttpClient httpClient, EstadoAutenticacao authenticationStateProvider, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
    }

    public async Task<bool> Login(LoginUsuarioDTO loginUser)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_httpClient.BaseAddress}/login", loginUser);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        var token = await response.Content.ReadAsStringAsync();
        await _localStorage.SetItemAsync("authToken", token);

        _authenticationStateProvider.MarkUserAsAuthenticated(token);
        return true;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        _authenticationStateProvider.MarkUserAsLoggedOut();
    }
}
