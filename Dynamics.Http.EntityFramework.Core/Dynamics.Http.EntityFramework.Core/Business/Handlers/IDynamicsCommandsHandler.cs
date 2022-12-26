using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Http.EntityFramework.Core.Business.Handlers
{
    public interface IDynamicsCommandsHandler
    {
        Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage);
    }
}
