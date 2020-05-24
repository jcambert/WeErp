using MicroS_Common.Mvc;
using MicroS_Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTracing;
using System;
using System.Threading.Tasks;
using weerp.api.Framework;
using weerp.api.Services;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Queries;

/// <summary>
/// @author: Ambert Jean-Christophe
/// @email: jc.ambert@free.fr
/// @created_on: Mon Nov 11 2019 15:18:52 GMT+0100 (GMT+01:00)
/// </summary>
namespace weerp.api.Controllers
{
    /// <summary>
    /// Product Controller that represent tha main API layer
    /// on wich each request must be made
    /// </summary>
    [AdminAuth]
    [Route("products")]
    public partial class ProductsController : BaseController
    {
        #region private varaibles
        private readonly IProductsService _productsService;
        private readonly ILogger<CreateProduct> _logger;
        #endregion

        #region constructors
        public ProductsController(IBusPublisher busPublisher, ITracer tracer,
            IProductsService productsService,ILogger<CreateProduct>logger) : base(busPublisher, tracer)
        {
            _productsService = productsService;
            _logger = logger;
        }
        #endregion

        #region public functions
         /// <summary>
        ///  Make a get query 
        /// </summary>
        /// <param name="query">The Query</param>
        /// <returns>A list of result</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] BrowseProducts query)
            => Collection(await _productsService.BrowseAsync(query));

        /// <summary>
        /// Search an Unique product based on its id
        /// </summary>
        /// <param name="id">The Id to search</param>
        /// <returns>The product</returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _productsService.GetAsync(id));

        /// <summary>
        ///  Create a new product
        /// </summary>
        /// <param name="command">The Create Command</param>
        /// <returns>Accepted response: The the operation Service</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProduct command)
            => await SendAsync(command.BindId(c => c.Id,_logger),  resourceId: command.Id, resource: "products");

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">the id of product to update</param>
        /// <param name="command">The Update Command</param>
        /// <returns>Accepted response: The the operation Service</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateProduct command)
            => await SendAsync(command.Bind(c => c.Id, id),resourceId: command.Id, resource: "products");

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">the id of product to delete</param>
        /// <returns>Accepted response: The the operation Service</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new DeleteProduct(id));

        #endregion
    }
}
