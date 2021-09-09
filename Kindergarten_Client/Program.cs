using Blazored.LocalStorage;
using Kindergarten_Client.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Radzen;
using Kindergarten_Client.Service.IService;
using Kindergarten_Client.Service;
using Microsoft.AspNetCore.Components.Authorization;

namespace Kindergarten_Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44330/api/") });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            builder.Services.AddScoped<IKidHttpRepository, KidHttpRepository>();
            builder.Services.AddScoped<IKgFacilityService, KgFacilityService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            await builder.Build().RunAsync();
        }
    }
}


