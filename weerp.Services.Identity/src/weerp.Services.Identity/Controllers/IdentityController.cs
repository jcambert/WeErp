using MicroS_Common;
using MicroS_Common.Dispatchers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Services.Identity.Controllers;
using MicroS_Common.Services.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MicroS.Services.Identity.Controllers
{
    [Route("")]
    public class IdentityController : BaseIdentityController
    {
        public IdentityController(
            IIdentityService identityService, 
            IRefreshTokenService refreshTokenService,
            IBusPublisher busPublisher,
            IDispatcher dispatcher,
            IConfiguration configuration,
            IOptions<AppOptions> appOptions) : 
            base(identityService, refreshTokenService, busPublisher, dispatcher, configuration,appOptions)
        {
        }
    }
   
}
