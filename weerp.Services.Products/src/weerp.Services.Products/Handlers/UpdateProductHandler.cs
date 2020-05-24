namespace weerp.Services.Products.Handlers
{
    public sealed partial class UpdateProductHandler //: DomainCommandHandler<UpdateProduct, Product>
    {
       /* public UpdateProductHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Product> repo) : base(busPublisher, mapper, repo)
        {
        }

        protected override async Task CheckExist(UpdateProduct command)
        {
            if (!await (Repository as IProductsRepository).ExistsAsync(command.Name))
            {
                throw new MicroSException("product_not_found",$"Product with id: '{command.Id}' was not found.");
            }
        }

        public override async Task HandleAsync(UpdateProduct command, ICorrelationContext context)
        {
            
            await base.HandleAsync(command, context);
            var product = GetDomainObject(command);
            await Repository.UpdateAsync(product);
            await BusPublisher.PublishAsync(CreateEvent<ProductUpdated>(command), context);
        }*/
    }
}
