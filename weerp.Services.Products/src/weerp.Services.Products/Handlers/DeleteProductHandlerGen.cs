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

/// <summary>
/// @author: Ambert Jean-Christophe
/// @email: jc.ambert@free.fr
/// @created_on: Mon Nov 11 2019 16:19:55 GMT+0100 (GMT+01:00)
/// </summary>
namespace weerp.Services.Products.Handlers
{


    /// <summary>
    /// Delete Product Handler
    /// </summary>
    public partial class DeleteProductHandler : DomainCommandHandler<DeleteProduct, Product>
    {
        #region Constructors
        public DeleteProductHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Product> repo) : base(busPublisher, mapper, repo)
        {
        }
        #endregion
        #region Protected Overrides functions
        /// <summary>
        /// Check if the model exist by Command
        /// </summary>
        /// <param name="command">The command in wich information can be use do check if the model exist in database</param>
        /// <returns>Nothing</returns>
        protected override async Task CheckExist(Product product)
        {
            if (!await Repository.ExistsAsync(product.Id))
            {
                throw new MicroSException("product_not_found",$"Product: '{product.Id}'  was not found.");
            }

        }
        #endregion

        #region Public Overrides functions
        /// <summary>
        ///  Handle the command with context
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <param name="context">The correlation context</param>
        /// <returns></returns>
        public override async Task HandleAsync(DeleteProduct command, ICorrelationContext context)
        {
            await base.HandleAsync(command, context);
            await Repository.DeleteAsync(command.Id);
            await BusPublisher.PublishAsync(CreateEvent<ProductDeleted>(command) , context);

        }
        #endregion
    }
}
