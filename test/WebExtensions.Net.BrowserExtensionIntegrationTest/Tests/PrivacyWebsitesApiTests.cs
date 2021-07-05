using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.privacy.services API")]
    public class PrivacyWebsitesApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public PrivacyWebsitesApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public async Task GetHyperlinkAuditingEnabled()
        {
            // Act
            var setting = await webExtensionsApi.Privacy.Websites.GetHyperlinkAuditingEnabled();

            // Assert
            setting.Should().NotBeNull();
        }

        [Fact]
        public async Task GetReferrersEnabled()
        {
            // Act
            var setting = await webExtensionsApi.Privacy.Websites.GetReferrersEnabled();

            // Assert
            setting.Should().NotBeNull();
        }
    }
}
