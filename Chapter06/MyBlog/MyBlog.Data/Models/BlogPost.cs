using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyBlog.Data.Interfaces;

namespace MyBlog.Data.Models
{
    public class BlogPost:IMyBlogItem
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public Category Category { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
