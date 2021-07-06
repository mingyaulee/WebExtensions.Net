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
        public async Task GetRedirectURL()
        {
            // Act
            var result = await webExtensionsApi.Identity.GetRedirectURL(testIdentityRedirectUrl);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
