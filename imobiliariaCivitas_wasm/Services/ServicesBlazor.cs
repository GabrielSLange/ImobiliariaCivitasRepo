namespace imobiliariaCivitas_wasm.Services
{
    public class ServicesBlazor
    {
        public readonly HttpClient _BlazorClient;
        public ServicesBlazor(HttpClient client)
        {
            _BlazorClient = client;
        }
    }
}
