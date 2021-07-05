using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.privacy.network API")]
    public class PrivacyNetworkApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public PrivacyNetworkApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public async Task GetNetworkPredictionEnabled()
        {
            // Act
            var setting = await webExtensionsApi.Privacy.Network.GetNetworkPredictionEnabled();

            // Assert
            setting.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWebRTCIPHandlingPolicy()
        {
            // Act
            var setting = await webExtensionsApi.Privacy.Network.GetWebRTCIPHandlingPolicy();

            // Assert
            setting.Should().NotBeNull();
        }
    }
}
