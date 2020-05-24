using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroS_Common.Dispatchers;
using MicroS_Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using WeErpServicesDiscounts.Dto;
using WeErpServicesDiscounts.Messages.Commands;
using WeErpServicesDiscounts.Queries;

namespace WeErpServicesDiscounts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public DiscountsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        // Idempotent
        // No side effects
        // Doesn't mutate a state
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDto>>> Get([FromQuery] FindDiscounts query)
            => Ok(await _dispatcher.QueryAsync(query));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DiscountDetailsDto>> Get([FromRoute] GetDiscount query)
        {
            var discount = await _dispatcher.QueryAsync(query);
            if (discount is null)
            {
                return NotFound();
            }

            return discount;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateDiscount command)
        {
            await _dispatcher.SendAsync(command.BindId(c => c.Id));

            return Accepted();
        }
    }
}