using Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Connection;
using Dynamics.Http.EntityFramework.Core.Models.Generic;
using Dynamics.Http.EntityFramework.Core.Persistence;
using Newtonsoft.Json.Linq;

namespace Dynamics.Http.EntityFramework.Core
{
    public class DynamicsContext : IDynamicsContext
    {
        private readonly DynamicsConnection _connection;

        private readonly DynamicsContextOptionsBuilder? _optionsBuilder;

        public DynamicsContext(DynamicsConnection connection)
            => _connection = connection;

        public DynamicsContext(DynamicsConnection connection, DynamicsContextOptionsBuilder optionsBuilder)
        {
            _connection = connection;
            _optionsBuilder = optionsBuilder;
        }

        public Task<Guid> Create(string entityNamme, JObject data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string entityNamme, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Entity?> RetriveById(string entityName, Guid id)
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