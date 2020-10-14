using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SignalManager.Client.Controlers;
using SignalManager.Client.Models;
using Microsoft.JSInterop;

namespace SignalManager.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<BagControler>();
            builder.Services.AddSingleton<User>();
            builder.Services.AddSingleton<Signal>();
            builder.Services.AddSingleton<DataControler<User>>();
            builder.Services.AddSingleton<DataControler<Signal>>();
            builder.Services.AddSingleton<CookieManager>(new CookieManager(
                builder.Build().Services.GetRequiredService<IJSRuntime>(),
                builder.Build().Services.GetRequiredService<HttpClient>()));

            await builder.Build().RunAsync();
        }
    }
}
