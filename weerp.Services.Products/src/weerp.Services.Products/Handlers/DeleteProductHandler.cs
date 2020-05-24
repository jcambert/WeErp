using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{


    public sealed partial class DeleteProductHandler //: DomainCommandHandler<DeleteProduct, Product>
    {
      /*  public DeleteProductHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Product> repo) : base(busPublisher, mapper, repo)
        {
        }

        protected override async Task CheckExist(DeleteProduct command)
        {
            if (!await (Repository as IProductsRepository).ExistsAsync(command.Id))
            {
                throw new MicroSException("product_not_found",$"Product: '{command.Id}'  was not found.");
            }

        }

        public override async Task HandleAsync(DeleteProduct command, ICorrelationContext context)
        {
            await base.HandleAsync(command, context);
            await Repository.DeleteAsync(command.Id);
            await BusPublisher.PublishAsync(CreateEvent<ProductDeleted>(command) , context);

        }*/
    }
}
