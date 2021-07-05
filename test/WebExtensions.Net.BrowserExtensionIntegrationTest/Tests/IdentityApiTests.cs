using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.identity API")]
    public class IdentityApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public IdentityApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public async Task GetRedirectURL()
        {
            // Act
            var result = await webExtensionsApi.Identity.GetRedirectURL("http://non-existent-url.com");

            // Assert
            result.Should().NotBeNull();
        }
    }
}
