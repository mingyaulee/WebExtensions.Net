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
        public void GetHyperlinkAuditingEnabled()
        {
            // Act
            var setting = webExtensionsApi.Privacy.Websites.HyperlinkAuditingEnabled;

            // Assert
            setting.ShouldNotBeNull();
        }

        [Fact]
        public void GetReferrersEnabled()
        {
            // Act
            var setting = webExtensionsApi.Privacy.Websites.ReferrersEnabled;

            // Assert
            setting.ShouldNotBeNull();
        }
    }
}
