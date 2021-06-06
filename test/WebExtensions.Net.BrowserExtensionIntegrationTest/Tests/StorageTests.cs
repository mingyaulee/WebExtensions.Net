using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.storage")]
    public class StorageTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string storageTestKey1;
        private readonly string storageTestValue1;
        private readonly string storageTestKey2;
        private readonly string storageTestValue2;

        public StorageTests(IWebExtensionsApi webExtensionsApi)
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
            var syncStorage = await webExtensionsApi.Storage.GetSync();
            var storageItem = new Dictionary<string, string>()
            {
                { storageTestKey1, storageTestValue1 },
                { storageTestKey2, storageTestValue2 }
            };

            // Act
            Func<Task> action = async () => await syncStorage.Set(storageItem);

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Description = "sync.get", Order = 2)]
        public async Task GetSyncStorageValue()
        {
            // Arrange
            var syncStorage = await webExtensionsApi.Storage.GetSync();

            // Act
            var jsonStorageObject = await syncStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());

            // Assert
            storageObject.Should().NotBeNull();
            storageObject.Should().ContainKey(storageTestKey1);
            storageObject.Should().ContainKey(storageTestKey2);
            storageObject[storageTestKey1].Should().Be(storageTestValue1);
            storageObject[storageTestKey2].Should().Be(storageTestValue2);
        }

        [Fact(Description = "sync.remove", Order = 3)]
        public async Task RemoveSyncStorageValue()
        {
            // Arrange
            var syncStorage = await webExtensionsApi.Storage.GetSync();

            // Act
            await syncStorage.Remove(storageTestKey2);

            // Assert
            var jsonStorageObject = await syncStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.Should().NotBeNull();
            storageObject.Should().ContainKey(storageTestKey1);
            storageObject.Should().NotContainKey(storageTestKey2);
        }

        [Fact(Description = "sync.clear", Order = 4)]
        public async Task ClearSyncStorageValue()
        {
            // Arrange
            var syncStorage = await webExtensionsApi.Storage.GetSync();

            // Act
            await syncStorage.Clear();

            // Assert
            var jsonStorageObject = await syncStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.Should().BeEmpty();
        }

        [Fact(Description = "local.set", Order = 1)]
        public async Task SetLocalStorageValue()
        {
            // Assert
            var localStorage = await webExtensionsApi.Storage.GetLocal();
            var storageItem = new Dictionary<string, string>()
            {
                { storageTestKey1, storageTestValue1 },
                { storageTestKey2, storageTestValue2 }
            };

            // Act
            Func<Task> action = async () => await localStorage.Set(storageItem);

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Description = "local.get", Order = 2)]
        public async Task GetLocalStorageValue()
        {
            // Arrange
            var localStorage = await webExtensionsApi.Storage.GetLocal();

            // Act
            var jsonStorageObject = await localStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());

            // Assert
            storageObject.Should().NotBeNull();
            storageObject.Should().ContainKey(storageTestKey1);
            storageObject.Should().ContainKey(storageTestKey2);
            storageObject[storageTestKey1].Should().Be(storageTestValue1);
            storageObject[storageTestKey2].Should().Be(storageTestValue2);
        }

        [Fact(Description = "local.remove", Order = 3)]
        public async Task RemoveLocalStorageValue()
        {
            // Arrange
            var localStorage = await webExtensionsApi.Storage.GetLocal();

            // Act
            await localStorage.Remove(storageTestKey2);

            // Assert
            var jsonStorageObject = await localStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.Should().NotBeNull();
            storageObject.Should().ContainKey(storageTestKey1);
            storageObject.Should().NotContainKey(storageTestKey2);
        }

        [Fact(Description = "local.clear", Order = 4)]
        public async Task ClearLocalStorageValue()
        {
            // Arrange
            var localStorage = await webExtensionsApi.Storage.GetLocal();

            // Act
            await localStorage.Clear();

            // Assert
            var jsonStorageObject = await localStorage.Get(null);
            var storageObject = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonStorageObject.GetRawText());
            storageObject.Should().BeEmpty();
        }
    }
}
