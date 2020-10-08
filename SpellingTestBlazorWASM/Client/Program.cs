namespace SpellingTestBlazorWASM.Client
{
    #region using

    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using SpellingTestBlazor.Client.Services.Services;

    #endregion

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddSingleton<SpeechService>();
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient
                                             {
                                                 BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                                             });

            await builder.Build().RunAsync();
        }
    }
}
