using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MyBlog.Data.Models;

namespace MyBlogWebAssembly.Server.Hubs
{
    public class BlogNotificationHub : Hub
    {
        public async Task SendNotification(BlogPost post)
        {
            await Clients.All.SendAsync("BlogPostChanged", post);
        }
    }
}