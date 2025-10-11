using System;

namespace WebExtensions.Net;

/// <summary>
/// Base class for Combined Callback Parameter class object
/// </summary>
/// <param name="propertyTypes">The property types.</param>
/// <param name="propertyNames">The property names.</param>
public class BaseCombinedCallbackParameterObject(Type[] propertyTypes, string[] propertyNames) : BaseObject
{
    internal Type[] PropertyTypes { get; } = propertyTypes;
    internal string[] PropertyNames { get; } = propertyNames;
}
