using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "Sanity Tests")]
    public class _SanityTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private string testStorageArea;

        public _SanityTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact(Description = "Execute API with primitive return type", Order = 1)]
        public void ExecuteAPIWithPrimitiveReturnType()
        {
            // Act
            var createdNotificationId = webExtensionsApi.Runtime.GetURL("");

            // Assert
            createdNotificationId.Should().NotBeNullOrEmpty();
        }

        [Fact(Description = "Execute API with strongly typed object return type", Order = 2)]
        public async Task ExecuteAPIWithStronglyTypedObjectReturnType()
        {
            // Act
            var platformInfo = await webExtensionsApi.Runtime.GetPlatformInfo();

            // Assert
            platformInfo.Should().NotBeNull();
        }

        [Fact(Description = "Execute API with enumerable return type", Order = 2)]
        public async Task ExecuteAPIWithEnumerableReturnType()
        {
            // Act
            var tabs = await webExtensionsApi.Tabs.Query(new() { Active = true });

            // Assert
            tabs.Should().NotBeNullOrEmpty();
            tabs.First().Id.Should().BeGreaterThan(0);
        }

        [Fact(Description = "Execute API with multitype class argument type", Order = 3)]
        public async Task ExecuteAPIWithMultitypeClassArgumentType()
        {
            // Arrange
            var activeTab = (await webExtensionsApi.Tabs.Query(new() { Active = true })).First();

            // Act
            var tabs = await webExtensionsApi.Tabs.Query(new() { Url = activeTab.Url });

            // Assert
            tabs.Should().NotBeNullOrEmpty();
            tabs.First().Id.Should().BeGreaterThan(0);
        }

        [Fact(Description = "Execute API with multitype class return type", Order = 3)]
        public async Task ExecuteAPIWithMultitypeClassReturnType()
        {
            // Arrange
            var activeTab = (await webExtensionsApi.Tabs.Query(new() { Active = true })).First();

            // Act
            var tab = await webExtensionsApi.Tabs.Move(activeTab.Id.Value, new() { Index = 1 });

            // Assert
            tab.Should().NotBeNull();
        }

        [Fact(Description = "Get primitive API property")]
        public void GetPrimitiveAPIProperty()
        {
            // Act
            var extensionId = webExtensionsApi.Runtime.Id;

            // Assert
            extensionId.Should().NotBeNullOrEmpty();
        }

        [Fact(Description = "Execute reference object function")]
        public async Task ExecuteReferenceObjectFunction()
        {
            // Arrange
            var localStorageReference = webExtensionsApi.Storage.Local;

            // Act
            Func<Task> action = async () => await localStorageReference.Set(new { test = true });

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Description = "Execute reference object function with return")]
        public async Task ExecuteReferenceObjectFunctionWithReturn()
        {
            // Arrange
            var localStorageReference = webExtensionsApi.Storage.Local;
            var testValue = Guid.NewGuid().ToString();
            await localStorageReference.Set(new { test = testValue });

            // Act
            var storageValue = await localStorageReference.Get(null);

            // Assert
            storageValue.Should().NotBeNull();
            storageValue.TryGetProperty("test", out var actualTestValue).Should().BeTrue();
            actualTestValue.GetString().Should().Be(testValue);
        }

        [Fact(Description = "Event listener can be added to event", Order = 1)]
        public void EventListenerCanBeAddedToEvent()
        {
            // Act
            Action action = () => webExtensionsApi.Storage.OnChanged.AddListener(HandleOnStorageChange);

            // Assert
            action.Should().NotThrow();
        }

        [Fact(Description = "Event listener can be checked if event has the listener", Order = 2)]
        public void EventListenerCanBeCheckedIfTheEventHasTheListener()
        {
            // Act
            var isRegistered = webExtensionsApi.Storage.OnChanged.HasListener(HandleOnStorageChange);

            // Assert
            isRegistered.Should().BeTrue();
        }

        [Fact(Description = "Event listener is invoked when the event is fired", Order = 2)]
        public async Task EventListenerIsInvokedWhenTheEventIsFired()
        {
            // Arrange
            var localStorage = webExtensionsApi.Storage.Local;
            await localStorage.Set(new { test = 1234 });
            await localStorage.Clear();

            // Assert
            testStorageArea.Should().Be("local");
        }

        [Fact(Description = "Event listener can be removed from event", Order = 3)]
        public void EventListenerCanBeRemovedFromEvent()
        {
            // Act
            Action action = () => webExtensionsApi.Storage.OnChanged.RemoveListener(HandleOnStorageChange);

            // Assert
            action.Should().NotThrow();
        }

        private void HandleOnStorageChange(object storageItem, string storageArea)
        {
            testStorageArea = storageArea;
        }
    }
}
