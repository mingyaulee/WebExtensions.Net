using System;

namespace WebExtensions.Net
{
    /// <summary>
    /// Base class for Combined Callback Parameter class object
    /// </summary>
    public class BaseCombinedCallbackParameterObject : BaseObject
    {
        /// <summary>
        /// Creates a new instance of the BaseCombinedCallbackParameterObject class
        /// </summary>
        /// <param name="propertyTypes">The property types.</param>
        /// <param name="propertyNames">The property names.</param>
        public BaseCombinedCallbackParameterObject(Type[] propertyTypes, string[] propertyNames)
        {
            PropertyTypes = propertyTypes;
            PropertyNames = propertyNames;
        }

        internal Type[] PropertyTypes { get; }
        internal string[] PropertyNames { get; }
    }
}
