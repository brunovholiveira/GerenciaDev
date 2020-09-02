using GDev.Business.Interfaces;
using GDev.Data.Context;
using GDev.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GDev.WebApp.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDBContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAcessoRespository, AcessoRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();

            return services;
        }
    }
}
