using System;
using System.Collections.Generic;
using MyBlog.Data.Interfaces;

namespace MyBlog.Data.Models
{
    public class Tag : IMyBlogItem
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}