﻿namespace Dynamics.Http.EntityFramework.Core.Design.AnnotationAttributes
{
    /// <summary>
    /// This class contains the implementation of the custom attributes to use for an entity field deffinition.
    /// </summary>
    public class ColumnAttributes : Attribute
    {
        /// <summary>
        /// Get and set entity Schema name.
        /// </summary>
        public string SchemaName { get; set; }

        /// <summary>
        /// Get an set entity Logical schema name.
        /// </summary>
        public string LogicalName { get; set; }

        /// <summary>
        /// Get and set entity field type.
        /// </summary>
        public FieldTypes FieldType { get; set; }

        /// <summary>
        /// Initialize the entity field attributes for a class property.
        /// </summary>
        /// <param name="schemaName">Field schema name.</param>
        /// <param name="logicalName">Field logical name.</param>
        /// <param name="fieldType">Field type.</param>
        public ColumnAttributes(string schemaName, string logicalName, FieldTypes fieldType)
        {
            SchemaName = schemaName;
            LogicalName = logicalName;
            FieldType = fieldType;
        }
    }
}
