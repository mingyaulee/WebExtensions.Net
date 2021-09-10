using System.Linq;
using JsBind.Net;
using WebExtensions.Net;
using WebExtensions.Net.Mock;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension method for service registration.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the required services for using WebExtensions API.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add the services to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddWebExtensions(this IServiceCollection services)
        {
            services.AddJsBind(options => options.UseInProcessJsRuntime());
            services.AddTransient<IWebExtensionsApi, WebExtensionsApi>();
            return services;
        }

        /// <summary>
        /// Adds the required services for using Mock WebExtensions API.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add the services to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IServiceCollection AddMockWebExtensions(this IServiceCollection services)
        {
            AddWebExtensions(services);
            // Replace registered IJsRuntimeAdapter with the mock adapter
            services.Remove(services.First(service => service.ServiceType == typeof(IJsRuntimeAdapter)));
            services.AddScoped<IJsRuntimeAdapter, MockJsRuntimeAdapter>();
            return services;
        }
    }
}
