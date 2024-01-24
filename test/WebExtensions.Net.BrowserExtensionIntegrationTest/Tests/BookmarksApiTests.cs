using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.bookmarks API")]
    public class BookmarksApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testBookmarkTitle;
        private readonly string testBookmarkUrl;
        private string testBookmarkId;
        private string testBookmarkFolderId;

        public BookmarksApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testBookmarkTitle = Guid.NewGuid().ToString();
            testBookmarkUrl = $"https://non-existent-url.com/?id={Guid.NewGuid()}";
        }

        [Fact(Order = 1)]
        public async Task Create()
        {
            // Act
            var node = await webExtensionsApi.Bookmarks.Create(new()
            {
                Title = testBookmarkTitle,
                Url = testBookmarkUrl
            });

            // Assert
            node.Should().NotBeNull();
            node.Title.Should().Be(testBookmarkTitle);
            node.Url.Should().Be(testBookmarkUrl);
            node.Id.Should().NotBeNullOrEmpty();
            testBookmarkId = node.Id;
        }

        [Fact(Order = 2)]
        public async Task Get()
        {
            // Act
            var nodes = await webExtensionsApi.Bookmarks.Get(testBookmarkId);

            // Assert
            nodes.Should().HaveCount(1);
            nodes.Single().Id.Should().Be(testBookmarkId);
        }

        [Fact(Order = 2)]
        public async Task GetRecent()
        {
            // Act
            var nodes = await webExtensionsApi.Bookmarks.GetRecent(1);

            // Assert
            nodes.Should().HaveCount(1);
            nodes.Single().Id.Should().Be(testBookmarkId);
        }

        [Fact(Order = 2)]
        public async Task GetTree()
        {
            // Act
            var nodes = await webExtensionsApi.Bookmarks.GetTree();

            // Assert
            nodes.Should().NotBeNullOrEmpty();
        }

        [Fact(Order = 2)]
        public async Task Update()
        {
            // Act
            var node = await webExtensionsApi.Bookmarks.Update(testBookmarkId, new()
            {
                Title = testBookmarkTitle + "Updated"
            });

            // Assert
            node.Should().NotBeNull();
            node.Title.Should().Be(testBookmarkTitle + "Updated");
        }

        [Fact(Order = 3)]
        public async Task CreateFolder()
        {
            // Act
            var node = await webExtensionsApi.Bookmarks.Create(new()
            {
                Title = testBookmarkTitle
            });

            // Assert
            node.Should().NotBeNull();
            node.Title.Should().Be(testBookmarkTitle);
            node.Id.Should().NotBeNullOrEmpty();
            testBookmarkFolderId = node.Id;
        }

        [Fact(Order = 4)]
        public async Task Move()
        {
            // Act
            var node = await webExtensionsApi.Bookmarks.Move(testBookmarkId, new()
            {
                ParentId = testBookmarkFolderId
            });

            // Assert
            node.Should().NotBeNull();
            node.ParentId.Should().Be(testBookmarkFolderId);
        }

        [Fact(Order = 5)]
        public async Task GetChildren()
        {
            // Act
            var nodes = await webExtensionsApi.Bookmarks.GetChildren(testBookmarkFolderId);

            // Assert
            nodes.Should().HaveCount(1);
            nodes.Single().Id.Should().Be(testBookmarkId);
        }

        [Fact(Order = 5)]
        public async Task GetSubTree()
        {
            // Act
            var nodes = await webExtensionsApi.Bookmarks.GetSubTree(testBookmarkFolderId);

            // Assert
            nodes.Should().HaveCount(1);
            nodes.Single().Id.Should().Be(testBookmarkFolderId);
            nodes.Single().Children.Should().HaveCount(1);
            nodes.Single().Children.Single().Id.Should().Be(testBookmarkId);
        }

        [Fact(Order = 6)]
        public async Task Remove()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Bookmarks.Remove(testBookmarkId);

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Order = 7)]
        public async Task RemoveTree()
        {
            // Act
            Func<Task> action = async () => await webExtensionsApi.Bookmarks.RemoveTree(testBookmarkFolderId);

            // Assert
            await action.Should().NotThrowAsync();
        }
    }
}
