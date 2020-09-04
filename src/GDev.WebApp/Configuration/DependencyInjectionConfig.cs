using GDev.Business.Interfaces;
using GDev.Business.Notificacoes;
using GDev.Business.Services;
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

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAcessoService, AcessoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IModuloService, ModuloService>();

            return services;
        }
    }
}
