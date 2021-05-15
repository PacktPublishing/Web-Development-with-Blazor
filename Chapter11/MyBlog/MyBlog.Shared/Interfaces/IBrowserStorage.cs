using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Shared.Interfaces
{
    public interface IBrowserStorage
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync(string key,object value);
        Task DeleteAsync(string key);
    }
}
