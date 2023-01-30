using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            // configure DI for repositores
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            return services;
        }

        public static IServiceCollection SetupDbContexts(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IWebShopDbContext, WebShopDbContext>();

            services.AddDbContext<WebShopDbContext>();

            return services;
        }
    }
}
