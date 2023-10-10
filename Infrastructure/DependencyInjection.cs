using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Default");
            services.AddDbContext<DeviceContext>(o => o.UseSqlServer(config.GetConnectionString("Default")
                , b => b.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName)));
            services.AddScoped<IDeviceRepository, DeviceRepository>();

            return services;
        }
    }
}
