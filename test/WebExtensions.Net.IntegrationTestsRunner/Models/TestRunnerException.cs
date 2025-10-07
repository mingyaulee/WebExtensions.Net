using System;

namespace WebExtensions.Net.IntegrationTestsRunner.Models
{
    public class TestRunnerException(string message) : Exception(message)
    {
    }
}
