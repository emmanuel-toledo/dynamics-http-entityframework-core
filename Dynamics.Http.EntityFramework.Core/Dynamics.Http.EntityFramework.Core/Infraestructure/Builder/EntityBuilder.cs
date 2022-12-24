using Dynamics.Http.EntityFramework.Core.Design.AnnotationAttributes;

namespace Dynamics.Http.EntityFramework.Core.Infraestructure.Builder
{
    /// <summary>
    /// This class contains the attributes definition of a entity (class) and the properties it has (fields).
    /// </summary>
    public class EntityBuilder
    {
        /// <summary>
        /// Entity model attributes definitions.
        /// </summary>
        private EntityAttributes? _entityAttributes { get; set; }

        /// <summary>
        /// List of entity fields attributes definitions.
        /// </summary>
        private ICollection<ColumnAttributes> _fieldAttributes { get; set; } = new HashSet<ColumnAttributes>();

        /// <summary>
        /// Get entity builder unique identifier.
        /// </summary>
        public Guid EntityBuilderId { get; } = Guid.NewGuid();

        /// <summary>
        /// Get entity type.
        /// </summary>
        public Type EntityType { get; init; }

        /// <summary>
        /// <para>Initialize the entity builder using a class type.</para>
        /// <para>Set configuration values for 'EntityAttributes' and 'FieldAttributes' definitions.</para>
        /// </summary>
        /// <param name="entityType">Entity (class) type.</param>
        public EntityBuilder(Type entityType)
        {
            EntityType = entityType;
            ExtractEntityAttributes();
            ExtractEntityFieldAttributes();
        }

        /// <summary>
        /// This function set the value of entity attributes by each class instance.
        /// </summary>
        /// <exception cref="NullReferenceException">The entity attribues were not defined.</exception>
        private void ExtractEntityAttributes()
        {
            var entityAttributes = EntityType.GetCustomAttributes(typeof(EntityAttributes), true).FirstOrDefault() as EntityAttributes;
            if (entityAttributes is null)
                throw new NullReferenceException($"The entity attributes definitions in class {EntityType.Name} is null.");
            _entityAttributes = entityAttributes;
        }

        /// <summary>
        /// This function set the value of entity field attributes by each property in a class.
        /// </summary>
        private void ExtractEntityFieldAttributes()
        {
            var properties = EntityType.GetProperties();
            if (properties is null || properties.Length <= 0)
                return;
            foreach (var property in properties)
            {
                var fieldAttributes = property.GetCustomAttributes(typeof(ColumnAttributes), true).FirstOrDefault() as ColumnAttributes;
                if (fieldAttributes is null)
                    return;
                _fieldAttributes.Add(fieldAttributes);
            }
        }
    }
}
