using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.management API")]
    public class ManagementApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public ManagementApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public async Task Get()
        {
            // Arrange
            var extensionId = await webExtensionsApi.Runtime.GetId();

            // Act
            var extension = await webExtensionsApi.Management.Get(extensionId);

            // Assert
            extension.Should().NotBeNull();
        }

        [Fact]
        public async Task GetSelf()
        {
            // Act
            var extension = await webExtensionsApi.Management.GetSelf();

            // Assert
            extension.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAll()
        {
            // Act
            var extensions = await webExtensionsApi.Management.GetAll();

            // Assert
            extensions.Should().NotBeNullOrEmpty();
        }
    }
}
