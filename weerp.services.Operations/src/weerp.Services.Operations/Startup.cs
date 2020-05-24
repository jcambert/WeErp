using MicroS_Common.Services.Operations;
using Microsoft.Extensions.Configuration;
using System;
using weerp.domain;

namespace MicroS.Services.Operations
{
    public class Startup : ServiceStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {

        }

        protected override Type DomainType => typeof(DomainProfile);


    }
}
