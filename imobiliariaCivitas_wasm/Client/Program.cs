using Blazored.LocalStorage;
using imobiliariaCivitas_wasm.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;


namespace imobiliariaCivitas_wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddRadzenComponents();
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Adicionar o Blazored.LocalStorage para armazenamento local
            builder.Services.AddBlazoredLocalStorage();

            // Configuração do HttpClient para acessar a API
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7142") });

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
}
