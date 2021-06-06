using System;

namespace WebExtensions.Net.Mock.Handlers
{
    /// <summary>
    /// Mock API Handler.
    /// </summary>
    internal class MockApiHandler : IMockHandler
    {
        /// <summary>
        /// The API call target path.
        /// </summary>
        public string ApiTargetPath { get; set; }

        /// <inheritdoc />
        public Delegate DelegateHandler { get; set; }
    }
}
