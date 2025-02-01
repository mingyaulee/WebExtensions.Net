using System.Text.Json;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.runtime API")]
    public class RuntimeApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public RuntimeApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public void GetId()
        {
            // Act
            var extensionId = webExtensionsApi.Runtime.Id;

            // Assert
            extensionId.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void GetManifest()
        {
            // Act
            var manifest = webExtensionsApi.Runtime.GetManifest();

            // Assert
            manifest.ValueKind.ShouldBe(JsonValueKind.Object);
        }

        [Fact]
        public void GetURL()
        {
            // Act
            var url = webExtensionsApi.Runtime.GetURL("index.html");

            // Assert
            url.ShouldStartWith("chrome-extension://");
            url.ShouldEndWith("/index.html");
        }

        [Fact]
        public async Task GetPlatformInfo()
        {
            // Act
            var platformInfo = await webExtensionsApi.Runtime.GetPlatformInfo();

            // Assert
            platformInfo.ShouldNotBeNull();
        }
    }
}
