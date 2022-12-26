using Dynamics.Http.EntityFramework.Core.Business.Handlers;
using Dynamics.Http.EntityFramework.Core.Infraestructure.Configuration.Context;
using Dynamics.Http.EntityFramework.Core.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics.Http.EntityFramework.Core.Business.Commands
{
    public class DynamicsCommandsHandler : IDynamicsCommandsHandler
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly IDynamicsContextOptionsBuilder _optionsBuilder;

        public DynamicsCommandsHandler(IHttpClientFactory clientFactory, IDynamicsContextOptionsBuilder optionsBuilder)
        {
            _clientFactory = clientFactory;
            _optionsBuilder = optionsBuilder;
        }

        public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage requestMessage)
        {
            var client = _clientFactory.CreateDynamicsClient(_optionsBuilder);
            var responseMessage = await client.SendAsync(requestMessage);
            return responseMessage;
        }
    }
}
