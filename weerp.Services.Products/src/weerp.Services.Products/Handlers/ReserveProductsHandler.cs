using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;

namespace weerp.Services.Products.Handlers
{

    public sealed class ReserveProductsHandler : DomainCommandHandler<ReserveProducts, Product>
    {
        private readonly ILogger<ReserveProductsHandler> _logger;

        public ReserveProductsHandler(IBusPublisher busPublisher, IMapper mapper, MicroS_Common.Repository.IRepository<Product> repo, ILogger<ReserveProductsHandler> logger) : base(busPublisher, mapper, repo)
        {
            _logger = logger;
        }

        public override async Task HandleAsync(ReserveProducts command, ICorrelationContext context)
        {
            foreach ((Guid productId, int quantity) in command.Products)
            {
                _logger.LogInformation($"Reserving a product: '{productId}' ({quantity})");
                var product = await Repository.GetAsync(productId);
                if (product == null)
                {
                    _logger.LogInformation($"Product was not found: '{productId}' (can't reserve).");

                    continue;
                }

                product.SetQuantity(product.Quantity - quantity);
                await Repository.UpdateAsync(product);
                _logger.LogInformation($"Reserved a product: '{productId}' ({quantity})");
            }

            await BusPublisher.PublishAsync(CreateEvent<ProductsReserved>(command), context);
        }
    }

}
