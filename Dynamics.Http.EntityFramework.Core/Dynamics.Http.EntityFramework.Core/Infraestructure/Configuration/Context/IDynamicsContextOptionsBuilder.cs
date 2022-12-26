using Microsoft.Extensions.Configuration;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Connection;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Builder;
using System.Reflection;

namespace Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context
{
    /// <summary>
    /// Interface to define the options to configure the Entities for the Framework.
    /// </summary>
    public interface IDynamicsContextOptionsBuilder
    {
        ///// <summary>
        ///// Dynamics connection information.
        ///// </summary>
        DynamicsConnection? DynamicsConnection { get; }

        ///// <summary>
        ///// Access entity collection.
        ///// </summary>
        ICollection<EntityBuilder> EntitiesBuilder { get; }

        /// <summary>
        /// Function to define the entities that will have access with the Framework.
        /// </summary>
        /// <param name="assembly">Assembly reference.</param>
        /// <returns>Context options builder with data.</returns>
        DynamicsContextOptionsBuilder AddEntitiesDeffinitionFromAssembly(Assembly assembly);

        /// <summary>
        /// Function to define an entity as one to access with the Framework.
        /// </summary>
        /// <typeparam name="TEntity">Entity class deffinition.</typeparam>
        /// <returns>Context options builder with data.</returns>
        DynamicsContextOptionsBuilder AddEntityDeffinition<TEntity>() where TEntity : class, new();

        /// <summary>
        /// Function to define the use of credential to connect with Dynamics using HTTP API and Configuration Section.
        /// </summary>
        /// <param name="configurationSection">Configuration Section with format.</param>
        /// <returns>Context options builder with data.</returns>
        DynamicsContextOptionsBuilder UseAppRegistrationCredentials(IConfigurationSection configurationSection);

        /// <summary>
        /// Function to define the use of credential to connect with Dynamics using HTTP API and Dynamics Connection class.
        /// </summary>
        /// <param name="connection">Dynamics Connection model.</param>
        /// <returns>Context options builder with data.</returns>
        DynamicsContextOptionsBuilder UseAppRegistrationCredentials(DynamicsConnection connection);
    }
}
