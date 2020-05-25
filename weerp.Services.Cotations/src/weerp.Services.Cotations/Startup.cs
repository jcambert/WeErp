using MicroS_Common.Services.Service;
using Microsoft.Extensions.Configuration;
using System;
using weerp.domain;

namespace weerp.Services.Cotations
{
    public class Startup : ServiceStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override Type DomainType => typeof(DomainProfile);
    }
}
