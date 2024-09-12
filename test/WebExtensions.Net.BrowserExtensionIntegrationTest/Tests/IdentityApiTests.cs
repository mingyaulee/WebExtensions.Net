using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.identity API")]
    public class IdentityApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testIdentityRedirectUrl;

        public IdentityApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testIdentityRedirectUrl = "https://non-existent-url.com";
        }

        [Fact]
        public void GetRedirectURL()
        {
            // Act
            var result = webExtensionsApi.Identity.GetRedirectURL(testIdentityRedirectUrl);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
