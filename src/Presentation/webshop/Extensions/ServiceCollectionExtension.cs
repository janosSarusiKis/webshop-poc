using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webshop.Services;

namespace webshop.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection SetupApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
