using MicroS_Common.Services.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using weerp.domain;

namespace weerp.api
{
    public class MyStartup : ServiceStartup
    {
        public MyStartup(IConfiguration configuration) : base(configuration)
        {
        }
        protected override bool UseCors => true;
        protected override Type DomainType => typeof(DomainProfile);
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
        }
       
    }
}
