using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Imobiliaria_adm.Services;

namespace Imobiliaria_adm;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://lange-dev.duckdns.org") });
        
        //Configuração padrão do Radzen
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();

        // Adicionar o Blazored.LocalStorage para armazenamento local
        builder.Services.AddBlazoredLocalStorage();

        // Configuração do AuthenticationStateProvider para gerenciar o estado de autenticação
        builder.Services.AddScoped<EstadoAutenticacao>();
        builder.Services.AddScoped<AuthenticationStateProvider, EstadoAutenticacao>();

        // Adicionar serviço de autenticação customizado
        builder.Services.AddScoped<AutenticacaoService>();
        builder.Services.AddScoped<ImobiliariaCivitasServices>();

        // Adicionar suporte para autorização
        builder.Services.AddAuthorizationCore();

        await builder.Build().RunAsync();
    }
}
