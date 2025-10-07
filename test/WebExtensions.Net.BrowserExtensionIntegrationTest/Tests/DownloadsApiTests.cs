using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.downloads API")]
    public class DownloadsApiTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
        private readonly string testDownloadFileName = Guid.NewGuid().ToString() + ".md";
        private readonly string testDownloadUrl = "https://raw.githubusercontent.com/mingyaulee/WebExtensions.Net/main/README.md";
        private int testDownloadId;

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
            downloadId.ShouldBeGreaterThan(0);
            testDownloadId = downloadId;
        }

        [Fact(Order = 2)]
        public async Task Pause()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Downloads.Pause(testDownloadId);

            // Assert
            await action.ShouldNotThrowAsync();
        }

        [Fact(Order = 2)]
        public async Task Resume()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Downloads.Resume(testDownloadId);

            // Assert
            await action.ShouldNotThrowAsync();
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
            downloads.ShouldHaveCount(1);
        }

        [Fact(Order = 3)]
        public async Task Cancel()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Downloads.Cancel(testDownloadId);

            // Assert
            await action.ShouldNotThrowAsync();
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
            downloadIds.ShouldHaveCount(1);
        }
    }
}
