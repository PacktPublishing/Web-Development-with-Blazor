using System;
using System.Collections.Generic;
using MyBlog.Data.Interfaces;

namespace MyBlog.Data.Models
{
    public class BlogPost : IMyBlogItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
