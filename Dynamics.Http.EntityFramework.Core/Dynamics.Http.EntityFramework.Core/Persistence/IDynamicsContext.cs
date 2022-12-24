using Dynamics.Http.EntityFramework.Core.Models.Generic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dynamics.Http.EntityFramework.Core.Persistence
{
    public interface IDynamicsContext
    {
        Task<Entity?> RetriveById(string entityName, Guid id);

        Task<ICollection<Entity>> RetriveQueryFetchXml(string entityName, string fetchXml);

        Task<ICollection<Entity>> RetriveQueryOData(string entityName, string oData);

        Task<Guid> Create(string entityNamme, JObject data);

        Task<bool> Update(string entityNamme, Guid id, JObject data);

        Task<bool> Delete(string entityNamme, Guid id);
    }
}
