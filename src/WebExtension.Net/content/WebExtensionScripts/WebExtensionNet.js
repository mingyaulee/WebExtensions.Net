(function (global) {
    global.WebExtensionNet = {
        Execute: async function (api, ...args) {
            let target = global.browser;
            api.split(".").forEach(api => target = target?.[api]);

            if (!target) {
                throw new Error(`Unable to find API browser.${api}`);
            }

            try {
                let result = target.apply(target, args);
                if (result instanceof Promise) {
                    result = await result;
                }
                return result;
            } catch (error) {
                console.error(api, args, target);
                throw new Error(`Failed to execute browser.${api}: ${error.message}`);
            }
        }
    };
})(globalThis);