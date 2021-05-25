//<using>
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Data.Interfaces;
using System.Net.Http;
using MyBlog.Data.Models;
using System.Net.Http.Json;
using System;
using MyBlog.Data.Interfaces;
using System.Net.Http;
using MyBlog.Data.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyBlog.Data.Extensions;
using Newtonsoft.Json;

//</using>
namespace MyBlog.Data
{
    public class MyBlogApiClientSide : IMyBlogApi
    {
        //<Constructor>
        private readonly IHttpClientFactory factory;

        public MyBlogApiClientSide(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        System.Text.Json.JsonSerializerOptions jsonoptions = new System.Text.Json.JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
            PropertyNamingPolicy = null
        };
        //</Constructor>

        //<BlogpostGet>
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<BlogPost>($"MyBlogAPI/BlogPosts/{id}", jsonoptions);
        }

        public async Task<int> GetBlogPostCountAsync()
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<int>("MyBlogAPI/BlogPostCount", jsonoptions);
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<List<BlogPost>>($"MyBlogAPI/BlogPosts?numberofposts={numberofposts}&startindex={startindex}", jsonoptions);
        }
        //</BlogpostGet>
        //<BlogpostSaveDelete>
        public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            try
            {
                var httpclient = factory.CreateClient("Authenticated");
                var response = await httpclient.PutAsJsonAsync<BlogPost>("MyBlogAPI/BlogPosts", item);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BlogPost>(json);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            return null;
        }
        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            try
            {
                var httpclient = factory.CreateClient("Authenticated");
                await httpclient.DeleteAsJsonAsync<BlogPost>("MyBlogAPI/BlogPosts", item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        //</BlogpostSaveDelete>

        //<Categories>
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<List<Category>>($"MyBlogAPI/Categories", jsonoptions);
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<Category>($"MyBlogAPI/Categories/{id}", jsonoptions);
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            try
            {
                var httpclient = factory.CreateClient("Authenticated");
                await httpclient.DeleteAsJsonAsync<Category>("MyBlogAPI/Categories", item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
        public async Task<Category> SaveCategoryAsync(Category item)
        {
            try
            {
                var httpclient = factory.CreateClient("Authenticated");
                var response = await httpclient.PutAsJsonAsync<Category>("MyBlogAPI/Categories", item);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Category>(json);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            return null;
        }

        //</Categories>

        //<Tags>
        public async Task<Tag> GetTagAsync(int id)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<Tag>($"MyBlogAPI/Tags/{id}", jsonoptions);
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<List<Tag>>($"MyBlogAPI/Tags", jsonoptions);
        }

        public async Task DeleteTagAsync(Tag item)
        {
            try
            {
                var httpclient = factory.CreateClient("Authenticated");
                await httpclient.DeleteAsJsonAsync<Tag>("MyBlogAPI/Tags", item);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
        public async Task<Tag> SaveTagAsync(Tag item)
        {
            try
            {
                var httpclient = factory.CreateClient("Authenticated");
                var response = await httpclient.PutAsJsonAsync<Tag>("MyBlogAPI/Tags", item);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Tag>(json);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            return null;
        }

        //</Tags>
    }
}