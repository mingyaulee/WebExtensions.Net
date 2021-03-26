(function (global) {
    const objectReferences = {
    };
    let objectReferencesCount = 0;
    async function invokeOnObjectReference({ referenceId, targetPath, isFunction, returnObjectReferenceId }, ...args) {
        let target = objectReferences[referenceId];
        if (referenceId === "browser") {
            target = global.browser;
        }
        targetPath.split(".").forEach(functionName => target = target?.[functionName]);

        if (isFunction && !target) {
            throw new Error(`Unable to find function ${targetPath} on object '${referenceId}'.`);
        }

        try {
            let result = isFunction ? target.apply(target, args) : target;
            if (result instanceof Promise) {
                result = await result;
            }
            if (returnObjectReferenceId) {
                objectReferencesCount++;
                objectReferences[returnObjectReferenceId] = result;
            }
            return result;
        } catch (error) {
            console.error(referenceId, targetPath, args, target);
            throw new Error(`Failed to execute function ${targetPath} on object '${referenceId}': ${error.message}`);
        }
    }
    async function removeObjectReference({ referenceId }) {
        if (objectReferences[referenceId] !== null) {
            objectReferencesCount--;
            objectReferences[referenceId] = null;
        }
    }
    global.WebExtensionNet = {
        InvokeOnObjectReference: invokeOnObjectReference,
        RemoveObjectReference: removeObjectReference,
        GetObjectReferences: () => objectReferences,
        GetObjectReferencesCount: () => objectReferencesCount
    };
})(globalThis);