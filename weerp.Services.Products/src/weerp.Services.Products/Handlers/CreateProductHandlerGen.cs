using AutoMapper;
using MicroS_Common.Domain;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
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
    public partial class CreateProductHandler : DomainCommandHandler<CreateProduct,Product>
    {
        

        #region Constructors
        public CreateProductHandler(
            IBrowseProductRepository productRepository,
            IBusPublisher busPublisher,
            IMapper mapper,
            IValidate<Product> validator,
            IValidateContext ctx ) :base(busPublisher,mapper,productRepository,validator,ctx)
        {
        }
        #endregion

        #region Protected Overrides functions
        /// <summary>
        /// Check if the model exist by Command
        /// </summary>
        /// <param name="command">The command in wich information can be use do check if the model exist in database</param>
        /// <returns>Nothing</returns>
        protected override async Task<bool> CheckExist(Product product)
        {
            if (await Repository.ExistsAsync(p=> p.Name == product.Name))
            {
                throw new MicroSException("product_already_exists",$"Product: '{product.Name}' already exists.");
            }
            return true;
           
        }
        #endregion

        #region Public Overrides functions
        /// <summary>
        ///  Handle the command with context
        /// </summary>
        /// <param name="command">The command to handle</param>
        /// <param name="context">The correlation context</param>
        /// <returns></returns>
        public override async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {

            await base.HandleAsync(command, context);

            var product = GetDomainObject(command);
            
            await Repository.AddAsync(product);

            await BusPublisher.PublishAsync(CreateEvent<ProductCreated>(command), context);
        }
        #endregion
    }
}
