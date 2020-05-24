using MicroS_Common;
using MicroS_Common.Authentication;
using MicroS_Common.Dispatchers;
using MicroS_Common.Services.Identity.Controllers;
using MicroS_Common.Services.Identity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MicroS.Services.Identity.Controllers
{
    public class TokensController : BaseTokensController
    {
        public TokensController(IAccessTokenService accessTokenService, 
            IRefreshTokenService refreshTokenService, 
            IDispatcher dispatcher, 
            IConfiguration configuration,
            IOptions<AppOptions> appOptions) : 
            base(accessTokenService, refreshTokenService, dispatcher, configuration,appOptions)
        {
        }
    }
}
