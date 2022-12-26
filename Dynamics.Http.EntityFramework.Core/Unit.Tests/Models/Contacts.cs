using Dynamics.Http.EntityFramework.Core.Design;
using Dynamics.Http.EntityFramework.Core.Annotations;

namespace Unit.Tests.Models
{
    [Entity("contact", "contact")]
    public class Contacts
    {
        [Column("contactid", "contactId", ColumnTypes.UniqueIdentifier)]
        public Guid ContactId { get; set; }

        [Column("name", "name", ColumnTypes.Text)]
        public string Name { get; set; }
    }
}
