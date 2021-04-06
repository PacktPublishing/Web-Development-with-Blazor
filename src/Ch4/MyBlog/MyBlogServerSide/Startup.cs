using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Data;
using MyBlog.Data.Interfaces;
using MyBlogServerSide.Data;


namespace MyBlogServerSide
{

    public class Startup
    {
        //<Startup>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        //</Startup>

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            //<AddMyBlogDataServices>
            services.AddDbContextFactory<MyBlogDbContext>(opt => opt.UseSqlite($"Data Source=../MyBlog.db"));
            services.AddScoped<IMyBlogApi, MyBlogApiServerSide>();
            //</AddMyBlogDataServices>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //<ConfigureMigrate>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbContextFactory<MyBlogDbContext> factory)
        {
            factory.CreateDbContext().Database.Migrate();
        //</ConfigureMigrate>
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }

}
