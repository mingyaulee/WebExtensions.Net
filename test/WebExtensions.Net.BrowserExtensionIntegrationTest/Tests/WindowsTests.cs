using FluentAssertions;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.Windows;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.windows")]
    public class WindowsTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private int? testWindowId;

        public WindowsTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var window = await webExtensionsApi.Windows.Create(new CreateData()
            {
                Url = "https://google.com",
                Top = 0,
                Left = 0
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
            var window = await webExtensionsApi.Windows.Get(testWindowId.Value, null);

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
            var window = await webExtensionsApi.Windows.Update(testWindowId.Value, new UpdateInfo()
            {
                Top = windowTop,
                Left = windowLeft
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
            Func<Task> action = async () => await webExtensionsApi.Windows.Remove(testWindowId.Value);

            // Assert
            await action.Should().NotThrowAsync();
        }
    }
}
