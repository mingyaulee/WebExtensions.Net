using System;

namespace WebExtension.Net.IntegrationTestsRunner.Models
{
    public class TestRunnerException : Exception
    {
        public TestRunnerException(string message) : base(message)
        {
        }
    }
}
