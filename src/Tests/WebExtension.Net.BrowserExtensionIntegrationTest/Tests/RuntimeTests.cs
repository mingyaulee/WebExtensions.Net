using FluentAssertions;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.runtime")]
    public class RuntimeTests
    {
        private readonly IWebExtensionAPI webExtensionApi;

        public RuntimeTests(IWebExtensionAPI webExtensionApi)
        {
            this.webExtensionApi = webExtensionApi;
        }

        [Fact]
        public async Task GetId()
        {
            // Act
            var extensionId = await webExtensionApi.Runtime.GetId();

            // Assert
            extensionId.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetManifest()
        {
            // Act
            var manifest = await webExtensionApi.Runtime.GetManifest();

            // Assert
            manifest.ValueKind.Should().Be(JsonValueKind.Object);
        }

        [Fact]
        public async Task GetURL()
        {
            // Act
            var url = await webExtensionApi.Runtime.GetURL("index.html");

            // Assert
            url.Should().StartWith("chrome-extension://")
                .And.EndWith("/index.html");
        }

        [Fact]
        public async Task GetPlatformInfo()
        {
            // Act
            var platformInfo = await webExtensionApi.Runtime.GetPlatformInfo();

            // Assert
            platformInfo.Should().NotBeNull();
        }
    }
}
