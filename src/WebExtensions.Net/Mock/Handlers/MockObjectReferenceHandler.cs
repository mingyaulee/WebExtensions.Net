using System;

namespace WebExtensions.Net.Mock.Handlers;

/// <summary>
/// Mock Object Reference Handler.
/// </summary>
internal class MockObjectReferenceHandler : IMockHandler
{
    /// <summary>
    /// The object reference.
    /// </summary>
    public object ObjectReference { get; set; }

    /// <summary>
    /// The object reference call target path.
    /// </summary>
    public string TargetPath { get; set; }

    /// <inheritdoc />
    public Delegate DelegateHandler { get; set; }
}
