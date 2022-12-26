using Dynamics.Http.EntityFramework.Core.Annotations;
using Dynamics.Http.EntityFramework.Core.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit.Tests.Models
{
    [Entity("incidents", "incident")]
    public class Incidents
    {
        [Column("incidentid", "incidentId", ColumnTypes.UniqueIdentifier)]
        public Guid IncidentId { get; set; }

        [Column("ticketnumber", "ticketNumber", ColumnTypes.Text)]
        public string TicketNumber { get; set; }
    }
}
