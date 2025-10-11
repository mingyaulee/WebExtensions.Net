using System;

namespace WebExtensions.Net.Mock.Handlers;

/// <summary>
/// Mock Handler interface.
/// </summary>
public interface IMockHandler
{
    /// <summary>
    /// The delegate to handle the mock call.
    /// </summary>
    Delegate DelegateHandler { get; set; }
}
