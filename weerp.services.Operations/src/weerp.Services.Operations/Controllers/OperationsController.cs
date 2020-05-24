using MicroS_Common;
using MicroS_Common.Dispatchers;
using MicroS_Common.Services.Operations.Controllers;
using MicroS_Common.Services.Operations.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MicroS.Services.Operations.Controllers
{

    public class OperationsController : BaseOperationsController
    {
        public OperationsController(
            IDispatcher dispatcher, 
            IConfiguration config, 
            IOperationsStorage operationsStorage,
            IOptions<AppOptions> appOptions) : 
            base(dispatcher, config, operationsStorage,appOptions)
        { }

    }
}
