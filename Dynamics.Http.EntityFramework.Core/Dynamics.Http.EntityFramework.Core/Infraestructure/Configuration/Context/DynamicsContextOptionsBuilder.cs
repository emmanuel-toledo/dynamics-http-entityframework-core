using Dynamics.Http.EntityFramework.Core.Infraestructure.Builder;

namespace Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context
{
    /// <summary>
    /// This class has the option deffinitions for each Entity that will works in the Framework request.
    /// </summary>
    public class DynamicsContextOptionsBuilder : IDynamicsContextOptionsBuilder
    {
        /// <summary>
        /// Access entity collection.
        /// </summary>
        internal ICollection<EntityBuilder> EntitiesBuilder { get; set; } = new HashSet<EntityBuilder>();

        /// <summary>
        /// Function to define an entity as one to access with the framework.
        /// </summary>
        /// <typeparam name="TEntity">Entity class deffinition.</typeparam>
        public void AddEntityDeffinition<TEntity>() where TEntity : class, new()
            => EntitiesBuilder.Add(new EntityBuilder(typeof(TEntity)));
    }
}
