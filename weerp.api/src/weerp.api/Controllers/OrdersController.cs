using MicroS_Common.Mvc;
using MicroS_Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.Threading.Tasks;
using weerp.api.Framework;
using weerp.api.Messages.Commands.Orders;
using weerp.api.Queries;
using weerp.api.Services;

namespace weerp.api.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IBusPublisher busPublisher, ITracer tracer,
            IOrdersService ordersService) : base(busPublisher, tracer)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseOrders query)
            => Collection(await _ordersService.BrowseAsync(query.Bind(q => q.CustomerId, UserId)));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(IsAdmin ? await _ordersService.GetAsync(id) : await _ordersService.GetAsync(UserId, id));

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrder command)
            => await SendAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId),
                resourceId: command.Id, resource: "orders");

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id, CompleteOrder command)
            => await SendAsync(command.Bind(c => c.Id, id).Bind(c => c.CustomerId, UserId),
                resourceId: command.Id, resource: "orders");

        [HttpPost("{id}/approve")]
        [AdminAuth]
        public async Task<IActionResult> Complete(Guid id, ApproveOrder command)
            => await SendAsync(command.Bind(c => c.Id, id),
                resourceId: command.Id, resource: "orders");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new CancelOrder(id, UserId));
    }
}
