using Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Connection;
using Dynamics.Http.EntityFramework.Core.Microsoft.Extensions.DependencyInjection;
using Dynamics.Http.EntityFramework.Core.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Unit.Tests.Models;

namespace Unit.Tests
{
    [TestClass]
    public class ServiceInitializerUT
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IServiceCollection _serviceCollection;

        private readonly IDynamicsContext _dynamicsContext;

        public ServiceInitializerUT()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddDynamicsContext(contextOptions =>
            {
                contextOptions.UseAppRegistrationCredentials(new DynamicsConnection()
                {
                    Version = "9.2",
                    TenantId = "346a1d1d-e75b-4753-902b-74ed60ae77a1",
                    ClientId = "5f32110f-cf6e-4557-9e40-391ff6870b12",
                    ClientSecret = "-~E1gn3-40G7ZDu_jdzD68~Uyb~U9CB~7s",
                    Resource = "https://latammx-caeuvmdesarrollo.crm.dynamics.com"
                });
                contextOptions.AddEntityDeffinition<Contacts>();
                contextOptions.AddEntityDeffinition<Incidents>();
                contextOptions.AddEntitiesDeffinitionFromAssembly(typeof(ServiceInitializerUT).Assembly);
                return contextOptions;
            });

            _serviceProvider = _serviceCollection.BuildServiceProvider();

            _dynamicsContext = _serviceProvider.GetRequiredService<IDynamicsContext>();

            //{
            //    options.UseAppRegistrationCredentials(new DynamicsConnection()
            //    {
            //        Version = "9.2",
            //        TenantId = "346a1d1d-e75b-4753-902b-74ed60ae77a1",
            //        ClientId = "5f32110f-cf6e-4557-9e40-391ff6870b12",
            //        ClientSecret = "-~E1gn3-40G7ZDu_jdzD68~Uyb~U9CB~7s",
            //        Resource = "https://latammx-caeuvmdesarrollo.crm.dynamics.com"
            //    });
            //});

            // Configure use of Dynamics 365 CRM Framework.
            //_serviceCollection.AddDynamicsContext(options =>
            //{
            //    options.UseAppRegistrationCredentials(new DynamicsConnection()
            //    {
            //        Version = "9.2",
            //        TenantId = "346a1d1d-e75b-4753-902b-74ed60ae77a1",
            //        ClientId = "5f32110f-cf6e-4557-9e40-391ff6870b12",
            //        ClientSecret = "-~E1gn3-40G7ZDu_jdzD68~Uyb~U9CB~7s",
            //        Resource = "https://latammx-caeuvmdesarrollo.crm.dynamics.com"
            //    });
            //});
        }

        [TestMethod]
        public async Task Test_Generic_Get_Request()
        {
            //var id = _dynamicsContext.Create("incidents", new Newtonsoft.Json.Linq.JObject());
            //var entity = _dynamicsContext.RetriveById("incidents", Guid.NewGuid());
            var responseMessage = await _dynamicsContext.SendQueryAsync(new HttpRequestMessage(HttpMethod.Get, "entities"));
            responseMessage = await _dynamicsContext.SendQueryAsync(new HttpRequestMessage(HttpMethod.Post, "entities"));
            Console.WriteLine(responseMessage.StatusCode);
        }
    }
}