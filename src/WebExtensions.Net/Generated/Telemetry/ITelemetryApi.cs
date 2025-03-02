using JsBind.Net;
using System;

namespace WebExtensions.Net.Telemetry
{
    /// <summary>Use the <c>browser.telemetry</c> API to send telemetry data to the Mozilla Telemetry service. Restricted to Mozilla privileged webextensions.</summary>
    [JsAccessPath("telemetry")]
    public partial interface ITelemetryApi
    {
        /// <summary>Checks if Telemetry upload is enabled.</summary>
        [JsAccessPath("canUpload")]
        void CanUpload();

        /// <summary>Adds the value to the given keyed scalar.</summary>
        /// <param name="name">The scalar name</param>
        /// <param name="key">The key name</param>
        /// <param name="value">The numeric value to add to the scalar. Only unsigned integers supported.</param>
        [JsAccessPath("keyedScalarAdd")]
        [Obsolete("`keyedScalarAdd` is a no-op since Firefox 134 (see bug 1930196)")]
        void KeyedScalarAdd(string name, string key, int value);

        /// <summary>Sets the keyed scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name.</param>
        /// <param name="key">The key name.</param>
        /// <param name="value">The value to set the scalar to.</param>
        [JsAccessPath("keyedScalarSet")]
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void KeyedScalarSet(string name, string key, string value);

        /// <summary>Sets the keyed scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name.</param>
        /// <param name="key">The key name.</param>
        /// <param name="value">The value to set the scalar to.</param>
        [JsAccessPath("keyedScalarSet")]
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void KeyedScalarSet(string name, string key, bool value);

        /// <summary>Sets the keyed scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name.</param>
        /// <param name="key">The key name.</param>
        /// <param name="value">The value to set the scalar to.</param>
        [JsAccessPath("keyedScalarSet")]
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void KeyedScalarSet(string name, string key, int value);

        /// <summary>Sets the keyed scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name.</param>
        /// <param name="key">The key name.</param>
        /// <param name="value">The value to set the scalar to.</param>
        [JsAccessPath("keyedScalarSet")]
        [Obsolete("`keyedScalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void KeyedScalarSet(string name, string key, object value);

        /// <summary>Sets the keyed scalar to the maximum of the current and the passed value</summary>
        /// <param name="name">The scalar name.</param>
        /// <param name="key">The key name.</param>
        /// <param name="value">The numeric value to set the scalar to. Only unsigned integers supported.</param>
        [JsAccessPath("keyedScalarSetMaximum")]
        [Obsolete("`keyedScalarSetMaximum` is a no-op since Firefox 134 (see bug 1930196)")]
        void KeyedScalarSetMaximum(string name, string key, int value);

        /// <summary>Record an event in Telemetry. Throws when trying to record an unknown event.</summary>
        /// <param name="category">The category name.</param>
        /// <param name="method">The method name.</param>
        /// <param name="object">The object name.</param>
        /// <param name="value">An optional string value to record.</param>
        /// <param name="extra">An optional object of the form (string -> string). It should only contain registered extra keys.</param>
        [JsAccessPath("recordEvent")]
        [Obsolete("`recordEvent` is a no-op since Firefox 132 (see bug 1894533)")]
        void RecordEvent(string category, string method, string @object, string value = null, object extra = null);

        /// <summary>Register new events to record them from addons. See nsITelemetry.idl for more details.</summary>
        /// <param name="category">The unique category the events are registered in.</param>
        /// <param name="data">An object that contains registration data for 1+ events. Each property name is the category name, and the corresponding property value is an object of EventData type.</param>
        [JsAccessPath("registerEvents")]
        [Obsolete("`registerEvents` is a no-op since Firefox 132 (see bug 1894533)")]
        void RegisterEvents(string category, object data);

        /// <summary>Register new scalars to record them from addons. See nsITelemetry.idl for more details.</summary>
        /// <param name="category">The unique category the scalars are registered in.</param>
        /// <param name="data">An object that contains registration data for multiple scalars. Each property name is the scalar name, and the corresponding property value is an object of ScalarData type.</param>
        [JsAccessPath("registerScalars")]
        [Obsolete("`registerScalars` is a no-op since Firefox 134 (see bug 1930196)")]
        void RegisterScalars(string category, object data);

        /// <summary>Adds the value to the given scalar.</summary>
        /// <param name="name">The scalar name.</param>
        /// <param name="value">The numeric value to add to the scalar. Only unsigned integers supported.</param>
        [JsAccessPath("scalarAdd")]
        [Obsolete("`scalarAdd` is a no-op since Firefox 134 (see bug 1930196)")]
        void ScalarAdd(string name, int value);

        /// <summary>Sets the named scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name</param>
        /// <param name="value">The value to set the scalar to</param>
        [JsAccessPath("scalarSet")]
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void ScalarSet(string name, string value);

        /// <summary>Sets the named scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name</param>
        /// <param name="value">The value to set the scalar to</param>
        [JsAccessPath("scalarSet")]
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void ScalarSet(string name, bool value);

        /// <summary>Sets the named scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name</param>
        /// <param name="value">The value to set the scalar to</param>
        [JsAccessPath("scalarSet")]
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void ScalarSet(string name, int value);

        /// <summary>Sets the named scalar to the given value. Throws if the value type doesn't match the scalar type.</summary>
        /// <param name="name">The scalar name</param>
        /// <param name="value">The value to set the scalar to</param>
        [JsAccessPath("scalarSet")]
        [Obsolete("`scalarSet` is a no-op since Firefox 134 (see bug 1930196)")]
        void ScalarSet(string name, object value);

        /// <summary>Sets the scalar to the maximum of the current and the passed value</summary>
        /// <param name="name">The scalar name.</param>
        /// <param name="value">The numeric value to set the scalar to. Only unsigned integers supported.</param>
        [JsAccessPath("scalarSetMaximum")]
        [Obsolete("`scalarSetMaximum` is a no-op since Firefox 134 (see bug 1930196)")]
        void ScalarSetMaximum(string name, int value);

        /// <summary>Enable recording of events in a category. Events default to recording enabled. This allows to toggle recording for all events in the specified category.</summary>
        /// <param name="category">The category name.</param>
        /// <param name="enabled">Whether recording is enabled for events in that category.</param>
        [JsAccessPath("setEventRecordingEnabled")]
        [Obsolete("`setEventRecordingEnabled` is a no-op since Firefox 133 (see bug 1920562)")]
        void SetEventRecordingEnabled(string category, bool enabled);

        /// <summary>Submits a custom ping to the Telemetry back-end. See <c>submitExternalPing</c> inside TelemetryController.sys.mjs for more details.</summary>
        /// <param name="type">The type of the ping.</param>
        /// <param name="message">The data payload for the ping.</param>
        /// <param name="options">Options object.</param>
        [JsAccessPath("submitPing")]
        void SubmitPing(string type, object message, Options options);
    }
}
