using MicroS_Common;
using MicroS_Common.Controllers;
using MicroS_Common.Dispatchers;
using MicroS_Common.Redis;
using MicroS_Common.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;

namespace weerp.Services.Products.Controllers
{
    //[Route("Products")]
    public class ProductsController : BaseController
    {
        public ProductsController(IDispatcher dispatcher, IConfiguration config, IOptions<AppOptions> appOptions)
            : base(dispatcher,config,appOptions)
        {
        }
        [Cached]
        [HttpGet]
        public async Task<ActionResult<PagedResult<ProductDto>>> Get([FromQuery] BrowseProducts query)
            => Collection(await QueryAsync(query));
        [Cached]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetAsync([FromRoute] GetProduct query)
            => Single(await QueryAsync(query));
    }
}
