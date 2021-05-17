using MyBlog.Shared.Interfaces;
using System.Threading.Tasks;
using Blazored.SessionStorage;
namespace MyBlogWebAssembly.Client.Services
{
    public class MyBlogBrowserStorage : IBrowserStorage
    {
        ISessionStorageService Storage { get; set; }
        public MyBlogBrowserStorage(ISessionStorageService storage)
        {
            Storage = storage;
        }

        public async  Task DeleteAsync(string key)
        {
            await Storage.RemoveItemAsync(key);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            return await Storage.GetItemAsync<T>(key);
        }

        public async Task SetAsync(string key, object value)
        {
            await Storage.SetItemAsync(key,value);
        }
    }
}
