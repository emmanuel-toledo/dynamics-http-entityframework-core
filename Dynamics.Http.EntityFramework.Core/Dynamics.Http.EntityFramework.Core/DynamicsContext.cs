using Dynamics.Http.EntityFramework.Core.Business.Handlers;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Connection;
using Dynamics.Http.EntityFramework.Core.Microsoft.Extensions.DependencyInjection;
using Dynamics.Http.EntityFramework.Core.Models.Generic;
using Dynamics.Http.EntityFramework.Core.Persistence;
using Newtonsoft.Json.Linq;

namespace Dynamics.Http.EntityFramework.Core
{
    public class DynamicsContext : IDynamicsContext
    {
        private readonly IDynamicsQueriesHandler _queriesHandler;

        public DynamicsContext(IDynamicsQueriesHandler queriesHandler)
        {
            _queriesHandler = queriesHandler;
        }

        //private readonly IHttpClientFactory _clientFactory;

        //private readonly IDynamicsContextOptionsBuilder _optionsBuilder;

        //public DynamicsContext(IHttpClientFactory clientFactory, IDynamicsContextOptionsBuilder optionsBuilder)
        //{
        //    _clientFactory = clientFactory;
        //    _optionsBuilder = optionsBuilder;
        //}

        public async Task<HttpResponseMessage> SendQueryAsync(HttpRequestMessage requestMessage)
        {
            if (requestMessage.Method != HttpMethod.Get)
                throw new Exception("SendQueryAsync method must be only for get data");
            return await _queriesHandler.SendRequestAsync(requestMessage);
        }

        public async Task<HttpResponseMessage> SendCommandAsync(HttpRequestMessage requestMessage)
        {
            if (requestMessage.Method == HttpMethod.Get)
                throw new Exception("SendCommandAsync method must be only for set data");
            return await _queriesHandler.SendRequestAsync(requestMessage);
        }

        public async Task<Guid> Create(string entityNamme, JObject data)
        {
            // TODO:
            return Guid.NewGuid();
        }

        public Task<bool> Delete(string entityNamme, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Entity?> RetriveById(string entityName, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Entity>> RetriveQueryFetchXml(string entityName, string fetchXml)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Entity>> RetriveQueryOData(string entityName, string oData)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> Update(string entityNamme, Guid id, JObject data)
        {
            throw new NotImplementedException();
        }
    }
}