using GDev.Business.Interfaces;
using GDev.Business.Notificacoes;
using GDev.Business.Services;
using GDev.Data.Context;
using GDev.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GDev.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDBContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
