using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
//<using>
using MyBlog.Data;
using MyBlog.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
//</using>
//<IdentityUsing>
using MyBlog.Data.Models;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
//</IdentityUsing>
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace MyBlogWebAssembly.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //<AddMyBlogDataServices>
            services.AddDbContextFactory<MyBlogDbContext>(opt => opt.UseSqlite($"Data Source=../../MyBlog.db"));
            services.AddScoped<IMyBlogApi, MyBlogApiServerSide>();
            //</AddMyBlogDataServices>

            //<Identity>
            services.AddDbContext<MyBlogDbContext>(opt => opt.UseSqlite($"Data Source=../../MyBlog.db"));

            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MyBlogDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<AppUser, MyBlogDbContext>(options =>
                {
                    options.IdentityResources["openid"].UserClaims.Add("name");
                    options.ApiResources.Single().UserClaims.Add("name");
                    options.IdentityResources["openid"].UserClaims.Add("role");
                    options.ApiResources.Single().UserClaims.Add("role");
                });
                JwtSecurityTokenHandler.DefaultInboundClaimFilter.Remove("role");

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddDatabaseDeveloperPageExceptionFilter();
            //</Identity>

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

          

            app.UseRouting();
            //<IdentityApp>
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            //</IdentityApp>
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
