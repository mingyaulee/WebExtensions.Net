using FluentAssertions;
using System.Text.Json;
using System.Threading.Tasks;
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
        public async Task GetId()
        {
            // Act
            var extensionId = await webExtensionsApi.Runtime.GetId();

            // Assert
            extensionId.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetManifest()
        {
            // Act
            var manifest = await webExtensionsApi.Runtime.GetManifest();

            // Assert
            manifest.ValueKind.Should().Be(JsonValueKind.Object);
        }

        [Fact]
        public async Task GetURL()
        {
            // Act
            var url = await webExtensionsApi.Runtime.GetURL("index.html");

            // Assert
            url.Should().StartWith("chrome-extension://")
                .And.EndWith("/index.html");
        }

        [Fact]
        public async Task GetPlatformInfo()
        {
            // Act
            var platformInfo = await webExtensionsApi.Runtime.GetPlatformInfo();

            // Assert
            platformInfo.Should().NotBeNull();
        }
    }
}
