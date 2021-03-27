using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebExtension.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtension.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "Sanity Tests")]
    public class SanityTests
    {
        private readonly IWebExtensionAPI webExtensionApi;

        public SanityTests(IWebExtensionAPI webExtensionApi)
        {
            this.webExtensionApi = webExtensionApi;
        }

        [Fact(Description = "Execute API with primitive return type")]
        public async Task ExecuteAPIWithPrimitiveReturnType()
        {
            // Act
            var createdNotificationId = await webExtensionApi.Runtime.GetURL("");

            // Assert
            createdNotificationId.Should().NotBeNullOrEmpty();
        }

        [Fact(Description = "Execute API with strongly typed object return type")]
        public async Task ExecuteAPIWithStronglyTypedObjectReturnType()
        {
            // Act
            var platformInfo = await webExtensionApi.Runtime.GetPlatformInfo();

            // Assert
            platformInfo.Should().NotBeNull();
        }

        [Fact(Description = "Execute API with enumerable return type")]
        public async Task ExecuteAPIWithEnumerableReturnType()
        {
            // Act
            var tab = await webExtensionApi.Tabs.Query(new { active = true });

            // Assert
            tab.Should().NotBeNull();
            tab.Should().NotBeEmpty();
            tab.First().Id.Should().BeGreaterThan(0);
        }

        [Fact(Description = "Get primitive API property")]
        public async Task GetPrimitiveAPIProperty()
        {
            // Act
            var extensionId = await webExtensionApi.Runtime.GetId();

            // Assert
            extensionId.Should().NotBeNullOrEmpty();
        }

        [Fact(Description = "Execute reference object function")]
        public async Task ExecuteReferenceObjectFunction()
        {
            // Arrange
            var localStorageReference = await webExtensionApi.Storage.GetLocal();

            // Act
            Func<Task> action = async () => await localStorageReference.Set(new { test = true });

            // Assert
            await action.Should().NotThrowAsync();
        }

        [Fact(Description = "Execute reference object function with return")]
        public async Task ExecuteReferenceObjectFunctionWithReturn()
        {
            // Arrange
            var localStorageReference = await webExtensionApi.Storage.GetLocal();
            var testValue = Guid.NewGuid().ToString();
            await localStorageReference.Set(new { test = testValue });

            // Act
            var storageValue = await localStorageReference.Get((object)null);

            // Assert
            storageValue.Should().NotBeNull();
            storageValue.TryGetProperty("test", out var actualTestValue).Should().BeTrue();
            actualTestValue.GetString().Should().Be(testValue);
        }
    }
}
