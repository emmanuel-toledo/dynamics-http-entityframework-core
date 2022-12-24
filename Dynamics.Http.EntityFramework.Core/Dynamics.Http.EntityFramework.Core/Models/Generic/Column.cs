using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Http.EntityFramework.Core.Models.Generic
{
    public class Column
    {
        public object Value { get; set; }

        public string SchemaName { get; set; }

        public string RelatedEntitySchemaName { get; set; }
    }
}
