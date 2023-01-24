
### Get this product for $5

<i>Packt is having its biggest sale of the year. Get this eBook or any other book, video, or course that you like just for $5 each</i>


<b><p align='center'>[Buy now](https://packt.link/9781800208728)</p></b>


<b><p align='center'>[Buy similar titles for just $5](https://subscription.packtpub.com/search)</p></b>


# Web Development with Blazor

<a href="https://www.packtpub.com/product/web-development-with-blazor-and-net-5/9781800208728"><img src="https://static.packt-cdn.com/products/9781800208728/cover/smaller" alt="Web Development with Blazor and .NET" height="256px" align="right"></a>

This is the code repository for [Web Development with Blazor](https://www.packtpub.com/product/web-development-with-blazor-and-net-5/9781800208728), published by Packt.

**A hands-on guide for .NET developers to build interactive UIs with C#**

## What is this book about?
Until now, creating interactive web pages also meant using JavaScript programming. With Blazor, Microsoft's new way to create .NET web applications, developers can now easily build interactive and rich web applications using C#. Web Development with Blazor and .NET will guide you through the most common challenges in getting started with Blazor.

This book covers the following exciting features: 
* Understand the different technologies that can be used with Blazor for building cross-platform applications
* Find out how to build simple and advanced Blazor components
* Explore the differences between server-side and WebAssembly projects
* Discover how the Entity Framework works and build a simple API
* Get up to speed with components and find out how to create basic and advanced components

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1800208723) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>


## Instructions and Navigations
All of the code is organized into folders. For example, Chapter02.

The code will look like the following:
```
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        await builder.Build().RunAsync();
    }
}


```

**Following is what you need for this book:**
This web development book is for web developers and software developers who want to explore Blazor for building dynamic web UIs. This book assumes beginner-level knowledge of C# programming and intermediate-level web development skills.

With the following software and hardware list you can run all code files present in the book (Chapter 1-15).

### Software and Hardware List

| Chapter  | Software required                   | OS required                        |
| -------- | ------------------------------------| -----------------------------------|
| 1-15     | Visual Studio 2019                    | Windows, Mac OS X, and Linux (Any) |


We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://static.packt-cdn.com/downloads/9781800208728_ColorImages.pdf).

## Errata 

Page 10 (Paragraph 3, line 2): **Chapter 3, Introducing Entity Framework Core** should be **Chapter 4, Understanding Basic Blazor Components**
Page 8 (line 8): **We will take a look at these this book.** should be **We will take a look at these IN this book.**

Page 35 (Paragraph 2, line 1): **Chapter 3, Introducing Entity Framework Core** should be **Chapter 4, Understanding Basic Blazor Components**

Page 54 **BlogPost.cs** Make sure the Tags property is also instantiated like this:
```
public ICollection<Tag> Tags { get; set; }=new List<Tag>();
```

Page 63-66 In the **MyBlog.Data-project** in the file **MyBlogApiServerSide.cs**  we need to add some code to **SaveItem** method need some additional code to set the category.
``` csharp
private async Task<IMyBlogItem> SaveItem(IMyBlogItem item)
{
    using var context = factory.CreateDbContext();
    if (item.Id == 0)
    {
        if (item is BlogPost)
        {
            var post = item as BlogPost;
            post.Category = await context.Categories.FirstOrDefaultAsync(c => c.Id == post.Category.Id);
            context.Add(item);
        }
        else
        {
            context.Add(item);
        }
    }
    else
    {
        if (item is BlogPost)
        {
            var post = item as BlogPost;
            var currentpost = await context.BlogPosts.Include(p => p.Category).Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == post.Id);
            currentpost.PublishDate = post.PublishDate;
            currentpost.Title = post.Title;
            currentpost.Text = post.Text;
            var ids = post.Tags.Select(t => t.Id);
            currentpost.Tags = context.Tags.Where(t => ids.Contains(t.Id)).ToList();
            currentpost.Category = await context.Categories.FirstOrDefaultAsync(c => c.Id == post.Category.Id);
            await context.SaveChangesAsync();
        }
        else
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
    await context.SaveChangesAsync();
    return item;
}
```
Page 92 In MyBlogServerside/Pages/Index.razor we need to add a category as well.
``` csharp 
protected async Task AddSomePosts()
{
    var category = await api.SaveCategoryAsync(new Category() { Name = "New Category" });
    for (int i = 0; i < 10; i++)
    {
        var post = new BlogPost
            {
               PublishDate = DateTime.Now, 
               Title = $"Blog post {i}", 
               Text = "Text",
               Category=category
            };
        await api.SaveBlogPostAsync(post);
    }   
}
```
Page 151 The **MyBlogAPIClientSide.cs** are missing some steps in the book, please use the source code for reference.

Page 164 Step 8 also need ```AddRoles<IdentityRole>()```
```
            services.AddDbContext<MyBlogDbContext>(opt => opt.UseSqlite(Configuration.GetConnectionString("MyBlogDB")));
            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MyBlogDbContext>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AppUser>>();
```

Page 187 Step 5 refers to the **MyBlog.Shared** project that we haven't created yet, skip adding it to the project and go back and add it after completing the steps on page 189.

Page 139 Step 10
Make sure to initialize the variables like this:
```
List<Category> Categories { get; set; } = new();
List<Tag> Tags { get; set; } = new();
```

Page 235 **BlazorWebAssemblyBlogNotificationService.cs**
The code snippet:
```public Action<BlogPost> BlogPostChanged { get; set; }```
Should be
```public event Action<BlogPost> BlogPostChanged;```  

Page 241 **IBlogNotificationService.cs**
The code snippet 
```Action<BlogPost> BlogPostChanged {get; set;}```
Should be:
```event Action<BlogPost> BlogPostChanged;```

Page 90 (last code snippet ,line 3)

``` To pass a value to the component, we surround it with a CascadingValue component like this: ```
Should be:
``` // To pass a value to the component, we surround it with a CascadingValue component like this: ```


### Related products <Other books you may enjoy>
* An Atypical ASP.NET Core 5 Design Patterns Guide [[Packt]](https://www.packtpub.com/product/an-atypical-asp-net-core-5-design-patterns-guide/9781789346091) [[Amazon]](https://www.amazon.com/dp/1789346096)

* Customizing ASP.NET Core 5.0 [[Packt]](https://www.packtpub.com/product/customizing-asp-net-core-5-0/9781801077866) [[Amazon]](https://www.amazon.com/dp/180107786X)

## Get to Know the Author
**Jimmy Engstrom**
has been developing ever since he was 7 years old and got his first computer. He loves to be on the cutting edge of technology, trying new things. When he got wind of Blazor, he immediately realized the potential and adopted it already when it was in Beta. He has been running Blazor in production since it was launched by Microsoft.
His passion for the .NET industry and community has taken him around the world, speaking about development. Microsoft has recognized this passion by awarding him the Microsoft Most Valuable Professional 7 years in a row.

### Download a free PDF

 <i>If you have already purchased a print or Kindle version of this book, you can get a DRM-free PDF version at no cost.<br>Simply click on the link to claim your free PDF.</i>
<p align="center"> <a href="https://packt.link/free-ebook/9781800208728">https://packt.link/free-ebook/9781800208728 </a> </p>
