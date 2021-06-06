using System.Collections.Generic;
using WebExtensions.Net.BrowserExtensionIntegrationTest.Models;

namespace WebExtensions.Net.BrowserExtensionIntegrationTest.Infrastructure
{
    public interface ITestFactory
    {
        IEnumerable<TestClassInfo> GetAllTests();
    }
}