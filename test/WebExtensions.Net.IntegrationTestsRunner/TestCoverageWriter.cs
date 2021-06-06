using System;
using System.IO;
using WebExtensions.Net.IntegrationTestsRunner.Models;

namespace WebExtensions.Net.IntegrationTestsRunner
{
    public static class TestCoverageWriter
    {
        public static void Write(string hitsFilePath, int[] hitsArray)
        {
            try
            {
                using var fs = new FileStream(hitsFilePath, FileMode.CreateNew);
                using var bw = new BinaryWriter(fs);
                bw.Write(hitsArray.Length);
                foreach (int hitCount in hitsArray)
                {
                    bw.Write(hitCount);
                }
            }
            catch (Exception exception)
            {
                throw new TestRunnerException($"Failed to write test coverage hits file at path '{hitsFilePath}'. Exception message: {exception.Message}");
            }
        }
    }
}
