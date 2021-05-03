using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyBlog.Data.Interfaces;

namespace MyBlog.Data.Models
{
    public class Tag:IMyBlogItem
    {
        public int Id {get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
