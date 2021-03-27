using FluentAssertions;
using System;
using System.Threading.Tasks;
using WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.windows")]
    public class WindowsTests
    {
        private readonly IWebExtensionAPI webExtensionApi;
        private int? testWindowId;

        public WindowsTests(IWebExtensionAPI webExtensionApi)
        {
            this.webExtensionApi = webExtensionApi;
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var window = await webExtensionApi.Windows.Create(new
            {
                url = "https://google.com",
                top = 0,
                left = 0
            });

            // Assert
            window.Should().NotBeNull();
            window.Id.Should().HaveValue();
            testWindowId = window.Id;
        }

        [Fact(Order = 2)]
        public async Task Get()
        {
            // Act
            var window = await webExtensionApi.Windows.Get(testWindowId.Value, null);

            // Assert
            window.Should().NotBeNull();
            window.Id.Should().Be(testWindowId.Value);
        }

        [Fact(Order = 3)]
        public async Task Update()
        {
            // Arrange
            var windowTop = 50;
            var windowLeft = 100;

            // Act
            var window = await webExtensionApi.Windows.Update(testWindowId.Value, new
            {
                top = windowTop,
                left = windowLeft
            });

            // Assert
            window.Should().NotBeNull();
            window.Top.Should().BeCloseTo(windowTop, 5);
            window.Left.Should().BeCloseTo(windowLeft, 5);
        }

        [Fact(Order = 4)]
        public async Task Remove()
        {
            // Act
            Func<Task> action = async () => await webExtensionApi.Windows.Remove(testWindowId.Value);

            // Assert
            await action.Should().NotThrowAsync();
        }
    }
}
