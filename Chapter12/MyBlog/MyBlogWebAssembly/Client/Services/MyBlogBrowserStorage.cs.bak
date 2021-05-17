using MyBlog.Shared.Interfaces;
using System.Threading.Tasks;
using Blazored.SessionStorage;
namespace MyBlogServerSide.Services
{
    public class MyBlogBrowserStorage : IBrowserStorage
    {
        ISessionStorageService storage { get; set; }
        public MyBlogBrowserStorage(ISessionStorageService storage)
        {
            this.storage = storage;
        }

        public async  Task DeleteAsync(string key)
        {
            await storage.RemoveItemAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            return await storage.GetItemAsync<T>(key);
        }

        public async Task SetAsync(string key, object value)
        {
            await storage.SetItemAsync(key,value);
        }
    }
}
