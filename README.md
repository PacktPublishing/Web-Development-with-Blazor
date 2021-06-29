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
Page 35 (Paragraph 2, line 1): **Chapter 3, Introducing Entity Framework Core** should be **Chapter 4, Understanding Basic Blazor Components**

### Related products <Other books you may enjoy>
* An Atypical ASP.NET Core 5 Design Patterns Guide [[Packt]](https://www.packtpub.com/product/an-atypical-asp-net-core-5-design-patterns-guide/9781789346091) [[Amazon]](https://www.amazon.com/dp/1789346096)

* Customizing ASP.NET Core 5.0 [[Packt]](https://www.packtpub.com/product/customizing-asp-net-core-5-0/9781801077866) [[Amazon]](https://www.amazon.com/dp/180107786X)

## Get to Know the Author
**Jimmy Engstrom**
has been developing ever since he was 7 years old and got his first computer. He loves to be on the cutting edge of technology, trying new things. When he got wind of Blazor, he immediately realized the potential and adopted it already when it was in Beta. He has been running Blazor in production since it was launched by Microsoft.
His passion for the .NET industry and community has taken him around the world, speaking about development. Microsoft has recognized this passion by awarding him the Microsoft Most Valuable Professional 7 years in a row.

