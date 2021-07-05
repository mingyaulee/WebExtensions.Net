using FluentAssertions;
using System;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;
using WebExtensions.Net.Downloads;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.downloads API")]
    public class DownloadsApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testDownloadFileName;
        private readonly string testDownloadUrl;
        private int testDownloadId;

        public DownloadsApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testDownloadFileName = Guid.NewGuid().ToString() + ".md";
            testDownloadUrl = "https://raw.githubusercontent.com/mingyaulee/WebExtensions.Net/main/README.md";
        }

        [Fact(Order = 1)]
        public async Task Download()
        {
            // Act
            var downloadId = await webExtensionsApi.Downloads.Download(new()
            {
                Filename = testDownloadFileName,
                Url = testDownloadUrl
            });

            // Assert
            downloadId.Should().BeGreaterThan(0);
            testDownloadId = downloadId;
        }

        [Fact(Order = 2)]
        public async Task Pause()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Downloads.Pause(testDownloadId);

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Order = 2)]
        public async Task Resume()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Downloads.Resume(testDownloadId);

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Order = 2)]
        public async Task Search()
        {
            // Act
            var downloads = await webExtensionsApi.Downloads.Search(new()
            {
                Id = testDownloadId
            });

            // Assert
            downloads.Should().HaveCount(1);
        }

        [Fact(Order = 3)]
        public async Task Cancel()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Downloads.Cancel(testDownloadId);

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Order = 4)]
        public async Task Erase()
        {
            // Act
            var downloadIds = await webExtensionsApi.Downloads.Erase(new()
            {
                Id = testDownloadId
            });

            // Assert
            downloadIds.Should().HaveCount(1);
        }
    }
}
