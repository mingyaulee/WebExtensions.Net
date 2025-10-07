using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExtensions.Net.IntegrationTestsRunner.Helpers;
using WebExtensions.Net.IntegrationTestsRunner.Models;

namespace WebExtensions.Net.IntegrationTestsRunner
{
    [TestClass]
    public class Runner
    {
        [TestMethod]
        public async Task RunTests()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var solutionDirectory = currentDirectory[..currentDirectory.LastIndexOf("\\test")];
            var resultsPath = $"{solutionDirectory}\\test\\TestResults";
            var assembly = Assembly.GetExecutingAssembly();
            var targetFramework = assembly.GetCustomAttribute<TargetFrameworkAttribute>().FrameworkDisplayName.ToLower().Replace(" ", string.Empty).TrimStart('.');
            var configuration = assembly.GetCustomAttribute<AssemblyConfigurationAttribute>().Configuration;
            var extensionPath = @$"{solutionDirectory}\test\WebExtensions.Net.BrowserExtensionIntegrationTest\bin\{configuration}\{targetFramework}\browserextension";

            if (!Directory.Exists(resultsPath))
            {
                Directory.CreateDirectory(resultsPath);
            }

            try
            {
                using var playwright = await Playwright.CreateAsync();
                var browser = await LaunchBrowser(playwright, currentDirectory, extensionPath);
                var page = await browser.RunAndWaitForPageAsync(static () => Task.CompletedTask);
                var consoleMessages = new List<string>();
                page.Console += (_, message) =>
                {
                    consoleMessages.Add(message.Text);
                };
                await LaunchTestPage(page);
                await WaitForTestToFinish(page, consoleMessages);

                // Test results
                var testResults = await GetTestResults(page);
                var resultsXML = TestResultsGenerator.Generate(testResults);
                var trxFilePath = $"{resultsPath}\\TestResults_{DateTime.UtcNow:yyyy-MM-dd_HH_mm_ss}.trx";
                await WriteResultsToFile(trxFilePath, resultsXML);
                Console.WriteLine($"Results file: {trxFilePath}");

                // Test coverage
                var testCoverage = await GetTestCoverageHits(page);
                if (testCoverage is not null)
                {
                    TestCoverageWriter.Write(testCoverage.HitsFilePath, testCoverage.HitsArray);
                    Console.WriteLine($"Test coverage hits file: {testCoverage.HitsFilePath}");
                }

                if (testResults.Status == "failed")
                {
                    var errors = new StringBuilder();
                    errors.AppendLine("One or more test(s) failed.");
                    var index = 0;
                    foreach (var testResult in testResults.Tests.Where(test => test.Status == "failed"))
                    {
                        index++;
                        errors.AppendLine(
                            $"""
                            // Start Test Result {index} - {testResult.MethodName}
                            {testResult.FailMessage}
                            // End Test Result {index} - {testResult.MethodName}
                            """);
                    }
                    throw new TestRunnerException(errors.ToString());
                }
            }
            catch (TestRunnerException testRunnerException)
            {
                Assert.Fail(testRunnerException.Message);
            }
        }

        private static Task<IBrowserContext> LaunchBrowser(IPlaywright playwright, string currentDirectory, string extensionPath)
        {
            var userDataDir = Path.Combine(currentDirectory, "chrome");
            if (Directory.Exists(userDataDir))
            {
                Directory.Delete(userDataDir, true);
            }
            Directory.CreateDirectory(userDataDir);

            return playwright.Chromium.LaunchPersistentContextAsync(userDataDir, new()
            {
                Headless = false,
                Channel = "chromium",
                Args =
                [
                    $"--disable-extensions-except={extensionPath}",
                    $"--load-extension={extensionPath}"
                ]
            });
        }

        private static Task LaunchTestPage(IPage page)
        {
            var extensionUri = new Uri(page.Url);
            var testPageUrl = $"{extensionUri.Scheme}://{extensionUri.Host}/tests.html?random=false&coverlet";
            return page.GotoAsync(testPageUrl);
        }

        private static async Task WaitForTestToFinish(IPage page, IEnumerable<string> consoleMessages)
        {
            // wait for 30 seconds
            var waitTime = 30 * 1000;
            var interval = 500;
            var count = waitTime / interval;

            var finished = false;

            while (count > 0)
            {
                count--;
                finished = await page.EvaluateAsync<bool>("window.jsApiReporter && window.jsApiReporter.finished");
                if (finished)
                {
                    break;
                }
                await Task.Delay(interval);
            }

            if (!finished)
            {
                var logs = consoleMessages
                    .Where(message => !message.Contains("ThrowExceptionInTest"))
                    .ToList();
                if (logs.Count > 0)
                {
                    throw new TestRunnerException($"Failed to wait for tests to finish. Browser logs: {string.Join(Environment.NewLine, logs)}");
                }
                throw new TestRunnerException("Failed to wait for tests to finish.");
            }
        }

        private static async Task<TestRunInfo> GetTestResults(IPage page)
        {
            var resultsObject = await page.EvaluateAsync<string>("JSON.stringify(TestRunner.GetTestResults())");
            var testRunResult = JsonSerializer.Deserialize<TestRunInfo>(resultsObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (testRunResult?.Tests is null)
            {
                throw new TestRunnerException("Failed to get test run results.");
            }

            // Initialize ID properties
            testRunResult.TestRunId = Guid.NewGuid().ToString();
            foreach (var test in testRunResult.Tests)
            {
                test.ExecutionId = Guid.NewGuid().ToString();
                test.TestId = GuidHelpers.Create($"{test.DeclaringTypeFullName}.{test.MethodName}").ToString();
            }

            return testRunResult;
        }

        private static async Task<TestCoverage> GetTestCoverageHits(IPage page)
        {
            // wait for 5 seconds
            var waitTime = 5 * 1000;
            var interval = 500;
            var count = waitTime / interval;

            TestCoverage testCoverage = null;

            while (count > 0)
            {
                count--;
                var resultsObject = await page.EvaluateAsync<string>("JSON.stringify(TestRunner.GetTestCoverage())");
                testCoverage = JsonSerializer.Deserialize<TestCoverage>(resultsObject, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                if (testCoverage != null)
                {
                    break;
                }
                await Task.Delay(interval);
            }

#if RELEASE
            if (testCoverage is null)
            {
                throw new TestRunnerException("Failed to get test coverage results.");
            }

            if (testCoverage.HitsFilePath is null)
            {
                throw new TestRunnerException("Failed to get test coverage hits file path.");
            }
#endif

            return testCoverage;
        }

        private static async Task WriteResultsToFile(string trxFilePath, string resultsXML)
        {
            try
            {
                await File.WriteAllTextAsync(trxFilePath, resultsXML);
            }
            catch (Exception exception)
            {
                throw new TestRunnerException($"Failed to write results to file. Exception message: {exception.Message}");
            }
        }
    }
}
