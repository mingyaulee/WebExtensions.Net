using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
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
            var currentDirectory = Directory.GetCurrentDirectory();
            var solutionDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf("\\test"));
            var driverPath = "C:\\SeleniumWebDrivers\\ChromeDriver";
            var resultsPath = $"{solutionDirectory}\\test\\TestResults";
#if DEBUG
            var configuration = "debug";
#else
            var configuration = "release";
#endif

            var extensionPath = $"{solutionDirectory}\\test\\WebExtensions.Net.BrowserExtensionIntegrationTest\\bin\\{configuration}\\net7.0\\browserextension";

            if (!Directory.Exists(resultsPath))
            {
                Directory.CreateDirectory(resultsPath);
            }

            if (!Directory.Exists(driverPath))
            {
                throw new NotSupportedException($"Download the chromedriver from and extract the executable file to {driverPath}. Check available versions at http://chromedriver.storage.googleapis.com/");
            }

            try
            {
                using var webDriver = GetWebDriver(driverPath, extensionPath);
                await WaitForExtensionPageLoaded(webDriver);
                LaunchTestPage(webDriver);
                await WaitForTestToFinish(webDriver);

                // Test results
                var testResults = GetTestResults(webDriver);
                var resultsXML = TestResultsGenerator.Generate(testResults);
                var trxFilePath = $"{resultsPath}\\TestResults_{DateTime.UtcNow:yyyy-MM-dd_HH_mm_ss}.trx";
                await WriteResultsToFile(trxFilePath, resultsXML);
                Console.WriteLine($"Results file: {trxFilePath}");

                // Test coverage
                var testCoverage = await GetTestCoverageHits(webDriver);
                if (testCoverage is not null)
                {
                    TestCoverageWriter.Write(testCoverage.HitsFilePath, testCoverage.HitsArray);
                    Console.WriteLine($"Test coverage hits file: {testCoverage.HitsFilePath}");
                }
            }
            catch (TestRunnerException testRunnerException)
            {
                Assert.Fail(testRunnerException.Message);
            }
            catch (Exception exception)
            {
                Assert.Fail("Failed to create WebDriver. Exception message: " + exception.Message);
            }
        }

        private static WebDriver GetWebDriver(string driverPath, string extensionPath)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument($"load-extension={extensionPath}");
            return new ChromeDriver(driverPath, chromeOptions);
        }

        private static async Task WaitForExtensionPageLoaded(WebDriver webDriver)
        {
            // wait for 10 seconds
            var waitTime = 10 * 1000;
            var interval = 500;
            var count = waitTime / interval;
            while (count > 0)
            {
                count--;
                var windowHandles = webDriver.WindowHandles;
                if (windowHandles.Count == 2)
                {
                    webDriver.SwitchTo().Window(windowHandles[1]);
                    break;
                }
                await Task.Delay(interval);
            }
            if (!webDriver.Url.StartsWith("chrome-extension://"))
            {
                throw new TestRunnerException("Failed to wait for extension page to load.");
            }
        }

        private static void LaunchTestPage(WebDriver webDriver)
        {
            var extensionUri = new Uri(webDriver.Url);
            var testPageUrl = $"{extensionUri.Scheme}://{extensionUri.Host}/tests.html?random=false&coverlet";
            webDriver.Navigate().GoToUrl(testPageUrl);
        }

        private static async Task WaitForTestToFinish(WebDriver webDriver)
        {
            // wait for 30 seconds
            var waitTime = 30 * 1000;
            var interval = 500;
            var count = waitTime / interval;

            var finished = false;

            while (count > 0)
            {
                count--;
                finished = (bool)webDriver.ExecuteScript("return window.jsApiReporter && window.jsApiReporter.finished;");
                if (finished)
                {
                    break;
                }
                await Task.Delay(interval);
            }
            if (!finished)
            {
                throw new TestRunnerException("Failed to wait for tests to finish.");
            }
        }

        private static TestRunInfo GetTestResults(WebDriver webDriver)
        {
            var resultsObject = (string)webDriver.ExecuteScript("return JSON.stringify(TestRunner.GetTestResults());");
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

        private static async Task<TestCoverage> GetTestCoverageHits(WebDriver webDriver)
        {
            // wait for 5 seconds
            var waitTime = 5 * 1000;
            var interval = 500;
            var count = waitTime / interval;

            TestCoverage testCoverage = null;

            while (count > 0)
            {
                count--;
                var resultsObject = (string)webDriver.ExecuteScript("return JSON.stringify(TestRunner.GetTestCoverage());");
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
