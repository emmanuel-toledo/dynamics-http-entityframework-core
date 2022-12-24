namespace Dynamics.Http.EntityFramework.Core.Design.AnnotationAttributes
{
    /// <summary>
    /// This class contains the implementation of the custom attributes to use for an entity deffinition.
    /// </summary>
    public class EntityAttributes : Attribute
    {
        /// <summary>
        /// Get and set schema name of an entity.
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// Get and set logical name of an entity.
        /// </summary>
        public string LogicalName { get; set; }

        /// <summary>
        /// Initialize the entity attributes for a class.
        /// </summary>
        /// <param name="schemaName">Entity schema name.</param>
        /// <param name="logicalName">Entity logical name.</param>
        public EntityAttributes(string schemaName, string logicalName)
        {
            SchemaName = schemaName;
            LogicalName = logicalName;
        }
    }
}
