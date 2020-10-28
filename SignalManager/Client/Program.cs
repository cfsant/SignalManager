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
using MatBlazor;
using Model;

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
            builder.Services.AddSingleton<UserDomain>();
            builder.Services.AddSingleton<FolderDomain>();
            builder.Services.AddSingleton<IqOptionAccount>();
            builder.Services.AddSingleton<IqOptionAdminSignalDomain>();
            builder.Services.AddSingleton<Signal>();
            builder.Services.AddSingleton<DataController<UserDomain>>();
            builder.Services.AddSingleton<DataController<IqOptionAccount>>();
            builder.Services.AddSingleton<DataController<IqOptionAdminSignalDomain>>();
            builder.Services.AddSingleton<DataController<FolderDomain>>();
            builder.Services.AddSingleton<DataController<Signal>>();
            builder.Services.AddSingleton<CookieManager>(new CookieManager(
                builder.Build().Services.GetRequiredService<IJSRuntime>(),
                builder.Build().Services.GetRequiredService<HttpClient>()));

            builder.Services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomFullWidth;
                config.PreventDuplicates = false;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 100;
                config.HideStepDuration = 1;
                config.HideTransitionDuration = 1;
                config.ShowStepDuration = 1;
                config.ShowTransitionDuration = 1;
                config.VisibleStateDuration = 1000;
                config.MaxDisplayedToasts = 3;
                config.ShowProgressBar = true;
            });

            await builder.Build().RunAsync();
        }
    }
}
