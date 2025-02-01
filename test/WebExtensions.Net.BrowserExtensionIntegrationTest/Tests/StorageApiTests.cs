using System.Text.Json;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.storage API")]
    public class StorageApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string storageTestKey1;
        private readonly string storageTestValue1;
        private readonly string storageTestKey2;
        private readonly string storageTestValue2;

        public StorageApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            storageTestKey1 = "test";
            storageTestValue1 = Guid.NewGuid().ToString();
            storageTestKey2 = "toRemove";
            storageTestValue2 = Guid.NewGuid().ToString();
        }

        [Fact(Description = "sync.set", Order = 1)]
        public async Task SetSyncStorageValue()
        {
            // Assert
            var syncStorage = webExtensionsApi.Storage.Sync;
            var storageItem = new Dictionary<string, string>()
            {
                { storageTestKey1, storageTestValue1 },
                { storageTestKey2, storageTestValue2 }
            };

            // Act
            Func<Task> action = async () => await syncStorage.Set(storageItem);

            // Assert
            await action.ShouldNotThrowAsync();
        }

        [Fact(Description = "sync.get", Order = 2)]
        public async Task GetSyncStorageValue()
        {
            // Arrange
            var syncStorage = webExtensionsApi.Storage.Sync;

            // Act
            var jsonStorageObject = await syncStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());

            // Assert
            storageObject.ShouldNotBeNull();
            storageObject.ShouldContainKey(storageTestKey1);
            storageObject.ShouldContainKey(storageTestKey2);
            storageObject[storageTestKey1].ShouldBe(storageTestValue1);
            storageObject[storageTestKey2].ShouldBe(storageTestValue2);
        }

        [Fact(Description = "sync.remove", Order = 3)]
        public async Task RemoveSyncStorageValue()
        {
            // Arrange
            var syncStorage = webExtensionsApi.Storage.Sync;

            // Act
            await syncStorage.Remove(storageTestKey2);

            // Assert
            var jsonStorageObject = await syncStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.ShouldNotBeNull();
            storageObject.ShouldContainKey(storageTestKey1);
            storageObject.ShouldNotContainKey(storageTestKey2);
        }

        [Fact(Description = "sync.clear", Order = 4)]
        public async Task ClearSyncStorageValue()
        {
            // Arrange
            var syncStorage = webExtensionsApi.Storage.Sync;

            // Act
            await syncStorage.Clear();

            // Assert
            var jsonStorageObject = await syncStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.ShouldBeEmpty();
        }

        [Fact(Description = "local.set", Order = 1)]
        public async Task SetLocalStorageValue()
        {
            // Assert
            var localStorage = webExtensionsApi.Storage.Local;
            var storageItem = new Dictionary<string, string>()
            {
                { storageTestKey1, storageTestValue1 },
                { storageTestKey2, storageTestValue2 }
            };

            // Act
            Func<Task> action = async () => await localStorage.Set(storageItem);

            // Assert
            await action.ShouldNotThrowAsync();
        }

        [Fact(Description = "local.get", Order = 2)]
        public async Task GetLocalStorageValue()
        {
            // Arrange
            var localStorage = webExtensionsApi.Storage.Local;

            // Act
            var jsonStorageObject = await localStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());

            // Assert
            storageObject.ShouldNotBeNull();
            storageObject.ShouldContainKey(storageTestKey1);
            storageObject.ShouldContainKey(storageTestKey2);
            storageObject[storageTestKey1].ShouldBe(storageTestValue1);
            storageObject[storageTestKey2].ShouldBe(storageTestValue2);
        }

        [Fact(Description = "local.remove", Order = 3)]
        public async Task RemoveLocalStorageValue()
        {
            // Arrange
            var localStorage = webExtensionsApi.Storage.Local;

            // Act
            await localStorage.Remove(storageTestKey2);

            // Assert
            var jsonStorageObject = await localStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.ShouldNotBeNull();
            storageObject.ShouldContainKey(storageTestKey1);
            storageObject.ShouldNotContainKey(storageTestKey2);
        }

        [Fact(Description = "local.clear", Order = 4)]
        public async Task ClearLocalStorageValue()
        {
            // Arrange
            var localStorage = webExtensionsApi.Storage.Local;

            // Act
            await localStorage.Clear();

            // Assert
            var jsonStorageObject = await localStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.ShouldBeEmpty();
        }
    }
}
