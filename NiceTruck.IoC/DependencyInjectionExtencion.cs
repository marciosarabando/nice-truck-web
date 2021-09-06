using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NiceTruck.Repository.Data;
using NiceTruck.Application.Interfaces;
using NiceTruck.Application.BLL;
using NiceTruck.Domain.Interfaces.Repositories;
using NiceTruck.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace NiceTruck.IoC
{
    public static class DependencyInjectionExtencion
    {
        public static IServiceCollection ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDataBaseSqLite(configuration);
            services.ConfigureBlls();
            services.ConfigureRepositories();
            services.AddAutoMapper(typeof(DependencyInjectionExtencion));

            return services;
        }

        public static IServiceCollection ConfigureDataBaseSqLite(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>();

            using var db = new ApplicationContext(configuration);

            db.Database.Migrate();

            return services;
        }

        public static IServiceCollection ConfigureBlls(this IServiceCollection services)
        {
            services.AddScoped<ITruckBll, TruckBll>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<ITruckModelRepository, TruckModelRepository>();

            return services;
        }
    }
}