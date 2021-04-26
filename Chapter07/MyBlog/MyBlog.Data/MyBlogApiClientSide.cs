//<using>
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBlog.Data.Interfaces;
using System.Net.Http;
using MyBlog.Data.Models;
using System.Net.Http.Json;
using System;
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
        //</Constructor>

        //<BlogpostGet>
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<BlogPost>($"MyBlogAPI/BlogPosts/{id}");
        }

        public async Task<int> GetBlogPostCountAsync()
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<int>("MyBlogAPI/BlogPostCount");
        }

        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<List<BlogPost>>($"MyBlogAPI/BlogPosts?numberofposts={numberofposts}&startindex={startindex}");
        }
        //</BlogpostGet>
        //<BlogpostSaveDelete>
        public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBlogPostAsync(BlogPost item)
        {
            throw new NotImplementedException();
        }
        //</BlogpostSaveDelete>

        //<Categories>
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<List<Category>>($"MyBlogAPI/Categories");
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<Category>($"MyBlogAPI/Categories/{id}");
        }

        public async Task DeleteCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }
        public async Task<Category> SaveCategoryAsync(Category item)
        {
            throw new NotImplementedException();
        }
        //</Categories>

        //<Tags>
        public async Task<Tag> GetTagAsync(int id)
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<Tag>($"MyBlogAPI/Tags/{id}");
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            var httpclient = factory.CreateClient("Public");
            return await httpclient.GetFromJsonAsync<List<Tag>>($"MyBlogAPI/Tags");
        }

        public async Task DeleteTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> SaveTagAsync(Tag item)
        {
            throw new NotImplementedException();
        }
        //</Tags>
    }
}