using Dynamics.Http.EntityFramework.Core.Models.Generic;

namespace Dynamics.Http.EntityFramework.Core.Business.Handlers
{
    /// <summary>
    /// Interface that define the different functions that can be used in the Framework.
    /// </summary>
    public interface IDynamicsQueriesHandler
    {
        /// <summary>
        /// Async function to retrive message with custom request for queries only.
        /// </summary>
        /// <param name="requestMessage">Http request message record.</param>
        /// <returns>Http response message record.</returns>
        Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage);

        /// <summary>
        /// Function to retrive a specific record with a specific Unique Identifier.
        /// </summary>
        /// <param name="entityName">Entity schema name for request.</param>
        /// <param name="id">Entity record unique identifier.</param>
        /// <returns>Entity model record.</returns>
        Task<Entity?> RetriveById(string entityName, Guid id);

        /// <summary>
        /// Function to retrive a collection of Entities using fetch Query.
        /// </summary>
        /// <param name="entityName">Entity schema name for request.</param>
        /// <param name="fetchXml">Fetch query param.</param>
        /// <returns>Collection of Entities.</returns>
        Task<ICollection<Entity>> RetriveQueryFetchXml(string entityName, string fetchXml);

        /// <summary>
        /// Function to retrive a collection of Entities using OData Query.
        /// </summary>
        /// <param name="entityName">Entity schema name for request.</param>
        /// <param name="oData">OData query param.</param>
        /// <returns>Collection of Entities.</returns>
        Task<ICollection<Entity>> RetriveQueryOData(string entityName, string oData);
    }
}
