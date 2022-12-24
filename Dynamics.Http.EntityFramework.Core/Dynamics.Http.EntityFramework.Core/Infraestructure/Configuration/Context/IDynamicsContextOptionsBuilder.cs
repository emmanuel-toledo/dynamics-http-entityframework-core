namespace Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context
{
    /// <summary>
    /// Interface to define the options to configure the Entities for the Framework.
    /// </summary>
    public interface IDynamicsContextOptionsBuilder
    {
        /// <summary>
        /// Function to define an entity as one to access with the framework.
        /// </summary>
        /// <typeparam name="TEntity">Entity class deffinition.</typeparam>
        void AddEntityDeffinition<TEntity>() where TEntity : class, new();
    }
}
