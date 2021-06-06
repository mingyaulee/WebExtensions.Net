using System;

namespace WebExtensions.Net.IntegrationTestsRunner.Models
{
    public class TestRunnerException : Exception
    {
        public TestRunnerException(string message) : base(message)
        {
        }
    }
}
