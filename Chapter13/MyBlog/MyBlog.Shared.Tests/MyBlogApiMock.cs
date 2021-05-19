using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Shared.Tests
{
    public class MyBlogApiMock : IMyBlogApi
    {
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            BlogPost post = new()
            {
                Id = id,
                Text = $"This is a blog post no {id}",
                Title = $"Blogpost {id}",
                PublishDate = DateTime.Now,
                Category = await GetCategoryAsync(1),
            };
            post.Tags.Add(await GetTagAsync(1));
            post.Tags.Add(await GetTagAsync(2));
            return post;
        }
        public Task<int> GetBlogPostCountAsync()
        {
            return Task.FromResult(10);
        }
        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            List<BlogPost> list = new();
            for (int a = 0; a < numberofposts; a++)
            {
                list.Add(await GetBlogPostAsync(startindex + a));
            }
            return list;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> list = new();
            for (int a = 0; a < 10; a++)
            {
                list.Add(await GetCategoryAsync(a));
            }
            return list;
        }
        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(new Category() { Id = id, Name = $"Category {id}" });
        }

        public Task<Tag> GetTagAsync(int id)
        {
            return Task.FromResult(new Tag() { Id = id, Name = $"Tag {id}" });
        }
        public async Task<List<Tag>> GetTagsAsync()
        {
            List<Tag> list = new();
            for (int a = 0; a < 10; a++)
            {
                list.Add(await GetTagAsync(a));
            }
            return list;
        }

        public Task<BlogPost> SaveBlogPostAsync(BlogPost item)
        {
            return Task.FromResult(item);
        }
        public Task<Category> SaveCategoryAsync(Category item)
        {
            return Task.FromResult(item);
        }
        public Task<Tag> SaveTagAsync(Tag item)
        {
            return Task.FromResult(item);
        }
        public Task DeleteBlogPostAsync(BlogPost item)
        {
            return Task.CompletedTask;
        }
        public Task DeleteCategoryAsync(Category item)
        {
            return Task.CompletedTask;
        }
        public Task DeleteTagAsync(Tag item)
        {
            return Task.CompletedTask;
        }

    }
}
