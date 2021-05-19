using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data.Models;
using MyBlog.Shared.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyBlogWebAssembly.Client.Services
{
    public class BlazorWebAssemblyBlogNotificationService: IBlogNotificationService, IAsyncDisposable
    {
        NavigationManager navigationManager;
        public BlazorWebAssemblyBlogNotificationService(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;

            hubConnection = new HubConnectionBuilder().AddJsonProtocol(options => {
                options.PayloadSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            })
            .WithUrl(navigationManager.ToAbsoluteUri("/BlogNotificationHub"))
            .Build();

            hubConnection.On<BlogPost>("BlogPostChanged", (post) =>
            {
                BlogPostChanged?.Invoke(post);
            });

            hubConnection.StartAsync();
        }

        private HubConnection hubConnection;

        public event Action<BlogPost> BlogPostChanged;

        public async Task SendNotification(BlogPost post)
        {
            await hubConnection.SendAsync("SendNotification", post);
        }

        public async ValueTask DisposeAsync()
        {
            await hubConnection.DisposeAsync();
        }
    }
}
