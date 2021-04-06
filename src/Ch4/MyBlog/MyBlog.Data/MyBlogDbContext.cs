using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyBlog.Data.Models;

namespace MyBlog.Data
{
    public class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> context) : base(context)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }

    public class MyBlogDbContextFactory : IDesignTimeDbContextFactory<MyBlogDbContext>
    {
        public MyBlogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyBlogDbContext>();
            optionsBuilder.UseSqlite("Data Source = test.db");

            return new MyBlogDbContext(optionsBuilder.Options);
        }
    }
}
