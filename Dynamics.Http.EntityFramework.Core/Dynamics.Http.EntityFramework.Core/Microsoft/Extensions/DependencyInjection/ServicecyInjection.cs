using Dynamics.Http.EntityFramework.Core.Annotations;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Connection;
using Dynamics.Http.EntityFramework.Core.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using CacheControlHeaderValue = System.Net.Http.Headers.CacheControlHeaderValue;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Dynamics.Http.EntityFramework.Core.Business.Handlers;
using Dynamics.Http.EntityFramework.Core.Business.Queries;
using Dynamics.Http.EntityFramework.Core.Business.Commands;

namespace Dynamics.Http.EntityFramework.Core.Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        //public static void AddDynamicsContext(
        //    [NotNull] this IServiceCollection serviceCollection, 
        //    Action<DynamicsContextOptionsBuilder> options)
        //{
        //    var contextBuilder = options.DynamicInvoke(new DynamicsContextOptionsBuilder()) as DynamicsContextOptionsBuilder;
        //    if(contextBuilder is null)
        //        throw new NullReferenceException(nameof(options));

        //    serviceCollection.AddScoped<IDynamicsContextOptionsBuilder, DynamicsContextOptionsBuilder>(s => contextBuilder);

        //    //var connection = options.Target.GetType().GetProperty("_connection").GetValue(options.Target, null) as DynamicsConnection;
        //    if (contextBuilder.Connection is null)
        //        throw new NullReferenceException(nameof(contextBuilder.Connection));
        //    serviceCollection.ConfigureDynamicsClient(contextBuilder.Connection);

        //    //serviceCollection.AddScoped<IDynamicsContext, DynamicsContext>();
        //}

        public static void AddDynamicsContext(
            [NotNull] this IServiceCollection serviceCollection,
            Func<DynamicsContextOptionsBuilder, DynamicsContextOptionsBuilder> options)
        {
            if (options is null)
                throw new NullReferenceException(nameof(options));

            var contextBuilder = options.Invoke(new DynamicsContextOptionsBuilder());

            if (contextBuilder.DynamicsConnection is null)
                throw new NullReferenceException(nameof(contextBuilder.DynamicsConnection));

            serviceCollection.AddScoped<IDynamicsContextOptionsBuilder, DynamicsContextOptionsBuilder>(s => contextBuilder);

            serviceCollection.ConfigureDynamicsClient(contextBuilder.DynamicsConnection);

            serviceCollection.AddScoped<IDynamicsQueriesHandler, DynamicsQueriesHandler>();

            serviceCollection.AddScoped<IDynamicsCommandsHandler, DynamicsCommandsHandler>();

            serviceCollection.AddScoped<IDynamicsContext, DynamicsContext>();
        }

        internal static void ConfigureDynamicsClient(this IServiceCollection serviceCollection, DynamicsConnection connection)
        {
            serviceCollection.AddHttpClient(nameof(DynamicsConnection), options =>
            {
                options.Timeout = new TimeSpan(0, 2, 0);
                options.DefaultRequestHeaders.ExpectContinue = false;
                options.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                options.DefaultRequestHeaders.Add("Prefer", "odata.include-annotations=\"*\"");
                options.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
                options.DefaultRequestHeaders.Add("OData-Version", "4.0");
                options.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                options.BaseAddress = new Uri($"{ connection.Resource }/api/data/v{ connection.Version ?? "9.2"}/");
            });
        }

        internal static HttpClient CreateDynamicsClient(this IHttpClientFactory clientFactory, IDynamicsContextOptionsBuilder optionsBuilder)
        {
            var client = clientFactory.CreateClient(nameof(DynamicsConnection));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetAuthorizationToken(optionsBuilder.DynamicsConnection));
            //client.DefaultRequestHeaders.Add("OData-Version", "4.0");
            //client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            return client;
        }

        //internal static HttpClient CreateDynamicsClient(this IServiceProvider serviceProvider)
        //{
        //    var contextBuilder = serviceProvider.GetRequiredService<DynamicsContextOptionsBuilder>();
        //    var client = serviceProvider.GetRequiredService<IHttpClientFactory>().CreateClient("DynamicsConnection");
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetAuthorizationToken(contextBuilder.Connection));
        //    //client.DefaultRequestHeaders.Add("OData-Version", "4.0");
        //    //client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        //    return client;
        //}

        private static string GetAuthorizationToken(DynamicsConnection connection)
        {
            try
            {
                var app = ConfidentialClientApplicationBuilder.Create(connection.ClientId)
                    .WithAuthority(AzureCloudInstance.AzurePublic, connection.TenantId)
                    .WithClientSecret(connection.ClientSecret)
                    .Build();
                var acquireToken = app.AcquireTokenForClient(new string[] { $"{connection.Resource}/.default" }).ExecuteAsync().Result;
                return acquireToken.AccessToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //public static void AddDynamicsContext<TContext>
        //    ([NotNull] this IServiceCollection services, IConfigurationSection configurationSection)
        //    where TContext : DynamicsContext
        //{
        //    if (configurationSection is null)
        //        throw new ArgumentNullException(nameof(IConfigurationSection));
        //    services.AddScoped<IDynamicsContext, TContext>();
        //}



        //public static void AddDynamicsContext
        //    ([NotNull] this IServiceCollection services, 
        //    IConfigurationSection configurationSection)
        //{
        //    if (configurationSection is null)
        //        throw new ArgumentNullException(nameof(IConfigurationSection));
        //    services.AddScoped<IDynamicsContext, DynamicsContext>();
        //}

        //public static void AddDynamicsContext
        //    ([NotNull] this IServiceCollection services, 
        //    IConfigurationSection configurationSection, 
        //    DynamicsContextOptionsBuilder optionsBuilder)
        //{
        //    if (configurationSection is null)
        //        throw new ArgumentNullException(nameof(IConfigurationSection));
        //    var connection = new DynamicsConnection();
        //    configurationSection.Bind(connection);
        //    services.AddScoped<IDynamicsContext, DynamicsContext>(s => new DynamicsContext(connection, optionsBuilder));
        //}

        //public static void AddDynamicsContext
        //    ([NotNull] this IServiceCollection services, 
        //    DynamicsConnection connection, 
        //    DynamicsContextOptionsBuilder optionsBuilder)
        //{
        //    if (connection is null)
        //        throw new ArgumentNullException(nameof(DynamicsConnection));
        //    if (optionsBuilder is null)
        //        throw new ArgumentNullException(nameof(DynamicsContextOptionsBuilder));
        //    services.AddScoped<IDynamicsContext, DynamicsContext>(s => new DynamicsContext(connection, optionsBuilder));
        //}
    }
}
