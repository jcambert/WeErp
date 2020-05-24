using MicroS_Common.Services.Identity;
using MicroS_Common.Services.Identity.Dto;
using Microsoft.Extensions.Configuration;
using System;

namespace MicroS.Services.Identity
{
    public class Startup : BaseIdentityStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override Type DomainType => typeof(User);
    }
}
