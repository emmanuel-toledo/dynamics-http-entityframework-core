using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Http.EntityFramework.Core.Models.Generic
{
    
    public class Entity
    {
        public Guid EntityId { get; set; }

        public string SchemaName { get; set; }

        public string LogicalName { get; set; }

        public ICollection<Column> Columns { get; set; } = new HashSet<Column>();
    }
}
