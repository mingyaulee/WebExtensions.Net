using System;
using System.Threading.Tasks;
using FluentAssertions;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.i18n API")]
    public class I18nApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;
        private readonly string testMessageName;
        private readonly string testMessageText;
        private readonly string testWithPlaceholdersMessageName;
        private readonly string testWithPlaceholdersMessageText;
        private bool shouldTestLocalization;

        public I18nApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
            testMessageName = "message_key_1";
            testMessageText = "Message";
            testWithPlaceholdersMessageName = "message_key_2";
            testWithPlaceholdersMessageText = "Message with placeholders {0} and {1}.";
        }

        [Fact]
        public async Task DetectLanguage()
        {
            // Act
            var result = await webExtensionsApi.I18n.DetectLanguage("Test text");

            // Assert
            result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task GetAcceptLanguages()
        {
            // Act
            var languages = await webExtensionsApi.I18n.GetAcceptLanguages();

            // Assert
            languages.Should().NotBeNullOrEmpty();
        }

        [Fact(Order = 1)]
        public void GetUILanguage()
        {
            // Act
            var uiLanguage = webExtensionsApi.I18n.GetUILanguage();

            // Assert
            uiLanguage.Should().NotBeNullOrEmpty();
            shouldTestLocalization = uiLanguage.StartsWith("en");
        }

        [Fact(Order = 2)]
        public void GetMessage()
        {
            if (!shouldTestLocalization)
            {
                return;
            }

            // Act
            var message = webExtensionsApi.I18n.GetMessage(testMessageName, null);

            // Assert
            message.Should().Be(testMessageText);
        }

        [Fact(Order = 2)]
        public void GetMessageWithPlaceholders()
        {
            if (!shouldTestLocalization)
            {
                return;
            }

            // Arrange
            var placeholders = new[]
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            };

            // Act
            var message = webExtensionsApi.I18n.GetMessage(testWithPlaceholdersMessageName, placeholders);

            // Assert
            message.Should().Be(string.Format(testWithPlaceholdersMessageText, placeholders));
        }
    }
}
