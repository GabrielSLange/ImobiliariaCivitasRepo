﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

public class EstadoAutenticacao : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;

    public EstadoAutenticacao(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        if (string.IsNullOrWhiteSpace(token))
        {
            // Usuário não está autenticado
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        // Criar uma ClaimsIdentity a partir do token
        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwtAuthType");
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    public void MarkUserAsAuthenticated(string token)
    {
        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwtAuthType");
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void MarkUserAsLoggedOut()
    {
        var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes) ?? throw new Exception("Teste");

        claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

        return claims;
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}
