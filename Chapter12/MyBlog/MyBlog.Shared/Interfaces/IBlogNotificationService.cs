using MyBlog.Data.Models;
using System;
using System.Threading.Tasks;

namespace MyBlog.Shared.Interfaces
{
    public interface IBlogNotificationService
    {
        event Action<BlogPost> BlogPostChanged;
        Task SendNotification(BlogPost post);
    }
}
