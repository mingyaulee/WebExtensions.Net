using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests;

[TestClass(Description = "browser.i18n API")]
public class I18nApiTests(IWebExtensionsApi webExtensionsApi)
{
    private readonly IWebExtensionsApi webExtensionsApi = webExtensionsApi;
    private readonly string testMessageName = "message_key_1";
    private readonly string testMessageText = "Message";
    private readonly string testWithPlaceholdersMessageName = "message_key_2";
    private readonly string testWithPlaceholdersMessageText = "Message with placeholders {0} and {1}.";
    private bool shouldTestLocalization;

    [Fact]
    public async Task DetectLanguage()
    {
        // Act
        var result = await webExtensionsApi.I18n.DetectLanguage("Test text");

        // Assert
        result.ShouldNotBeNull();
    }
    
    [Fact]
    public async Task GetAcceptLanguages()
    {
        // Act
        var languages = await webExtensionsApi.I18n.GetAcceptLanguages();

        // Assert
        languages.ShouldNotBeNullOrEmpty();
    }

    [Fact(Order = 1)]
    public void GetUILanguage()
    {
        // Act
        var uiLanguage = webExtensionsApi.I18n.GetUILanguage();

        // Assert
        uiLanguage.ShouldNotBeNullOrEmpty();
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
        message.ShouldBe(testMessageText);
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
        message.ShouldBe(string.Format(testWithPlaceholdersMessageText, placeholders));
    }
}
