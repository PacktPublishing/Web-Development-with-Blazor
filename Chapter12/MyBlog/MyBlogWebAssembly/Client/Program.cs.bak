using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyBlogWebAssembly.Client.Authentication;
using MyBlog.Data;
using MyBlog.Data.Interfaces;
using Blazored.SessionStorage;
using MyBlog.Shared.Interfaces;
using MyBlogServerSide.Services;
using MyBlogWebAssembly.Client.Services;

namespace MyBlogWebAssembly.Client
{    
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");



            //<Identity>
            builder.Services.AddHttpClient("Authenticated", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient("Public", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddApiAuthorization()
                .AddAccountClaimsPrincipalFactory<RoleAccountClaimsPrincipalFactory>();
            //</Identity>

            builder.Services.AddScoped<IMyBlogApi, MyBlogApiClientSide>();
            //<AddBlazored>
            builder.Services.AddBlazoredSessionStorage(
                options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            builder.Services.AddScoped<IBrowserStorage, MyBlogBrowserStorage>();
            //</AddBlazored>
            //<SignalR>
            builder.Services.AddSingleton<IBlogNotificationService, BlazorWebAssemblyBlogNotificationService>();
            //</SignalR>
            await builder.Build().RunAsync();
        }
    }
}
