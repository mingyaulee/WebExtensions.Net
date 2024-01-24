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
        public void GetNetworkPredictionEnabled()
        {
            // Act
            var setting = webExtensionsApi.Privacy.Network.NetworkPredictionEnabled;

            // Assert
            setting.Should().NotBeNull();
        }

        [Fact]
        public void GetWebRTCIPHandlingPolicy()
        {
            // Act
            var setting = webExtensionsApi.Privacy.Network.WebRTCIPHandlingPolicy;

            // Assert
            setting.Should().NotBeNull();
        }
    }
}
