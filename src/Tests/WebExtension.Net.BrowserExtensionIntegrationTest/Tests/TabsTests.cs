using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.tabs")]
    public class TabsTests
    {
        private readonly IWebExtensionAPI webExtensionApi;
        private int? testTabId;
        private readonly string testTabUrl;

        public TabsTests(IWebExtensionAPI webExtensionApi)
        {
            this.webExtensionApi = webExtensionApi;
            testTabUrl = "https://developer.chrome.com/?testId=" + Guid.NewGuid().ToString();
        }

        [Fact]
        public async Task GetCurrent()
        {
            // Act
            var tab = await webExtensionApi.Tabs.GetCurrent();

            // Assert
            tab.Should().NotBeNull();
            tab.Id.Should().NotBeNull();
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var tab = await webExtensionApi.Tabs.Create(new
            {
                url = testTabUrl
            });

            // Assert
            tab.Should().NotBeNull();
            tab.Id.Should().HaveValue();
            tab.Id.Should().NotBe(webExtensionApi.Tabs.TAB_ID_NONE);
            testTabId = tab.Id;
        }

        [Fact(Order = 2)]
        public async Task Get()
        {
            // Act
            var tab = await webExtensionApi.Tabs.Get(testTabId.Value);
            int attemptCount = 0;
            while (tab.Status != "complete" && attemptCount < 10)
            {
                attemptCount++;
                await Task.Delay(500);
                tab = await webExtensionApi.Tabs.Get(testTabId.Value);
            }

            // Assert
            tab.Should().NotBeNull();
            tab.Id.Should().Be(testTabId.Value);
            tab.Url.Should().Be(testTabUrl);
            tab.Status.Should().Be("complete");
        }

        [Fact(Order = 3)]
        public async Task Query()
        {
            // Act
            var tabs = await webExtensionApi.Tabs.Query(new
            {
                url = testTabUrl
            });

            // Assert
            tabs.Should().NotBeEmpty();
            tabs.Should().HaveCount(1);
            tabs.Single().Id.Should().Be(testTabId);
        }

        [Fact(Order = 4)]
        public async Task Update()
        {
            // Arrange
            var url = "https://developer.chrome.com/?testId=" + Guid.NewGuid().ToString();

            // Act
            var tab = await webExtensionApi.Tabs.Update(testTabId.Value, new
            {
                url = url
            });

            // Assert
            tab.Should().NotBeNull();
            tab.Status.Should().Be("loading");
        }

        [Fact(Order = 5)]
        public async Task Remove()
        {
            // Act
            Func<Task> action = async () => await webExtensionApi.Tabs.Remove(testTabId.Value);

            // Assert
            await action.Should().NotThrowAsync();
        }
    }
}
