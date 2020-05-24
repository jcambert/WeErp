using AutoMapper;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;

namespace weerp.domain.Products.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ConstructUsing(e => new ProductDto() { Id = e.Id, Name = e.Name, Description = e.Description, Price = e.Price, Quantity = e.Quantity, Vendor = e.Vendor });
            CreateMap<CreateProduct, Product>().ConstructUsing(e => new Product(e.Id, e.Name, e.Description, e.Vendor, e.Price, e.Quantity));
            CreateMap<CreateProduct, ProductCreated>().ConstructUsing(e => new ProductCreated(e.Id, e.Name, e.Description, e.Vendor, e.Price, e.Quantity));
            CreateMap<UpdateProduct, ProductUpdated>().ConstructUsing(e => new ProductUpdated(e.Id, e.Name, e.Description, e.Vendor, e.Price, e.Quantity));
            CreateMap<ReleaseProducts, ProductsReleased>().ConstructUsing(e => new ProductsReleased(e.OrderId, e.Products));
            CreateMap<DeleteProduct, ProductDeleted>().ConstructUsing(e => new ProductDeleted(e.Id));
            CreateMap<ReserveProducts, ProductsReserved>().ConstructUsing(e => new ProductsReserved(e.OrderId, e.Products));
        }
    }
}
