using MicroS_Common;
using MicroS_Common.Controllers;
using MicroS_Common.Dispatchers;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace weerp.Services.Cotations.Controllers
{
    
    public class CotationsController : BaseController
    {
        public CotationsController(IDispatcher dispatcher, IConfiguration config, IOptions<AppOptions> appOptions)
            : base(dispatcher, config, appOptions)
        {
        }
     
    }
}
