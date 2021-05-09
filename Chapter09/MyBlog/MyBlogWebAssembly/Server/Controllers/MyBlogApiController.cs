using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlogWebAssembly.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyBlogApiController:ControllerBase
    {
        //<Constructor>
        internal readonly IMyBlogApi api;
        public MyBlogApiController(IMyBlogApi api)
        {
            this.api = api;
        }
        //</Constructor>
        //<GetBlogPostsAsync>
        [HttpGet]
        [Route("BlogPosts")]
        public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            return await api.GetBlogPostsAsync(numberofposts, startindex);
        }
        //</GetBlogPostsAsync>

        //<GetBlogPostCountAsync>
        [HttpGet]
        [Route("BlogPostCount")]
        public async Task<int> GetBlogPostCountAsync()
        {
            return await api.GetBlogPostCountAsync();
        }
        //</GetBlogPostCountAsync>

        //<GetBlogPostAsync>
        [HttpGet]
        [Route("BlogPosts/{id}")]
        public async Task<BlogPost> GetBlogPostAsync(int id)
        {
            return await api.GetBlogPostAsync(id);
        }
        //</GetBlogPostAsync>

        //<SaveBlogPostAsync>
        [Authorize]
        [HttpPut]
        [Route("BlogPosts")]
        public async Task<BlogPost> SaveBlogPostAsync([FromBody] BlogPost item)
        {
            return await api.SaveBlogPostAsync(item);
        }
        //</SaveBlogPostAsync>

        //<DeleteBlogPostAsync>
        [Authorize]
        [HttpDelete]
        [Route("BlogPosts")]
        public async Task DeleteBlogPostAsync([FromBody] BlogPost item)
        {
            await api.DeleteBlogPostAsync(item);
        }
        //</DeleteBlogPostAsync>

        //<Categories>
        [HttpGet]
        [Route("Categories")]
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await api.GetCategoriesAsync();
        }

        [HttpGet]
        [Route("Categories/{id}")]
        public async Task<Category> GetCategoryAsync(int id)
        {
            return await api.GetCategoryAsync(id);
        }

        [Authorize]
        [HttpPut]
        [Route("Categories")]
        public async Task<Category> SaveCategoryAsync([FromBody] Category item)
        {
            return await api.SaveCategoryAsync(item);
        }

        [Authorize]
        [HttpDelete]
        [Route("Categories")]
        public async Task DeleteCategoryAsync([FromBody] Category item)
        {
            await api.DeleteCategoryAsync(item);
        }

        //</Categories>

        //<Tags>
        [HttpGet]
        [Route("Tags")]
        public async Task<List<Tag>> GetTagsAsync()
        {
            return await api.GetTagsAsync();
        }

        [HttpGet]
        [Route("Tags/{id}")]
        public async Task<Tag> GetTagAsync(int id)
        {
            return await api.GetTagAsync(id);
        }

        [Authorize]
        [HttpPut]
        [Route("Tags")]
        public async Task<Tag> SaveTagAsync([FromBody] Tag item)
        {
            return await api.SaveTagAsync(item);
        }

        [Authorize]
        [HttpDelete]
        [Route("Tags")]
        public async Task DeleteTagAsync([FromBody] Tag item)
        {
            await api.DeleteTagAsync(item);
        }
        //</Tags>



    }
}
