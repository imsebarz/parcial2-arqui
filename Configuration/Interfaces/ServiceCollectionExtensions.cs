using AutoMapper;
using Database.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repositorios;
using Services.Interfaces;
using Services.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Interfaces
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            if (services != null)
            {
                services.AddTransient<IPedidoServicio, PedidoServicio>();
                services.AddTransient<IPedidoRepositorio, PedidoRepositorio>();
            }
        }

        public static void ConfigureMappings(this IServiceCollection services)
        {
            if (services != null)
            {
                //Automap settings
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
            }
        }

        public static void CreateDatabase(IWebHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ContextDatabase>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
