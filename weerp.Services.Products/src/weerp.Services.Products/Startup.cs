using MicroS_Common.RabbitMq;
using MicroS_Common.Services.Service;
using Microsoft.Extensions.Configuration;
using System;
using weerp.domain;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;

namespace weerp.Services.Products
{


    public class Startup : ServiceStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        protected override Type DomainType => typeof(DomainProfile);

        protected override void SubscribeEventAndMessageBus(IBusSubscriber bus)
        {
            base.SubscribeEventAndMessageBus(bus);
            bus.SubscribeCommand<CreateProduct>(onError: (c, e) =>new CreateProductRejected(c.Id, e.Message, e.Code));
        }
    }
}
