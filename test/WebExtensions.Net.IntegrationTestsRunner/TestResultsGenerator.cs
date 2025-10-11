using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using WebExtensions.Net.IntegrationTestsRunner.Models;

namespace WebExtensions.Net.IntegrationTestsRunner;

public static class TestResultsGenerator
{
    private const string TestListId = "8c84fa94-04c1-424b-9868-57a2d4851a1d";
    private const string TestTypeId = "13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b";

    public static string Generate(TestRunInfo testRunInfo)
    {
        var vsTestRun = GetVSTestRun(testRunInfo);
        return SerializeToXML(vsTestRun);
    }

    private static TestRunType GetVSTestRun(TestRunInfo testRunInfo)
    {
        var results = new ResultsType()
        {
            Items = [.. testRunInfo.Tests.Select(MapTestResult)],
            ItemsElementName = [.. testRunInfo.Tests.Select(_ => ItemsChoiceType3.UnitTestResult)]
        };
        var testDefinitions = new TestDefinitionType()
        {
            Items = [.. testRunInfo.Tests.Select(MapTestDefinition)],
            ItemsElementName = [.. testRunInfo.Tests.Select(_ => ItemsChoiceType4.UnitTest)]
        };
        var testEntries = new TestEntriesType1()
        {
            TestEntry = [.. testRunInfo.Tests.Select(MapTestEntry)],
        };
        var testLists = new TestRunTypeTestLists()
        {
            TestList =
            [
                new TestListType() { name = "Results Not in a List", id = TestListId },
                new TestListType() { name = "All Loaded Results", id = "19431567-8539-422a-85d7-44ee4e166bda" }
            ]
        };
        var resultsSummary = MapSummary(testRunInfo);

        return new TestRunType()
        {
            id = Guid.NewGuid().ToString(),
            Items = [results, testDefinitions, testEntries, testLists, resultsSummary]
        };
    }

    private static object MapTestResult(TestInfo testInfo)
    {
        var testResult = new UnitTestResultType()
        {
            executionId = testInfo.ExecutionId,
            testId = testInfo.TestId,
            testName = testInfo.FullName,
            duration = TimeSpan.FromMilliseconds(testInfo.Duration).ToString(),
            testType = TestTypeId,
            outcome = MapStatus(testInfo.Status).ToString(),
            testListId = TestListId,
            relativeResultsDirectory = testInfo.ExecutionId
        };
        if (testResult.outcome == "NotExecuted")
        {
            var output = new OutputType()
            {
                StdOut = testInfo.Skip
            };
            testResult.Items = [output];
        }
        else if (testResult.outcome == "Failed")
        {
            var output = new OutputType()
            {
                ErrorInfo = new OutputTypeErrorInfo()
                {
                    Message = testInfo.FailMessage,
                    StackTrace = testInfo.StackTrace
                }
            };
            testResult.Items = [output];
        }
        return testResult;
    }

    private static TestStatus MapStatus(string status) => status switch
    {
        "passed" => TestStatus.Passed,
        "failed" => TestStatus.Failed,
        "pending" => TestStatus.NotExecuted,
        _ => throw new TestRunnerException($"Test status '{status}' is not recognized.")
    };

    private static object MapTestDefinition(TestInfo testInfo)
    {
        var testDefinition = new UnitTestType()
        {
            name = testInfo.FullName,
            storage = "",   // skipped, value = dll
            id = testInfo.TestId,
            TestMethod = new UnitTestTypeTestMethod()
            {
                codeBase = "",  // skipped, value = dll
                adapterTypeName = "",   // skipped, value = executor://xunit/VsTestRunner2/netcoreapp
                className = testInfo.DeclaringTypeFullName,
                name = testInfo.MethodName
            }
        };
        var execution = new BaseTestTypeExecution()
        {
            id = testInfo.ExecutionId
        };
        testDefinition.Items = [execution];
        return testDefinition;
    }

    private static TestEntryType MapTestEntry(TestInfo testInfo) => new()
    {
        testId = testInfo.TestId,
        executionId = testInfo.ExecutionId,
        testListId = TestListId
    };

    private static TestRunTypeResultSummary MapSummary(TestRunInfo testRunInfo)
    {
        var testSummary = new TestRunTypeResultSummary()
        {
            outcome = testRunInfo.Status switch
            {
                "passed" => "Passed",
                "failed" => "Failed",
                _ => throw new TestRunnerException($"Test overall status '{testRunInfo.Status}' is not recognized.")
            }
        };
        var total = 0;
        var executed = 0;
        var passed = 0;
        var failed = 0;
        var notExecuted = 0;
        foreach (var testInfo in testRunInfo.Tests)
        {
            total++;
            switch (MapStatus(testInfo.Status))
            {
                case TestStatus.Passed:
                    passed++;
                    executed++;
                    break;
                case TestStatus.Failed:
                    failed++;
                    executed++;
                    break;
                case TestStatus.NotExecuted:
                    notExecuted++;
                    break;
            }
        }
        var counters = new CountersType()
        {
            totalSpecified = true,
            total = total,
            executed = executed,
            passed = passed,
            failed = failed,
            notExecuted = notExecuted
        };
        var output = new TestRunOutputType();
        var runInfos = new TestRunTypeResultSummaryRunInfos();
        testSummary.Items = [counters, output, runInfos];
        return testSummary;
    }

    private static string SerializeToXML(TestRunType testRun)
    {
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(TestRunType));
            var xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true
            };
            using var stringWriter = new StringWriter();
            using var xmlTextWriter = XmlWriter.Create(stringWriter, xmlWriterSettings);
            xmlSerializer.Serialize(xmlTextWriter, testRun);
            return stringWriter.GetStringBuilder().ToString();
        }
        catch(Exception exception)
        {
            throw new TestRunnerException($"Failed to serialize XML. Exception message: {exception.Message}");
        }
    }
}
