using Microsoft.Extensions.Configuration;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Builder;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Connection;
using System.Reflection;
using Dynamics.Http.EntityFramework.Core.Annotations;
using Dynamics.Http.EntityFramework.Core.Models.Generic;

namespace Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context
{
    /// <summary>
    /// This class has the option deffinitions for each Entity that will works in the Framework request.
    /// </summary>
    public class DynamicsContextOptionsBuilder : IDynamicsContextOptionsBuilder
    {
        /// <summary>
        /// Dynamics connection information.
        /// </summary>
        public DynamicsConnection? DynamicsConnection { get; internal set; }

        /// <summary>
        /// Access entity collection.
        /// </summary>
        public ICollection<EntityBuilder> EntitiesBuilder { get; internal set; } = new HashSet<EntityBuilder>();

        /// <summary>
        /// Function to add a new entity builder deffinition.
        /// </summary>
        /// <param name="type">Entity class type reference.</param>
        internal void AddEntityBuilderDeffinition(Type type)
        {
            if (EntitiesBuilder.Any(x => x.EntityType == type))
                return;
            EntitiesBuilder.Add(new EntityBuilder(type));
        }

        /// <summary>
        /// Function to define the entities that will have access with the Framework.
        /// </summary>
        /// <param name="assembly">Assembly reference.</param>
        /// <returns>Context options builder with data.</returns>
        public DynamicsContextOptionsBuilder AddEntitiesDeffinitionFromAssembly(Assembly assembly)
        {
            var entities = assembly.GetTypes().Where(t => t.IsDefined(typeof(EntityAttribute)));
            foreach (var entity in entities)
                AddEntityBuilderDeffinition(entity);
            return this;
        }

        /// <summary>
        /// Function to define an entity as one to access with the framework.
        /// </summary>
        /// <typeparam name="TEntity">Entity class deffinition.</typeparam>
        /// <returns>Context options builder with data.</returns>
        public DynamicsContextOptionsBuilder AddEntityDeffinition<TEntity>() where TEntity : class, new()
        {
            AddEntityBuilderDeffinition(typeof(TEntity));
            return this;
        }

        /// <summary>
        /// Function to define connection to Dynamics using Configuration Section and automatic parse.
        /// </summary>
        /// <param name="configurationSection">Configuration Section with Dynamics connection information.</param>
        /// <exception cref="NullReferenceException">Configuration Section is null.</exception>
        /// <returns>Context options builder with data.</returns>
        public DynamicsContextOptionsBuilder UseAppRegistrationCredentials(IConfigurationSection configurationSection)
        {
            if(configurationSection is null)
                throw new NullReferenceException(nameof(configurationSection));
            DynamicsConnection = configurationSection.Get<DynamicsConnection>();
            if (DynamicsConnection is null)
                throw new NullReferenceException(nameof(DynamicsConnection));
            return this;
        }

        /// <summary>
        /// Function to define connection to Dynamics using custom instance of Dynamics Connection class. 
        /// </summary>
        /// <param name="connection">Dynamics connection class.</param>
        /// <exception cref="NullReferenceException">Dynamics connection is null</exception>
        /// <returns>Context options builder with data.</returns>
        public DynamicsContextOptionsBuilder UseAppRegistrationCredentials(DynamicsConnection connection)
        {
            if(connection is null)
                throw new NullReferenceException(nameof(connection));
            DynamicsConnection = connection;
            return this;
        }
    }
}
