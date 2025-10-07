using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.management API")]
    public class ManagementApiTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;

        [Fact]
        public async Task Get()
        {
            // Arrange
            var extensionId = webExtensionsApi.Runtime.Id;

            // Act
            var extension = await webExtensionsApi.Management.Get(extensionId);

            // Assert
            extension.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetSelf()
        {
            // Act
            var extension = await webExtensionsApi.Management.GetSelf();

            // Assert
            extension.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAll()
        {
            // Act
            var extensions = await webExtensionsApi.Management.GetAll();

            // Assert
            extensions.ShouldNotBeNullOrEmpty();
        }
    }
}
