using Dynamics.Http.EntityFramework.Core.Business.Handlers;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context;
using Dynamics.Http.EntityFramework.Core.Microsoft.Extensions.DependencyInjection;
using Dynamics.Http.EntityFramework.Core.Models.Generic;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Http.EntityFramework.Core.Business.Queries
{
    /// <summary>
    /// Implementation class for all Dynamics Queries function that the Framework has.
    /// </summary>
    public class DynamicsQueriesHandler : IDynamicsQueriesHandler
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly IDynamicsContextOptionsBuilder _optionsBuilder;

        public DynamicsQueriesHandler(IHttpClientFactory clientFactory, IDynamicsContextOptionsBuilder optionsBuilder)
        {
            _clientFactory = clientFactory;
            _optionsBuilder = optionsBuilder;
        }

        /// <summary>
        /// Async function to retrive message with custom request for queries only.
        /// </summary>
        /// <param name="requestMessage">Http request message record.</param>
        /// <returns>Http response message record.</returns>
        public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage)
        {
            var client = _clientFactory.CreateDynamicsClient(_optionsBuilder);
            var responseMessage = await client.SendAsync(requestMessage);
            return responseMessage;
        }

        /// <summary>
        /// Function to retrive a specific record with a specific Unique Identifier.
        /// </summary>
        /// <param name="entityName">Entity schema name for request.</param>
        /// <param name="id">Entity record unique identifier.</param>
        /// <returns>Entity model record.</returns>
        public Task<Entity?> RetriveById(string entityName, Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Function to retrive a collection of Entities using fetch Query.
        /// </summary>
        /// <param name="entityName">Entity schema name for request.</param>
        /// <param name="fetchXml">Fetch query param.</param>
        /// <returns>Collection of Entities.</returns>
        public Task<ICollection<Entity>> RetriveQueryFetchXml(string entityName, string fetchXml)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Function to retrive a collection of Entities using OData Query.
        /// </summary>
        /// <param name="entityName">Entity schema name for request.</param>
        /// <param name="oData">OData query param.</param>
        /// <returns>Collection of Entities.</returns>
        public Task<ICollection<Entity>> RetriveQueryOData(string entityName, string oData)
        {
            throw new NotImplementedException();
        }
    }
}
