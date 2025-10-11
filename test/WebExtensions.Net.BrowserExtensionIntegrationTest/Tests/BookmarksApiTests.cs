using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests;

[TestClass(Description = "browser.bookmarks API")]
public class BookmarksApiTests(IWebExtensionsApi webExtensionsApi)
{
    private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
    private readonly string testBookmarkTitle = Guid.NewGuid().ToString();
    private readonly string testBookmarkUrl = $"https://non-existent-url.com/?id={Guid.NewGuid()}";
    private string testBookmarkId;
    private string testBookmarkFolderId;

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
        node.ShouldNotBeNull();
        node.Title.ShouldBe(testBookmarkTitle);
        node.Url.ShouldBe(testBookmarkUrl);
        node.Id.ShouldNotBeNullOrEmpty();
        testBookmarkId = node.Id;
    }

    [Fact(Order = 2)]
    public async Task Get()
    {
        // Act
        var nodes = await webExtensionsApi.Bookmarks.Get(testBookmarkId);

        // Assert
        nodes.ShouldHaveCount(1);
        nodes.Single().Id.ShouldBe(testBookmarkId);
    }

    [Fact(Order = 2)]
    public async Task GetRecent()
    {
        // Act
        var nodes = await webExtensionsApi.Bookmarks.GetRecent(1);

        // Assert
        nodes.ShouldHaveCount(1);
        nodes.Single().Id.ShouldBe(testBookmarkId);
    }

    [Fact(Order = 2)]
    public async Task GetTree()
    {
        // Act
        var nodes = await webExtensionsApi.Bookmarks.GetTree();

        // Assert
        nodes.ShouldNotBeNullOrEmpty();
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
        node.ShouldNotBeNull();
        node.Title.ShouldBe(testBookmarkTitle + "Updated");
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
        node.ShouldNotBeNull();
        node.Title.ShouldBe(testBookmarkTitle);
        node.Id.ShouldNotBeNullOrEmpty();
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
        node.ShouldNotBeNull();
        node.ParentId.ShouldBe(testBookmarkFolderId);
    }

    [Fact(Order = 5)]
    public async Task GetChildren()
    {
        // Act
        var nodes = await webExtensionsApi.Bookmarks.GetChildren(testBookmarkFolderId);

        // Assert
        nodes.ShouldHaveCount(1);
        nodes.Single().Id.ShouldBe(testBookmarkId);
    }

    [Fact(Order = 5)]
    public async Task GetSubTree()
    {
        // Act
        var nodes = await webExtensionsApi.Bookmarks.GetSubTree(testBookmarkFolderId);

        // Assert
        nodes.ShouldHaveCount(1);
        nodes.Single().Id.ShouldBe(testBookmarkFolderId);
        nodes.Single().Children.ShouldHaveCount(1);
        nodes.Single().Children.Single().Id.ShouldBe(testBookmarkId);
    }

    [Fact(Order = 6)]
    public async Task Remove()
    {
        // Act
        Func<Task> action = async () => await webExtensionsApi.Bookmarks.Remove(testBookmarkId);

        // Assert
        await action.ShouldNotThrowAsync();
    }

    [Fact(Order = 7)]
    public async Task RemoveTree()
    {
        // Act
        Func<Task> action = async () => await webExtensionsApi.Bookmarks.RemoveTree(testBookmarkFolderId);

        // Assert
        await action.ShouldNotThrowAsync();
    }
}
