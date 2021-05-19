using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MyBlog.Shared.Interfaces;
using System.Threading.Tasks;

namespace MyBlogServerSide.Services
{
    public class MyBlogProtectedBrowserStorage : IBrowserStorage
    {
        ProtectedSessionStorage storage { get; set; }
        public MyBlogProtectedBrowserStorage(ProtectedSessionStorage storage)
        {
            this.storage = storage;
        }

        public async Task DeleteAsync(string key)
        {
            await storage.DeleteAsync(key);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await storage.GetAsync<T>(key);
            if (value.Success)
            {
                return value.Value;
            }
            else
            {
                return default(T);
            }
        }

        public async Task SetAsync(string key, object value)
        {
            await storage.SetAsync(key,value);
        }
    }
}
