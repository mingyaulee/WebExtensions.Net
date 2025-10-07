using System.Text.Json;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "Sanity Tests")]
    public class _SanityTests(IWebExtensionsApi webExtensionsApi)
    {
        private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
        private string testStorageArea;

        [Fact(Description = "Execute API with primitive return type", Order = 1)]
        public void ExecuteAPIWithPrimitiveReturnType()
        {
            // Act
            var createdNotificationId = webExtensionsApi.Runtime.GetURL("");

            // Assert
            createdNotificationId.ShouldNotBeNullOrEmpty();
        }

        [Fact(Description = "Execute API with strongly typed object return type", Order = 2)]
        public async Task ExecuteAPIWithStronglyTypedObjectReturnType()
        {
            // Act
            var platformInfo = await webExtensionsApi.Runtime.GetPlatformInfo();

            // Assert
            platformInfo.ShouldNotBeNull();
        }

        [Fact(Description = "Execute API with enumerable return type", Order = 2)]
        public async Task ExecuteAPIWithEnumerableReturnType()
        {
            // Act
            var tabs = await webExtensionsApi.Tabs.Query(new() { Active = true });

            // Assert
            tabs.ShouldNotBeNull();
            tabs.ShouldNotBeEmpty();
            tabs.First().Id.GetValueOrDefault().ShouldBeGreaterThan(0);
        }

        [Fact(Description = "Execute API with multitype class argument type", Order = 3)]
        public async Task ExecuteAPIWithMultitypeClassArgumentType()
        {
            // Arrange
            var activeTab = (await webExtensionsApi.Tabs.Query(new() { Active = true })).First();

            // Act
            var tabs = await webExtensionsApi.Tabs.Query(new() { Url = activeTab.Url });

            // Assert
            tabs.ShouldNotBeNull();
            tabs.ShouldNotBeEmpty();
            tabs.First().Id.GetValueOrDefault().ShouldBeGreaterThan(0);
        }

        [Fact(Description = "Execute API with multitype class return type", Order = 3)]
        public async Task ExecuteAPIWithMultitypeClassReturnType()
        {
            // Arrange
            var activeTab = (await webExtensionsApi.Tabs.Query(new() { Active = true })).First();

            // Act
            var tab = await webExtensionsApi.Tabs.Move(activeTab.Id.Value, new() { Index = 1 });

            // Assert
            tab.ShouldNotBeNull();
        }

        [Fact(Description = "Get primitive API property")]
        public void GetPrimitiveAPIProperty()
        {
            // Act
            var extensionId = webExtensionsApi.Runtime.Id;

            // Assert
            extensionId.ShouldNotBeNullOrEmpty();
        }

        [Fact(Description = "Execute reference object function")]
        public async Task ExecuteReferenceObjectFunction()
        {
            // Arrange
            var localStorageReference = webExtensionsApi.Storage.Local;

            // Act
            Func<Task> action = async () => await localStorageReference.Set(new { test = true });

            // Assert
            await action.ShouldNotThrowAsync();
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
            storageValue.TryGetProperty("test", out var actualTestValue).ShouldBeTrue();
            actualTestValue.GetString().ShouldBe(testValue);
        }

        [Fact(Description = "Event listener can be added to event", Order = 1)]
        public void EventListenerCanBeAddedToEvent()
        {
            // Act
            Action action = () => webExtensionsApi.Storage.OnChanged.AddListener(HandleOnStorageChange);

            // Assert
            action.ShouldNotThrow();
        }

        [Fact(Description = "Event listener can be checked if event has the listener", Order = 2)]
        public void EventListenerCanBeCheckedIfTheEventHasTheListener()
        {
            // Act
            var isRegistered = webExtensionsApi.Storage.OnChanged.HasListener(HandleOnStorageChange);

            // Assert
            isRegistered.ShouldBeTrue();
        }

        [Fact(Description = "Event listener is invoked when the event is fired", Order = 2)]
        public async Task EventListenerIsInvokedWhenTheEventIsFired()
        {
            // Arrange
            var localStorage = webExtensionsApi.Storage.Local;
            await localStorage.Set(new { test = 1234 });
            await localStorage.Clear();

            // Assert
            testStorageArea.ShouldBe("local");
        }

        [Fact(Description = "Event listener can be removed from event", Order = 3)]
        public void EventListenerCanBeRemovedFromEvent()
        {
            // Act
            Action action = () => webExtensionsApi.Storage.OnChanged.RemoveListener(HandleOnStorageChange);

            // Assert
            action.ShouldNotThrow();
        }

        private void HandleOnStorageChange(object storageItem, string storageArea)
            => testStorageArea = storageArea;
    }
}
