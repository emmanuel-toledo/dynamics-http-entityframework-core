using Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Connection;
using Dynamics.Http.EntityFramework.Core.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Http.EntityFramework.Core.Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        //public static void AddDynamicsContext<TContext>
        //    ([NotNull] this IServiceCollection services, IConfigurationSection configurationSection)
        //    where TContext : DynamicsContext
        //{
        //    if (configurationSection is null)
        //        throw new ArgumentNullException(nameof(IConfigurationSection));
        //    services.AddScoped<IDynamicsContext, TContext>();
        //}

        internal static void ConfigureDynamicsConnection(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var connection = configurationSection.Get<DynamicsConnection>();
            services.AddHttpClient("DynamicsConnection", options =>
            {

            });
        }

        internal static void ConfigureDynamicsConnection(this IServiceCollection services, DynamicsConnection connection)
        {
            services.AddHttpClient("DynamicsConnection", options =>
            {

            });
        }

        public static void AddDynamicsContext([NotNull] this IServiceCollection services, IConfigurationSection configurationSection)
        {
            if (configurationSection is null)
                throw new ArgumentNullException(nameof(IConfigurationSection));
            services.AddScoped<IDynamicsContext, DynamicsContext>();
        }

        public static void AddDynamicsContext
            ([NotNull] this IServiceCollection services, 
            IConfigurationSection configurationSection, 
            DynamicsContextOptionsBuilder optionsBuilder)
        {
            if (configurationSection is null)
                throw new ArgumentNullException(nameof(IConfigurationSection));
            var connection = new DynamicsConnection();
            configurationSection.Bind(connection);
            services.AddScoped<IDynamicsContext, DynamicsContext>(s => new DynamicsContext(connection, optionsBuilder));
        }

        public static void AddDynamicsContext
            ([NotNull] this IServiceCollection services, 
            DynamicsConnection connection) 
        {
            if (connection is null)
                throw new ArgumentNullException(nameof(DynamicsConnection));
            services.AddScoped<IDynamicsContext, DynamicsContext>(s => new DynamicsContext(connection));
        }

        public static void AddDynamicsContext
            ([NotNull] this IServiceCollection services, 
            DynamicsConnection connection, 
            DynamicsContextOptionsBuilder optionsBuilder)
        {
            if (connection is null)
                throw new ArgumentNullException(nameof(DynamicsConnection));
            if (optionsBuilder is null)
                throw new ArgumentNullException(nameof(DynamicsContextOptionsBuilder));
            services.AddScoped<IDynamicsContext, DynamicsContext>(s => new DynamicsContext(connection, optionsBuilder));
        }
    }
}
