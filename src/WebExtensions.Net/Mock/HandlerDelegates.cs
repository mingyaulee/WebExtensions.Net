namespace WebExtensions.Net.Mock;

/// <summary>
/// Api handler delegate.
/// </summary>
/// <param name="targetPath">The API target path.</param>
/// <param name="arguments">The arguments array.</param>
/// <param name="result">The output result.</param>
/// <returns>'True' if the call is handled, otherwise 'False'.</returns>
public delegate bool ApiHandler(string targetPath, object[] arguments, out object result);

/// <summary>
/// Object reference handler delegate.
/// </summary>
/// <param name="objectReference">The object reference.</param>
/// <param name="targetPath">The target path.</param>
/// <param name="arguments">The arguments array.</param>
/// <param name="result">The output result.</param>
/// <returns>'True' if the call is handled, otherwise 'False'.</returns>
public delegate bool ObjectReferenceHandler(object objectReference, string targetPath, object[] arguments, out object result);
