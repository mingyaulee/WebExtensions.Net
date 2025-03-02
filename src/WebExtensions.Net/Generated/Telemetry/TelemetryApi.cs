using JsBind.Net;
using System;

namespace WebExtensions.Net.Telemetry
{
    /// <inheritdoc />
    public partial class TelemetryApi : BaseApi, ITelemetryApi
    {
        /// <summary>Creates a new instance of <see cref="TelemetryApi" />.</summary>
        /// <param name="jsRuntime">The JS runtime adapter.</param>
        /// <param name="accessPath">The base API access path.</param>
        public TelemetryApi(IJsRuntimeAdapter jsRuntime, string accessPath) : base(jsRuntime, AccessPaths.Combine(accessPath, "telemetry"))
        {
        }

        /// <inheritdoc />
        public virtual void CanUpload()
            => InvokeVoid("canUpload");

        /// <inheritdoc />
        [Obsolete("`keyedScalarAdd` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void KeyedScalarAdd(string name, string key, int value)
            => InvokeVoid("keyedScalarAdd", name, key, value);

        /// <inheritdoc />
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void KeyedScalarSet(string name, string key, string value)
            => InvokeVoid("keyedScalarSet", name, key, value);

        /// <inheritdoc />
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void KeyedScalarSet(string name, string key, bool value)
            => InvokeVoid("keyedScalarSet", name, key, value);

        /// <inheritdoc />
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void KeyedScalarSet(string name, string key, int value)
            => InvokeVoid("keyedScalarSet", name, key, value);

        /// <inheritdoc />
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void KeyedScalarSet(string name, string key, object value)
            => InvokeVoid("keyedScalarSet", name, key, value);

        /// <inheritdoc />
        [Obsolete("`keyedScalarSetMaximum` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void KeyedScalarSetMaximum(string name, string key, int value)
            => InvokeVoid("keyedScalarSetMaximum", name, key, value);

        /// <inheritdoc />
        [Obsolete("`recordEvent` is a no-op since Firefox 132 (see bug 1894533)")]
        public virtual void RecordEvent(string category, string method, string @object, string value = null, object extra = null)
            => InvokeVoid("recordEvent", category, method, @object, value, extra);

        /// <inheritdoc />
        [Obsolete("`registerEvents` is a no-op since Firefox 132 (see bug 1894533)")]
        public virtual void RegisterEvents(string category, object data)
            => InvokeVoid("registerEvents", category, data);

        /// <inheritdoc />
        [Obsolete("`registerScalars` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void RegisterScalars(string category, object data)
            => InvokeVoid("registerScalars", category, data);

        /// <inheritdoc />
        [Obsolete("`scalarAdd` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void ScalarAdd(string name, int value)
            => InvokeVoid("scalarAdd", name, value);

        /// <inheritdoc />
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void ScalarSet(string name, string value)
            => InvokeVoid("scalarSet", name, value);

        /// <inheritdoc />
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void ScalarSet(string name, bool value)
            => InvokeVoid("scalarSet", name, value);

        /// <inheritdoc />
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void ScalarSet(string name, int value)
            => InvokeVoid("scalarSet", name, value);

        /// <inheritdoc />
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void ScalarSet(string name, object value)
            => InvokeVoid("scalarSet", name, value);

        /// <inheritdoc />
        [Obsolete("`scalarSetMaximum` is a no-op since Firefox 134 (see bug 1930196)")]
        public virtual void ScalarSetMaximum(string name, int value)
            => InvokeVoid("scalarSetMaximum", name, value);

        /// <inheritdoc />
        [Obsolete("`setEventRecordingEnabled` is a no-op since Firefox 133 (see bug 1920562)")]
        public virtual void SetEventRecordingEnabled(string category, bool enabled)
            => InvokeVoid("setEventRecordingEnabled", category, enabled);

        /// <inheritdoc />
        public virtual void SubmitPing(string type, object message, Options options)
            => InvokeVoid("submitPing", type, message, options);
    }
}
