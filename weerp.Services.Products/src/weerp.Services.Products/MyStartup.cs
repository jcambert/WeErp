using MicroS_Common.Services.Service;
using Microsoft.Extensions.Configuration;
using System;
using weerp.domain;

namespace weerp.Services.Products
{


    public class MyStartup : ServiceStartup
    {
        public MyStartup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override Type DomainType => typeof(DomainProfile);
    }
}
