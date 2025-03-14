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
        
        //Configura��o padr�o do Radzen
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();

        // Adicionar o Blazored.LocalStorage para armazenamento local
        builder.Services.AddBlazoredLocalStorage();

        // Configura��o do AuthenticationStateProvider para gerenciar o estado de autentica��o
        builder.Services.AddScoped<EstadoAutenticacao>();
        builder.Services.AddScoped<AuthenticationStateProvider, EstadoAutenticacao>();

        // Adicionar servi�o de autentica��o customizado
        builder.Services.AddScoped<AutenticacaoService>();
        builder.Services.AddScoped<ImobiliariaCivitasServices>();

        // Adicionar suporte para autoriza��o
        builder.Services.AddAuthorizationCore();

        await builder.Build().RunAsync();
    }
}
