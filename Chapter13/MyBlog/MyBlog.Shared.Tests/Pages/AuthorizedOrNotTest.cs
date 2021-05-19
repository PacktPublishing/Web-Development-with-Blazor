using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyBlog.Shared.Tests.Pages.Admin
{
    public class AuthorizedOrNotTest:TestContext
    {
        [Fact(DisplayName = "Shows not authorized")]
        public void ShowsNotAuthorized()
        {
            var authContext = this.AddTestAuthorization();
            
            var cut = RenderComponent<MyBlog.Shared.Pages.AuthorizedOrNot>();
            var content = cut.Find("strong").TextContent;
            Assert.Equal("Not Authorized", content);
        }

        [Fact(DisplayName = "Shows authorized")]
        public void ShowsAuthorized()
        {
            var authContext = this.AddTestAuthorization();
            authContext.SetAuthorized("Testuser", AuthorizationState.Authorized);

            var cut = RenderComponent<MyBlog.Shared.Pages.AuthorizedOrNot>();
            var content = cut.Find("strong").TextContent;
            Assert.Equal("Authorized", content);
        }
    }
}
