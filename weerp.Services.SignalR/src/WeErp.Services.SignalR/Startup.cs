using MicroS_Common.Services.Service;
using Microsoft.Extensions.Configuration;
using System;

namespace MicroS.Services.SignalR
{
    public class Startup : ServiceStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override Type DomainType =>typeof(object);
    }
}
