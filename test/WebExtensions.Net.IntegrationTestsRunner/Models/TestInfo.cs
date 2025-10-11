namespace WebExtensions.Net.IntegrationTestsRunner.Models;

public class TestInfo
{
    public string TestId { get; set; }
    public string ExecutionId { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Duration { get; set; }
    public string Skip { get; set; }
    public string DeclaringTypeFullName { get; set; }
    public string MethodName { get; set; }
    public string FailMessage { get; set; }
    public string StackTrace { get; set; }
}
