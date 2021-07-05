using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.privacy.services API")]
    public class PrivacyServicesApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public PrivacyServicesApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public async Task GetPasswordSavingEnabled()
        {
            // Act
            var setting = await webExtensionsApi.Privacy.Services.GetPasswordSavingEnabled();

            // Assert
            setting.Should().NotBeNull();
        }
    }
}
