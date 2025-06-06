﻿using WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Tests
{
    [TestClass(Description = "browser.privacy.services API")]
    public class PrivacyServicesApiTests
    {
        private readonly IWebExtensionsApi webExtensionsApi;

        public PrivacyServicesApiTests(IWebExtensionsApi webExtensionsApi)
        {
            this.webExtensionsApi = webExtensionsApi;
        }

        [Fact]
        public void GetPasswordSavingEnabled()
        {
            // Act
            var setting = webExtensionsApi.Privacy.Services.PasswordSavingEnabled;

            // Assert
            setting.ShouldNotBeNull();
        }
    }
}
