using System;

namespace WebExtension.Net
{
    /// <summary>
    /// Base class for types that has multiple type choices
    /// </summary>
    public class BaseMultiTypeObject : BaseObject
    {
        private readonly object value;

        /// <summary>
        /// Creates a new instance of the BaseMultiTypeObject class
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="valueType">The value type.</param>
        protected BaseMultiTypeObject(object value, Type valueType)
        {
            this.value = value;
            ValueType = valueType;
        }

        /// <summary>
        /// The value.
        /// </summary>
        public object Value
        {
            get
            {
                if (value is BaseObject baseObject && IsInitialized)
                {
                    baseObject.Initialize(webExtensionJSRuntime, referenceId, accessPath);
                }

                return value;
            }
        }

        /// <summary>
        /// The type of the value.
        /// </summary>
        public Type ValueType { get; }
    }
}
