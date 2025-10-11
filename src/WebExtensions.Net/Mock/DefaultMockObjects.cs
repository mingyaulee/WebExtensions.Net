using WebExtensions.Net.Storage;

namespace WebExtensions.Net.Mock;

/// <summary>
/// Default mock objects.
/// </summary>
public static class DefaultMockObjects
{
    /// <summary>
    /// The default mock local storage object.
    /// </summary>
    public static readonly StorageArea LocalStorage = new();

    /// <summary>
    /// The default mock managed storage object.
    /// </summary>
    public static readonly StorageArea ManagedStorage = new();

    /// <summary>
    /// The default mock sync storage object.
    /// </summary>
    public static readonly StorageAreaWithUsage SyncStorage = new();
}
