using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;

namespace weerp.Services.Products.Handlers
{


    public sealed class ReleaseProductsHandler : DomainCommandHandler<ReleaseProducts, Product> {
        private readonly ILogger<ReleaseProductsHandler> _logger;

        public ReleaseProductsHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Product> repo,ILogger<ReleaseProductsHandler>logger) : base(busPublisher, mapper, repo)
        {
            _logger = logger;
        }
        public override async Task HandleAsync(ReleaseProducts command, ICorrelationContext context)
        {
            foreach ((Guid productId, int quantity) in command.Products)
            {
                _logger.LogInformation($"Releasing a product: '{productId}' ({quantity})");
                var product = await Repository.GetAsync(productId);
                if (product == null)
                {
                    _logger.LogInformation($"Product was not found: '{productId}' (can't release).");

                    continue;
                }

                product.SetQuantity(product.Quantity + quantity);
                await Repository.UpdateAsync(product);
                _logger.LogInformation($"Released a product: '{productId}' ({quantity})");
            }

            await BusPublisher.PublishAsync(CreateEvent<ProductsReleased>(command), context);
        }
    }
}
